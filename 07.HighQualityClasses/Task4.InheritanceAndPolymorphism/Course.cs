namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private string name;
        private string teacherName;
        private IList<string> students;

        public Course(string courseName, string teacherName)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.students = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.ValidateName(value, "Course");

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                this.ValidateName(value, "Teacher");

                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return new List<string>(this.students);
            }
        }

        public void AddStudents(params string[] newStudents)
        {
            foreach (var student in newStudents)
            {
                this.ValidateName(student, "Student");

                this.students.Add(student);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0} {{ Name = {1}; ", this.GetType().Name, this.Name);

            if (this.TeacherName != null)
            {
                result.AppendFormat("Teacher = {0}; ", this.TeacherName);
            }

            result.AppendFormat("Students = {0}; ", this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        private void ValidateName(string name, string type)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(type + " name cannot be null or empty");
            }
        }
    }
}
