import numpy as np
from PIL import Image
import requests
from io import BytesIO

import tensorflow as tf
import tensorflow.contrib.eager as tfe

from tensorflow.python.keras.preprocessing import image as kp_image
from tensorflow.python.keras import models 
from tensorflow.python.keras import losses
from tensorflow.python.keras import layers
from tensorflow.python.keras import backend as K

#tf.enable_eager_execution()
tf.compat.v1.enable_eager_execution()

import linecache

print("Keras Tensorflow Image Started")

style_exponents = []
num_iterations = 1
style_image_patch = ""

def load_config():
    global num_iterations
    global style_image_patch
    #file = open("..\\..\\config.cfg", "r")
    file = open("../../../config.cfg", "r")  
    style_exponents.append(float(file.readline().strip().replace(',','.')))
    num_iterations = int(file.readline().strip())
    style_image_patch = file.readline().strip()
    #style_image_patch = style_image_patch[3:]
    print("Config file readed sucessfullty!")

load_config()

def load_image(url):
    max_dim = 512
    response = requests.get(url)
    image = Image.open(BytesIO(response.content))
    image.thumbnail((max_dim, max_dim))
    return image.copy()

def load_image_from_disk(path):
    max_dim = 512
    image = Image.open(path)
    image.thumbnail((max_dim, max_dim))
    return image.copy()

def create_progress_file(n):
    f = open("progress/"+str(n)+".txt","w+")
    f.close

def process_image(image):
    image = kp_image.img_to_array(image)
    image = np.expand_dims(image, axis=0)
    return tf.keras.applications.vgg19.preprocess_input(image)

def deprocess_image(processed_image):
    image = processed_image.copy()
    if len(image.shape) == 4:
        image = np.squeeze(image, 0)
    image[:, :, 0] += 103.939
    image[:, :, 1] += 116.779
    image[:, :, 2] += 123.68
    image = image[:, :, ::-1]
    return np.clip(image, 0, 255).astype('uint8')

content_layers = ['block5_conv2'] 

style_layers = ['block1_conv1',
                'block2_conv1',
                'block3_conv1', 
                'block4_conv1', 
                'block5_conv1']

num_content_layers = len(content_layers)
num_style_layers = len(style_layers)

def get_model():
    vgg = tf.keras.applications.vgg19.VGG19(include_top=False, weights='imagenet')
    vgg.trainable = False
    style_outputs = [vgg.get_layer(name).output for name in style_layers]
    content_outputs = [vgg.get_layer(name).output for name in content_layers]
    model_outputs = style_outputs + content_outputs
    model = models.Model(vgg.input, model_outputs)
    for layer in model.layers:
        layer.trainable = False
    return model

def get_content_loss(base_content, target):
    return tf.reduce_mean(tf.square(base_content - target))

def gram_matrix(input_tensor):
    channels = int(input_tensor.shape[-1])
    a = tf.reshape(input_tensor, [-1, channels])
    n = tf.shape(a)[0]
    gram = tf.matmul(a, a, transpose_a=True)
    return gram / tf.cast(n, tf.float32)

def get_style_loss(base_style, gram_target):
    height, width, channels = base_style.get_shape().as_list()
    gram_style = gram_matrix(base_style)
    return tf.reduce_mean(tf.square(gram_style - gram_target))

def get_feature_representations(model, content_image, style_image):
    content_image = process_image(content_image)
    style_image = process_image(style_image)
    style_outputs = model(style_image)
    content_outputs = model(content_image)
    style_features = [style_layer[0] for style_layer in style_outputs[:num_style_layers]]
    content_features = [content_layer[0] for content_layer in content_outputs[num_style_layers:]]
    
    return style_features, content_features

def compute_loss(model, loss_weights, init_image, gram_style_features, content_features):
    style_weight, content_weight = loss_weights
    model_outputs = model(init_image)
    style_output_features = model_outputs[:num_style_layers]
    content_output_features = model_outputs[num_style_layers:]
    style_score = 0
    content_score = 0
    weight_per_style_layer = 1.0 / float(num_style_layers)
    
    for target_style, comb_style in zip(gram_style_features, style_output_features):
        style_score += weight_per_style_layer * get_style_loss(comb_style[0], target_style)
        
    weight_per_content_layer = 1.0 / float(num_content_layers)
    
    for target_content, comb_content in zip(content_features, content_output_features):
        content_score += weight_per_content_layer * get_content_loss(comb_content[0], target_content)
        
    style_score *= style_weight
    content_score *= content_weight
    loss = style_score + content_score
    return loss, style_score, content_score

def compute_grads(cfg):
    with tf.GradientTape() as tape: 
        all_loss = compute_loss(**cfg)
    total_loss = all_loss[0]
    return tape.gradient(total_loss, cfg['init_image']), all_loss

def run_style_transfer(content_image, style_image, num_iterations, content_weight, style_weight): 
    model = get_model()
        
    style_features, content_features = get_feature_representations(model, content_image, style_image)
    gram_style_features = [gram_matrix(style_feature) for style_feature in style_features]
    init_image = process_image(content_image)
    init_image = tfe.Variable(init_image, dtype=tf.float32)
    
    opt = tf.compat.v1.train.AdamOptimizer(learning_rate=5, beta1=0.99, epsilon=1e-1)
    #opt = tf.train.AdamOptimizer(learning_rate=5, beta1=0.99, epsilon=1e-1)
    iter_count = 1
    best_loss, best_image = float('inf'), None
    loss_weights = (style_weight, content_weight)
    
    cfg = {
        'model': model,
        'loss_weights': loss_weights,
        'init_image': init_image,
        'gram_style_features': gram_style_features,
        'content_features': content_features
    }
    
    norm_means = np.array([103.939, 116.779, 123.68])
    min_vals = -norm_means
    max_vals = 255 - norm_means
    
    for i in range(num_iterations):
        print("Iteration " + str(i))
        create_progress_file(i)
        grads, all_loss = compute_grads(cfg)
        loss, style_score, content_score = all_loss
        opt.apply_gradients([(grads, init_image)])
        clipped = tf.clip_by_value(init_image, min_vals, max_vals)
        init_image.assign(clipped)
        if loss < best_loss:
            best_loss = loss
            best_image = deprocess_image(init_image.numpy())
            
    return best_image, best_loss


content_images = {
    'content': f'..\\..\\..\\Image\\Image.png',
}

style_images = {
    'style': style_image_patch
}

for name, address in content_images.items():
    content_images[name] = load_image_from_disk(address)
    print(f'content image {name}')
    #content_images[name].show()

for name, address in style_images.items():
    #style_images[name] = load_image(address)
    style_images[name] = load_image_from_disk(address)
    print(f'style image {name}')
    #style_images[name].show()


from os.path import isfile
from time import time
from datetime import timedelta

for content_image_name, content_image in content_images.items():
    for style_image_name, style_image in style_images.items():
        for e in style_exponents:
            path = f'results/{content_image_name}_{style_image_name}_w{e}.jpg'
            if isfile(path):
                continue
            style_weight = e
            start = time()
            best_image, best_loss = run_style_transfer(
                content_image,
                style_image,
                content_weight=1,
                style_weight=style_weight,
                num_iterations=num_iterations
            )
            end = time()
            delta = timedelta(seconds=(end - start))
            print(f'{path} done in {str(delta)}')
            best_image = Image.fromarray(best_image)
            best_image.save(path)

print("Ended")