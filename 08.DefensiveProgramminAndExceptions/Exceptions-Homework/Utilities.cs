namespace ExceptionsHomework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Utilities
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            List<T> result = new List<T>();

            if (startIndex < 0 || startIndex >= arr.Length)
            {
                throw new ArgumentOutOfRangeException("Start index is out of range." + startIndex);
            }

            if (startIndex + count > arr.Length)
            {
                throw new ArgumentOutOfRangeException("Start index + count is out of range.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("Count is out of range" + count);
            }

            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (count < 0)
            {
                throw new ArgumentException("Invalid count value.");
            }

            if (count > str.Length)
            {
                count = str.Length;
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static bool CheckPrime(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException("Number cannot be less or equal to zero.");
            }

            bool isPrime = true;

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            return isPrime;
        }
    }
}
