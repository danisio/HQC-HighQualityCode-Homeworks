using System;
using System.Linq;

public class SumOfDifferences
{
    public static void Main()
    {
        long[] numbers = Console.ReadLine()
                         .Split(' ')
                         .Select(long.Parse)
                         .ToArray();

        long sum = 0;

        for (int i = 1; i < numbers.Length; i++)
        {
            long currentDiff = 0;

            if (numbers[i] > numbers[i - 1])
            {
                currentDiff = Math.Abs(numbers[i] - numbers[i - 1]);
                
                if (currentDiff % 2 == 0)
                {
                    i++;
                }
                else
                {
                    sum += currentDiff;
                }
            }
            else
            {
                currentDiff = Math.Abs(numbers[i - 1] - numbers[i]);

                if (currentDiff % 2 == 0)
                {
                    i++;
                }
                else
                {
                    sum += currentDiff;
                }
            }
        }

        Console.WriteLine(sum);
    }
}
