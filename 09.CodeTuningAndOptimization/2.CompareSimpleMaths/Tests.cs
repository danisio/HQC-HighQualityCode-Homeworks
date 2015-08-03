namespace _2.CompareSimple_Maths
{
    using System;
    using System.Diagnostics;

    public class Tests
    {
        private const int Limit = 1000000;

        public static void Main()
        {
            Console.WriteLine("Test ADD");
            TestAdd();
            Console.WriteLine("\nTest SUBSTRACT");
            TestSubstract();
            Console.WriteLine("\nTest INCREMENT");
            TestIncrement();
            Console.WriteLine("\nTest MULTIPLY");
            TestMultiply();
            Console.WriteLine("\nTest DIVIDE");
            TestDivide();
        }

        private static void TestAdd()
        {
            Console.Write("INTEGER -->");
            DisplayExecutionTime(() =>
            {
                int result = 1;
                for (int i = 1; i < Limit; i++)
                {
                    result += i;
                }
            });

            Console.Write("LONG    -->");
            DisplayExecutionTime(() =>
            {
                long result = 1L;
                for (int i = 1; i < Limit; i++)
                {
                    result += i;
                }
            });

            Console.Write("FLOAT   -->");
            DisplayExecutionTime(() =>
            {
                float result = 1.0f;
                for (int i = 1; i < Limit; i++)
                {
                    result += i;
                }
            });

            Console.Write("DOUBLE  -->");
            DisplayExecutionTime(() =>
            {
                double result = 1.0;
                for (int i = 1; i < Limit; i++)
                {
                    result += i;
                }
            });

            Console.Write("DECIMAL -->");
            DisplayExecutionTime(() =>
            {
                decimal result = 1.0m;
                for (int i = 1; i < Limit; i++)
                {
                    result += i;
                }
            });
        }

        private static void TestSubstract()
        {
            Console.Write("INTEGER -->");
            DisplayExecutionTime(() =>
            {
                int result = 1;
                for (int i = 1; i < Limit; i++)
                {
                    result -= i;
                }
            });

            Console.Write("LONG    -->");
            DisplayExecutionTime(() =>
            {
                long result = 1L;
                for (int i = 1; i < Limit; i++)
                {
                    result -= i;
                }
            });

            Console.Write("FLOAT   -->");
            DisplayExecutionTime(() =>
            {
                float result = 1.0f;
                for (int i = 1; i < Limit; i++)
                {
                    result -= i;
                }
            });

            Console.Write("DOUBLE  -->");
            DisplayExecutionTime(() =>
            {
                double result = 1.0;
                for (int i = 1; i < Limit; i++)
                {
                    result -= i;
                }
            });

            Console.Write("DECIMAL -->");
            DisplayExecutionTime(() =>
            {
                decimal result = 1.0m;
                for (int i = 1; i < Limit; i++)
                {
                    result -= i;
                }
            });
        }

        private static void TestIncrement()
        {
            Console.Write("INTEGER -->");
            DisplayExecutionTime(() =>
            {
                int result = 1;
                for (int i = 1; i < Limit; i++)
                {
                    result++;
                }
            });

            Console.Write("LONG    -->");
            DisplayExecutionTime(() =>
            {
                long result = 1L;
                for (int i = 1; i < Limit; i++)
                {
                    result++;
                }
            });

            Console.Write("FLOAT   -->");
            DisplayExecutionTime(() =>
            {
                float result = 1.0f;
                for (int i = 1; i < Limit; i++)
                {
                    result++;
                }
            });

            Console.Write("DOUBLE  -->");
            DisplayExecutionTime(() =>
            {
                double result = 1.0;
                for (int i = 1; i < Limit; i++)
                {
                    result++;
                }
            });

            Console.Write("DECIMAL -->");
            DisplayExecutionTime(() =>
            {
                decimal result = 1.0m;
                for (int i = 1; i < Limit; i++)
                {
                    result++;
                }
            });
        }

        private static void TestMultiply()
        {
            Console.Write("INTEGER -->");
            DisplayExecutionTime(() =>
            {
                int result = 1;
                for (int i = 1; i < Limit; i++)
                {
                    result *= i;
                }
            });

            Console.Write("LONG    -->");
            DisplayExecutionTime(() =>
            {
                long result = 1L;
                for (int i = 1; i < Limit; i++)
                {
                    result *= i;
                }
            });

            Console.Write("FLOAT   -->");
            DisplayExecutionTime(() =>
            {
                float result = 1.0f;
                for (int i = 1; i < Limit; i++)
                {
                    result *= i;
                }
            });

            Console.Write("DOUBLE  -->");
            DisplayExecutionTime(() =>
            {
                double result = 1.0;
                for (int i = 1; i < Limit; i++)
                {
                    result *= i;
                }
            });

            Console.Write("DECIMAL -->"); // overflow decimal type
            // DisplayExecutionTime(() =>
            // {
            //    decimal result = 1.0m;
            //    for (int i = 1; i < Limit; i++)
            //    {
            //        result *= i;
            //    }
            // });
        }

        private static void TestDivide()
        {
            Console.Write("INTEGER -->");
            DisplayExecutionTime(() =>
            {
                int result = 1;
                for (int i = 1; i < Limit; i++)
                {
                    result /= i;
                }
            });

            Console.Write("LONG    -->");
            DisplayExecutionTime(() =>
            {
                long result = 1L;
                for (int i = 1; i < Limit; i++)
                {
                    result /= i;
                }
            });

            Console.Write("FLOAT   -->");
            DisplayExecutionTime(() =>
            {
                float result = 1.0f;
                for (int i = 1; i < Limit; i++)
                {
                    result /= i;
                }
            });

            Console.Write("DOUBLE  -->");
            DisplayExecutionTime(() =>
            {
                double result = 1.0;
                for (int i = 1; i < Limit; i++)
                {
                    result /= i;
                }
            });

            Console.Write("DECIMAL -->");
            DisplayExecutionTime(() =>
            {
                decimal result = 1.0m;
                for (int i = 1; i < Limit; i++)
                {
                    result /= i;
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
