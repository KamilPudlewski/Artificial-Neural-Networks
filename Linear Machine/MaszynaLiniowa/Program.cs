using System;

namespace MaszynaLiniowa
{
    class Program
    {
        static void Main(string[] args)
        {
            MaszynaLiniowa ml = new MaszynaLiniowa();
            ml.SetIterationCount(100);
            ml.loadExampleDataset();
            ml.StartLearningAndTesting();

            Console.ReadKey();
        }
    }
}
