namespace AssertionsHomework
{
    using System;
    using System.Diagnostics;

    public class SortingAlgorithms
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null.");
            Debug.Assert(arr.Length > 0, "Array is empty.");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            Debug.Assert(x != null, "The swapping value X is null.");
            Debug.Assert(y != null, "The swapping value Y is null.");

            T oldX = x;
            x = y;
            y = oldX;
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null.");
            Debug.Assert(arr.Length > 0, "Array is empty.");
            Debug.Assert(0 <= startIndex && startIndex <= arr.Length - 1, "Start index is out of range.");
            Debug.Assert(0 <= endIndex && endIndex <= arr.Length - 1, "End index is out of range.");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }
    }
}
