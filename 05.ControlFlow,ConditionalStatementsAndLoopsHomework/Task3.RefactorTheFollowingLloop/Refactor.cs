/*
 int i=0;
for (i = 0; i < 100;) 
{
   if (i % 10 == 0)
   {
    Console.WriteLine(array[i]);
    if ( array[i] == expectedValue ) 
    {
       i = 666;
    }
    i++;
   }
   else
   {
        Console.WriteLine(array[i]);
    i++;
   }
}
// More code here
if (i == 666)
{
    Console.WriteLine("Value Found");
}
 */

namespace Task3.RefactorTheFollowingLloop
{
    using System;

    public class Refactor
    {
        public static void Main()
        {
            const int ExpectedValue = 5;
            int[] array = new int[10];
            bool valueIsFound = false;
            Random randNum = new Random();

            // Put random numbers to the array only for testing
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randNum.Next(1, 10);
            }

            Console.WriteLine(string.Join(",", array));

            // Refactored loop
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
                if (i % 10 == 0)
                {
                    if (array[i] == ExpectedValue)
                    {
                        valueIsFound = true;
                    }
                }
            }

            if (valueIsFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
