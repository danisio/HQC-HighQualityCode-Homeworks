namespace Methods.Array
{
    using System;

    public class ArrayMethods
    {
        public static int FindMaxElementInArray(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("The collection of elements cannot be null!");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("The collection of elements is empty!");
            }

            int maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (maxElement < elements[i])
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }
    }
}
