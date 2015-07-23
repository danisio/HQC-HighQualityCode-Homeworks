namespace Students
{
    using System;

    public class StudentTests
    {
        public static void Main(string[] args)
        {
            Student peter = new Student("Peter", "Ivanov", new DateTime(1892, 03, 17));

            Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 03));

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
