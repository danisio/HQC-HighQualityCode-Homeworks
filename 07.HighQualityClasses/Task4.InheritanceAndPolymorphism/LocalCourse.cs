namespace InheritanceAndPolymorphism
{
    using System;

    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string courseName, string teacherName, string lab)
            : base(courseName, teacherName)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Lab cannot be null or empty");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Lab = {0}", this.Lab) + " }";
        }
    }
}
