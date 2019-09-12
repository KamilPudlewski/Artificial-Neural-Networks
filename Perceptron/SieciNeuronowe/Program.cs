using System;
using System.Collections.Generic;
using System.IO;

namespace SieciNeuronowe
{
    class Program
    {
        public static void Main(string[] args)
        {
            Perceptron perceptron = new Perceptron();

            perceptron.SetLearningRate(0.01);
            perceptron.SetIterationCount(10000);

            perceptron.loadExampleDataset('A');
            perceptron.StartLearningAndTesting();

            perceptron.loadExampleDataset('B');
            perceptron.StartLearningAndTesting();

            perceptron.loadExampleDataset('C');
            perceptron.StartLearningAndTesting();

            perceptron.loadExampleDataset('D');
            perceptron.StartLearningAndTesting();

            perceptron.loadExampleDataset('E');
            perceptron.StartLearningAndTesting();

            perceptron.loadExampleDataset('F');
            perceptron.StartLearningAndTesting();

            perceptron.loadExampleDataset('G');
            perceptron.StartLearningAndTesting();

            Console.ReadKey();
        }
    } 
}
