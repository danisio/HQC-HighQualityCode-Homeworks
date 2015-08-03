namespace AssertionsHomework
{
    using System;

    public class TestAlgorithms
    {
        public static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("Initial array = [{0}]", string.Join(", ", arr));
            SortingAlgorithms.SelectionSort(arr);
            Console.WriteLine("Sorted array = [{0}]", string.Join(", ", arr));

            // SortingAlgorithms.SelectionSort(new int[0]); // Test sorting empty array Assertation failed
            SortingAlgorithms.SelectionSort(new int[1]); // Test sorting single element array

            // Console.WriteLine(SearchingAlgorithms.BinarySearch(arr, -1000, -1, 8)); // Assertaion failed
            Console.WriteLine(SearchingAlgorithms.BinarySearch(arr, 17));
            Console.WriteLine(SearchingAlgorithms.BinarySearch(arr, 10));
            Console.WriteLine(SearchingAlgorithms.BinarySearch(arr, 1000));
            Console.WriteLine(SearchingAlgorithms.BinarySearch(arr, 0));
        }
    }
}