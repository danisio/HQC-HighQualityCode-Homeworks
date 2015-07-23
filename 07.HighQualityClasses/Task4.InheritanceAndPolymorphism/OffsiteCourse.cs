namespace InheritanceAndPolymorphism
{
    using System;

    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string courseName, string teacherName, string town)
            : base(courseName, teacherName)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Town cannot be null or empty");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Town = {0}", this.Town) + " }";
        }
    }
}
