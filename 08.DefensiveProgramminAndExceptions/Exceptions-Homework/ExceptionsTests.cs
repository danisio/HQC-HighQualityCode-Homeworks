namespace ExceptionsHomework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExceptionsHomework
    {
        public static void Main()
        {
            var substr = Utilities.Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Utilities.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(string.Join(" ", subarr));

            var allarr = Utilities.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(string.Join(" ", allarr));

            var emptyarr = Utilities.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(string.Join(" ", emptyarr));

            Console.WriteLine(Utilities.ExtractEnding("I love C#", 2));
            Console.WriteLine(Utilities.ExtractEnding("Nakov", 4));
            Console.WriteLine(Utilities.ExtractEnding("beer", 4));
            Console.WriteLine(Utilities.ExtractEnding("Hi", 100));

            var number = 23;
            Console.WriteLine("The number {0} is prime --> {1}", number, Utilities.CheckPrime(number));

            var invalidNumber = 0;
            try
            {
                Console.WriteLine("The number {0} is prime --> {1}", invalidNumber, Utilities.CheckPrime(invalidNumber));
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine(invalidNumber + " is not prime. ");
            }

            var peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };

            Student peter = new Student("Peter", "Petrov", peterExams);
            var peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}