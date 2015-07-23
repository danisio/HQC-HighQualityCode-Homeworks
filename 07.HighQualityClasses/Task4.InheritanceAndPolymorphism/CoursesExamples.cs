namespace InheritanceAndPolymorphism
{
    using System;

    public class CoursesExamples
    {
        public static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases", "Svetlin Nakov", "Enterprise");
            localCourse.AddStudents("Peter", "Maria");

            localCourse.AddStudents("Milena");
            localCourse.AddStudents("Todor");
            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse("PHP and WordPress Development", "Mario Peshev", "Sofia");
            offsiteCourse.AddStudents("Thomas", "Ani", "Steve");
            Console.WriteLine(offsiteCourse);
        }
    }
}
