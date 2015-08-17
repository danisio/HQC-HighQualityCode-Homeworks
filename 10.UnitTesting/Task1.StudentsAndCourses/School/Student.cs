namespace School
{
    using System;

    public class Student
    {
        private const int MinUniqueNumber = 10000;
        private const int MaxUniqueNumber = 99999;

        private string name;
        private int uniqueNumber;

        public Student(string name, int uniqueNumber)
        {
            this.Name = name;
            this.UniqueNumber = uniqueNumber;
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
                    throw new ArgumentNullException("Student name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }

            set
            {
                if (value < MinUniqueNumber || value > MaxUniqueNumber)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Student number has to be in range [{0}-{1}]", MinUniqueNumber, MaxUniqueNumber));
                }

                this.uniqueNumber = value;
            }
        }
    }
}
