namespace _3.CompareАdvancedMaths
{
    using System;
    using System.Diagnostics;

    public class Tests
    {
        private const float FloatNumber = 10000F;
        private const double DoubleNumber = 10000;
        private const decimal DecimalNumber = 10000M;
        private const int Limit = 1000000;

        public static void Main()
        {
            Console.WriteLine("Test SquareRoot");
            SquareRoot();
            Console.WriteLine("\nTest NaturalLogarithm");
            NaturalLogarithm();
            Console.WriteLine("\nTest Sinus");
            Sinus();
        }

        private static void SquareRoot()
        {
            Console.Write("FLOAT   -->");
            DisplayExecutionTime(() =>
            {
                float result = FloatNumber;
                for (int i = 1; i < Limit; i++)
                {
                    result = (float)Math.Sqrt(FloatNumber);
                }
            });

            Console.Write("DOUBLE  -->");
            DisplayExecutionTime(() =>
            {
                double result = DoubleNumber;
                for (int i = 1; i < Limit; i++)
                {
                    result = Math.Sqrt(DoubleNumber);
                }
            });

            Console.Write("DECIMAL -->");
            DisplayExecutionTime(() =>
            {
                decimal result = DecimalNumber;
                for (int i = 1; i < Limit; i++)
                {
                    result = (decimal)Math.Sqrt((double)DecimalNumber);
                }
            });
        }

        private static void NaturalLogarithm()
        {
            Console.Write("FLOAT   -->");
            DisplayExecutionTime(() =>
            {
                float result = FloatNumber;
                for (int i = 1; i < Limit; i++)
                {
                    result = (float)Math.Log(FloatNumber);
                }
            });

            Console.Write("DOUBLE  -->");
            DisplayExecutionTime(() =>
            {
                double result = DoubleNumber;
                for (int i = 1; i < Limit; i++)
                {
                    result = Math.Log(DoubleNumber);
                }
            });

            Console.Write("DECIMAL -->");
            DisplayExecutionTime(() =>
            {
                decimal result = DecimalNumber;
                for (int i = 1; i < Limit; i++)
                {
                    result = (decimal)Math.Log((double)DecimalNumber);
                }
            });
        }

        private static void Sinus()
        {
            Console.Write("FLOAT   -->");
            DisplayExecutionTime(() =>
            {
                float result = FloatNumber;
                for (int i = 1; i < Limit; i++)
                {
                    result = (float)Math.Sin(FloatNumber);
                }
            });

            Console.Write("DOUBLE  -->");
            DisplayExecutionTime(() =>
            {
                double result = DoubleNumber;
                for (int i = 1; i < Limit; i++)
                {
                    result = Math.Sin(DoubleNumber);
                }
            });

            Console.Write("DECIMAL -->");
            DisplayExecutionTime(() =>
            {
                decimal result = DecimalNumber;
                for (int i = 1; i < Limit; i++)
                {
                    result = (decimal)Math.Sin((double)DecimalNumber);
                }
            });
        }

        private static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
