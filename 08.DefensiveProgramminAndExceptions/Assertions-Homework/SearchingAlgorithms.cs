namespace AssertionsHomework
{
    using System;
    using System.Diagnostics;

    public class SearchingAlgorithms
    {
        public static int BinarySearch<T>(T[] arr, T value)
            where T : IComparable<T>
        {
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        public static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null.");
            Debug.Assert(arr.Length > 0, "Array is empty.");
            Debug.Assert(value != null, "Searching value is null.");
            Debug.Assert(0 <= startIndex && startIndex <= arr.Length - 1, "Start index is out of range.");
            Debug.Assert(0 <= endIndex && endIndex <= arr.Length - 1, "End index is out of range.");
            Debug.Assert(startIndex <= endIndex, "Start index is greater than end index.");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }
    }
}
