using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MaszynaLiniowa
{
    class MaszynaLiniowa
    {
        private double[,] input;
        private int inputCount;
        private int[] output;

        private string dataTreningFile;
        private string dataTestingFile;

        private int neuronNumber;
        private double[,] weights;
        private double bias;
        private int iterationCount = 100;

        public void StartLearningAndTesting()
        {
            readDataset(dataTreningFile);
            StartLearning();

            readDataset(dataTestingFile);
            StartTesting();
        }

        private void preparePerceptronSettings()
        {
            neuronNumberCout();

            // Weights to macierz 3x4 (3 perceptrony x 4 inputy)
            weights = new double[neuronNumber, input.GetLength(1)];

            for (int i = 0; i < neuronNumber; i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    weights[i, j] = randomNumber();
                }
            }

            bias = randomNumber();
        }

        public void StartLearning()
        {
            preparePerceptronSettings();

            int datasetNumber = 0;
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
                    startLearning(datasetNumber);
                }
            }
        }

        private void startLearning(int datasetNumber)
        {
            int maxElementNumber = maxIndexScalarProduct(datasetNumber);

            if (maxElementNumber+1 == output[datasetNumber])
            {
                //Console.WriteLine("Correct Learning Detection");    
            }
            else
            {
                for (int i = 0; i < weights.GetLength(1); i++)
                {
                    weights[maxElementNumber, i] = weights[maxElementNumber, i] - input[datasetNumber, i];
                }

                for (int i = 0; i < weights.GetLength(1); i++)
                {
                    weights[output[datasetNumber] - 1, i] = weights[output[datasetNumber] - 1, i] + input[datasetNumber, i];
                    
                }
            }
        }

        public void StartTesting()
        {
            int datasetNumber = 0;
            List<int> listTestingData = new List<int>();
            int goodDetection = 0;
            int badDetection = 0;

            readDataset(dataTestingFile);
            for (int i = 0; i < input.GetLength(0); i++)
            {
                listTestingData.Add(i);
            }
            while (listTestingData.Count != 0)
            {
                randomLearningData(listTestingData, ref datasetNumber);
                startTesting(datasetNumber, ref goodDetection, ref badDetection);
            }

            Console.WriteLine("Linear machine information:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Good recognized: " + goodDetection);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(", bad recognized: " + badDetection);
            Console.ResetColor();
            Console.WriteLine("Efficiency: " + ((double)goodDetection / (goodDetection + badDetection)) * 100 + "%");
            Console.WriteLine();
        }

        private void startTesting(int datasetNumber, ref int goodDetection, ref int badDetection)
        {
            int maxElementNumber = maxIndexScalarProduct(datasetNumber);
            maxElementNumber++;
            if (maxElementNumber ==  output[datasetNumber])
            {
                goodDetection++;
            }
            else
            {
                badDetection++;

                Console.WriteLine("Selected: " + maxElementNumber + " should be: " + output[datasetNumber]);
            }
        }

        public void loadExampleDataset()
        {
            dataTreningFile = "..\\..\\..\\..\\Iris\\iris.data_tr.txt";
            dataTestingFile = "..\\..\\..\\..\\Iris\\iris.data_te.txt";

            Console.WriteLine("Selected example dataset");
        }

        public void loadDatasetFiles(string loadDataTreningFile, string loadDataTestingFile)
        {
            dataTreningFile = loadDataTreningFile;
            dataTestingFile = loadDataTestingFile;

            Console.WriteLine("Selected custom dataset");
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
                    input = new Double[lineCount, inputCount];
                    output = new int[lineCount];

                    String line = sr.ReadToEnd();
                    foreach (Char word in line)
                    {
                        if (word == '\t' || word == '\n')
                        {
                            if (j < columnCount - 1)
                            {
                                input[i, j] = double.Parse(tmp);
                            }
                            else
                            {
                                output[i] = int.Parse(tmp);
                            }
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
                    output[i] = int.Parse(tmp);
                }
            }
            catch (IOException error)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(error.Message);
            }
        }

        private void neuronNumberCout()
        {
            List<double> neuronValueList = new List<double>();

            for (int i = 0; i < output.GetLength(0); i++)
            {
                double tmpValue = output[i];

                double czyIstnieje = neuronValueList.Find(item => item == tmpValue);
                if (czyIstnieje == 0)
                {
                    neuronValueList.Add(tmpValue);
                } 
            }
            neuronNumber = neuronValueList.Count;
        }

        private int maxIndexScalarProduct(int datasetNumber)
        {
            double[] scalar = new double[weights.GetLength(0)];

            // ScalarProduct to jest (1input x 1percepron + 1input x 2percepron + 1input x 3percepron + 1input x 4percepron) + bias i tak dla reszty perceptronow

            for (int i = 0; i < neuronNumber; i++)
            {
                for (int j = 0; j < weights.GetLength(1); j++)
                {
                    scalar[i] += (weights[i, j] * input[datasetNumber, j]);
                }
                scalar[i] += bias;
            }

            return maxIndex(scalar);
        }

        private int maxIndex(double[] scalar)
        {
            int maxIndex = 0;
            double max = scalar[0];

            for (int i = 1; i < scalar.Length; i++)
            {
                if (max < scalar[i])
                {
                    maxIndex = i;
                    max = scalar[i];
                }
            }

            return maxIndex;
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

        private double randomNumber()
        {
            Random rand = new Random();

            double lower = -0.1;
            double upper = 0.1;
            double result = rand.NextDouble() * (upper - lower) + lower;
            return result;
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
            }
        }
    }
}
