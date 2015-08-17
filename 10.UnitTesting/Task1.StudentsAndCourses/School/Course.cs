namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        public const int StudentsCapacity = 30;

        private ICollection<Student> students;
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Course name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public ICollection<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("The student cannot be null");
            }

            if (this.Students.Count + 1 > StudentsCapacity)
            {
                throw new ArgumentOutOfRangeException("The course is full.");
            }

            if (this.students.Contains(student))
            {
                throw new ArgumentException("This student has been already added to the course.");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("The student cannot be null.");
            }

            if (!this.students.Contains(student))
            {
                throw new ArgumentException("The student is not from this course.");
            }

            this.students.Remove(student);
        }
    }
}
