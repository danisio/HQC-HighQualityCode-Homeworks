namespace School
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private ICollection<Course> courses;
        private string name;

        public School(string name)
        {
            this.Name = name;
            this.courses = new List<Course>();
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
                    throw new ArgumentNullException("School name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public ICollection<Course> Courses
        {
            get
            {
                return new List<Course>(this.courses);
            }
        }

        public void AddNewCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("The course cannot be null");
            }

            if (this.courses.Contains(course))
            {
                throw new ArgumentException("This course has been already added to the school.");
            }

            this.courses.Add(course);
        }
    }
}
