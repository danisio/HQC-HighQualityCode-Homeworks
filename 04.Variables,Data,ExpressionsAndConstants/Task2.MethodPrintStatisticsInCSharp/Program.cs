using System;

public class Statistics
{
    public static void PrintStatistics(double[] arr, int count)
    {
        double max = double.MinValue;
        for (int i = 0; i < count; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        Console.WriteLine("The MAX value is: " + max);

        double min = double.MaxValue;
        for (int i = 0; i < count; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }

        Console.WriteLine("The MIN value is: " + min);

        double sum = 0;
        for (int i = 0; i < count; i++)
        {
            sum += arr[i];
        }

        Console.WriteLine("The AVERAGE value is: " + (sum / count));
    }
}
