using System;
using System.Collections.Generic;
using System.IO;

namespace SieciNeuronowe
{
    class Perceptron
    {
        private double[,] input;
        private int inputCount;

        private string dataTreningFile;
        private string dataTestingFile;
        private int datasetNumber;

        double[] weights;
        private double bias;
        private double learningRate;
        private double output;
        private int age;

        private double pocketBias;
        private int pocketAge;
        private int pocketDatasetNumber;

        private int iterationCount;

        private int goodDetection;
        private int badDetection;

        bool changeLearningRateFlag = false;
        bool changeIterationCountFlag = false;

        public void loadExampleDataset(char datasetType)
        {
            switch (datasetType)
            {
                case 'A':
                    //100%
                    dataTreningFile = "..\\..\\..\\..\\Dane\\iris_2vs3_A_tr.txt";
                    dataTestingFile = "..\\..\\..\\..\\Dane\\iris_2vs3_A_te.txt";
                    break;
                case 'B':
                    //100%
                    dataTreningFile = "..\\..\\..\\..\\Dane\\iris_2vs3_B_tr.txt";
                    dataTestingFile = "..\\..\\..\\..\\Dane\\iris_2vs3_B_te.txt";
                    break;
                case 'C':
                    dataTreningFile = "..\\..\\..\\..\\Dane\\iris_2vs3_C_tr.txt";
                    dataTestingFile = "..\\..\\..\\..\\Dane\\iris_2vs3_C_te.txt";
                    break;
                case 'D':
                    dataTreningFile = "..\\..\\..\\..\\Dane\\iris_2vs3_D_tr.txt";
                    dataTestingFile = "..\\..\\..\\..\\Dane\\iris_2vs3_D_te.txt";
                    break;
                case 'E':
                    //100%
                    dataTreningFile = "..\\..\\..\\..\\Dane\\iris_2vs3_E_tr.txt";
                    dataTestingFile = "..\\..\\..\\..\\Dane\\iris_2vs3_E_te.txt";
                    break;
                case 'F':
                    // 75%
                    dataTreningFile = "..\\..\\..\\..\\Dane\\xor.txt";
                    dataTestingFile = "..\\..\\..\\..\\Dane\\xor.txt";
                    break;
                case 'G':
                    // 62%
                    dataTreningFile = "..\\..\\..\\..\\Dane\\xor_ext.txt";
                    dataTestingFile = "..\\..\\..\\..\\Dane\\xor_ext.txt";
                    break;
                default:
                    Console.WriteLine("Bad dataset type");
                    return;
            }

            readDataset(dataTreningFile);
            readDataset(dataTestingFile);
            preparePerceptronSettings();
            Console.WriteLine("Loaded example dataset: " + datasetType);
        }

        public void loadDatasetFiles(string dataTreningFile, string dataTestingFile)
        {
            readDataset(dataTreningFile);
            readDataset(dataTestingFile);
            preparePerceptronSettings();
            Console.WriteLine("Loaded custom dataset");
        }


        private void preparePerceptronSettings()
        {
            datasetNumber = 0;

            weights = new double[inputCount];
            for (int i = 0; i < inputCount; i++)
            {
                weights[i] = randomNumbers();
            }
            bias = randomNumbers();

            if (!changeLearningRateFlag)
            {
                learningRate = 0.1;
            }
            output = 0;
            age = 0;

            pocketBias = 0;
            pocketAge = 0;
            pocketDatasetNumber = 0;

            if (!changeIterationCountFlag)
            {
                iterationCount = 10000;
            }

            goodDetection = 0;
            badDetection = 0;
        }

        public void SetLearningRate(double lr)
        {
            if (lr <= 0)
            {
                Console.WriteLine("Bad learning rate value!");
            }
            else
            {
                learningRate = lr;
                changeLearningRateFlag = true;
            }
        }

        public void SetIterationCount(int iteration)
        {
            if (iteration <= 0)
            {
                Console.WriteLine("Bad value iteration count!");
            }
            else
            {
                iterationCount = iteration;
                changeIterationCountFlag = true;
            }
        }

        public void ResetSettings()
        {
            changeLearningRateFlag = false;
            changeIterationCountFlag = false;
        }

        public void StartLearning()
        {
            List<int> listLearningData = new List<int>();

            for (int i = 0; i < iterationCount; i++)
            {
                for (int j = 0; j < input.GetLength(0); j++)
                {
                    listLearningData.Add(j);
                }
                while (listLearningData.Count != 0)
                {
                    randomLearningData(listLearningData, ref datasetNumber);
                    startLearning(datasetNumber, ref weights, ref bias, learningRate, ref age, ref pocketAge, ref pocketBias, ref output, ref pocketDatasetNumber);
                }
            }

            Console.WriteLine("Perceptron learning information:");
            Console.WriteLine("Bias: " + pocketBias + " with age: " + pocketAge);
            for (int i = 0; i < weights.Length; i++)
            {
                Console.WriteLine("Weight  " + i + ": " + weights[i]);
            }
            Console.WriteLine("For laset dataset number: " + pocketDatasetNumber);
            Console.WriteLine("Output " + output);
        }

        public void StartTesting()
        {
            List<int> listTestingData = new List<int>();

            readDataset(dataTestingFile);
            for (int j = 0; j < input.Length / (inputCount + 1); j++)
            {
                listTestingData.Add(j);
            }
            while (listTestingData.Count != 0)
            {
                randomLearningData(listTestingData, ref datasetNumber);
                startTesting(weights, datasetNumber, bias, ref goodDetection, ref badDetection);
            }
            Console.WriteLine();
            Console.WriteLine("Perceptron testing information:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Good recognized: " + goodDetection);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(", bad recognized: " + badDetection);
            Console.ResetColor();
            Console.WriteLine("Efficiency: " + ((double)goodDetection / (goodDetection + badDetection)) * 100 + "%");
            Console.WriteLine();
        }

        public void StartLearningAndTesting()
        {
            StartLearning();
            StartTesting();
        }

        private void readDataset(string filePath)
        {
            String tmp = null;
            var lineCount = 0;
            var columnCount = 0;
            int i = 0;
            int j = 0;

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    // Check how many lines have file
                    using (var reader = File.OpenText(filePath))
                    {
                        while (reader.ReadLine() != null)
                        {
                            lineCount++;
                        }
                    }

                    // Check how many columns have file
                    string file = new StreamReader(filePath).ReadLine();
                    string[] lines = file.Split("\t");
                    columnCount = lines.Length;
                    inputCount = columnCount - 1;
                    input = new Double[lineCount, columnCount];

                    String line = sr.ReadToEnd();
                    foreach (Char word in line)
                    {
                        if (word == '\t' || word == '\n')
                        {
                            input[i, j] = double.Parse(tmp);
                            tmp = null;
                            j++;

                            if (j == columnCount)
                            {
                                i++;
                                j = 0;
                            }
                        }
                        else
                        {
                            if (word == '.')
                            {
                                tmp += ',';
                            }
                            else
                            {
                                tmp += word;
                            }
                        }
                    }
                    // Load last element in the input table
                    input[i, j] = double.Parse(tmp);
                }
            }
            catch (IOException error)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(error.Message);
            }
        }

        private double randomNumbers()
        {
            Random rand = new Random();

            double lower = -0.1;
            double upper = 0.1;
            double result = rand.NextDouble() * (upper - lower) + lower;
            return result;
        }

        private void randomLearningData(List<int> datasetList, ref int datasetNumber)
        {
            if (datasetList.Count != 0)
            {
                Random rand = new Random();
                int tmp = datasetList[rand.Next(datasetList.Count)];
                datasetList.Remove(tmp);
                datasetNumber = tmp;
            }
            else
            {
                Console.WriteLine("List is empty!");
                return;
            }
        }

        private void startLearning(int datasetNumber, ref double[] weights, ref double bias, double learningRate, ref int age, ref int pocketAge, ref double pocketBias, ref double output, ref int pocketDatasetNumber)
        {
            if (sgn(scalarProduct(weights, datasetNumber) + bias) == input[datasetNumber, weights.Length])
            {
                age++;
                if (age > pocketAge)
                {
                    pocketAge = age;
                    pocketBias = bias;
                    pocketDatasetNumber = datasetNumber;
                    for (int i = 0; i < weights.Length; i++)
                    {
                        output = sgn(scalarProduct(weights, datasetNumber) + bias);
                    }
                }
            }
            else
            {
                age = 0;
                for (int i = 0; i < weights.Length; i++)
                {
                    weights[i] = weights[i] + learningRate * input[datasetNumber, weights.Length] * input[datasetNumber, i];
                }
                bias = bias + learningRate * input[datasetNumber, weights.Length];
            }
        }

        private void startTesting(double[] weights, int datasetNumber, double bias, ref int goodDetection, ref int badDetection)
        {
            if (sgn(scalarProduct(weights, datasetNumber) + bias) == input[datasetNumber, weights.Length])
            {
                goodDetection++;
            }
            else
            {
                badDetection++;
            }
        }

        private double scalarProduct(double[] weights, int datasetNumber)
        {
            double scalar = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                scalar += weights[i] * input[datasetNumber, i];
            }
            return scalar;
        }

        private double sgn(double x)
        {
            if (x < 0)
            {
                x = -1;
            }
            else if (x > 0)
            {
                x = 1;
            }
            else
            {
                x = 0;
            }
            return x;
        }

    }
}
