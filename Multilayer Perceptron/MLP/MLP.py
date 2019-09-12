import numpy as np

trainDataPath = '../Dane/xor.txt'
testDataPath = '../Dane/xor_ext.txt'

inputNode = 2 # input neuron count
hiddenNode = 4 # hidden neuron count
outputNode = 1 # output neuron count

learningRate = 0.1
maxIterations = int(20000)
showEvery = int(maxIterations / 5)

def loadData(path ,input, output):
   data = np.loadtxt(path)
   for x in range(len(data)):
           i = data[x]
           i = i[:-outputNode]
           input.append(i)
           o = data[x]
           o = o[inputNode:]
           output.append(o)

def activation(x): # sigmoid
    return 1 / (1 + np.exp(-x))

def activation_d(x): # sigmoid derivative
    return x * (1 - x)

def cost(y1, y2):
    return (np.linalg.norm(y1 - y2) ** 2) / 2

def cost_d(y1, y2):
    return (y1 - y2) * activation_d(y1)

def mlpTrain(trainInputData, trainOutputData, inputNode, hiddenNode, outputNode, learningRate=1e-2, maxIterations=int(1e5), showEvery=1000):
    hw = np.random.rand(inputNode, hiddenNode) # hidden layer weights
    hb = np.random.randn(1, hiddenNode) # hidden layer bias
    
    ow = np.random.rand(hiddenNode, outputNode) # output layer weights
    ob = np.random.randn(1, outputNode) # output layer bias
    
    for iteration in range(maxIterations):
        if (iteration % showEvery == 0):
            print('Iteration', iteration, ":")
        for xi, yi in zip(trainInputData, trainOutputData):
            xi = xi[np.newaxis, :]
            
            ha = np.dot(xi, hw) + hb
            ho = activation(ha)
            
            oa = np.dot(ho, ow) + ob
            oo = activation(oa)
            
            c = cost(oo, yi)
            
            grad_ob = cost_d(oo, yi)
            grad_ow = np.dot(ho.T, grad_ob)
            
            ow -= learningRate * grad_ow
            ob -= learningRate * grad_ob
            
            grad_hb = np.dot(grad_ob, ow.T) * (ho * (1 - ho))
            grad_hw = np.dot(xi.T, grad_hb)
            
            hw -= learningRate * grad_hw
            hb -= learningRate * grad_hb
            
            if (iteration % showEvery == 0):
                print(xi, '->', oo, 'cost', c)
    
    return (hw, ow), (hb, ob)
            
def mlpPredict(x, w, b):
    hw, ow = w
    hb, ob = b
    ha = np.dot(x, hw) + hb
    ho = activation(ha)
    oa = np.dot(ho, ow) + ob
    oo = activation(oa)
    return oo


# -----------------------------------------------------------------------------
if __name__ == '__main__':
    trainInputData = []
    trainOutputData = []
    loadData(trainDataPath, trainInputData, trainOutputData)
    trainInputData =  np.asarray(trainInputData)
    trainOutputData = np.asarray(trainOutputData)

    print("MLP ", inputNode, "-", hiddenNode, "-", outputNode, ", learning rate = ", learningRate, ", epoch = ", maxIterations, " trening start!")
    print("")
    w, b = mlpTrain(trainInputData, trainOutputData, inputNode, hiddenNode, outputNode, learningRate, maxIterations, showEvery)
    
    print("")
    print('Trening result:')
    for x in trainInputData:
        o = mlpPredict(x, w, b)
        print(x, '->', o)

    hw, ow = w
    hb, ob = b
    print('Hidden layer weights:')
    print(hw)
    print('Hidden layer bias:')
    print(hb)
    print('Output layer weights:')
    print(ow)
    print('Output layer bias:')
    print(ob)

    print("")
    print('Test result:')
    testInputData = []
    testOutputData = []
    loadData(testDataPath, testInputData, testOutputData)
    testInputData =  np.asarray(testInputData)
    testOutputData = np.asarray(testOutputData)

    counter = 0
    for x in testInputData:
        o = mlpPredict(x, w, b)
        if o < 0.1:
            print(x, '->', -1)
        if o > 0.75:
            print(x, '->', 1)
        print('Expected: ', testOutputData[counter])
        counter = counter + 1
        print("")
    print('Done')