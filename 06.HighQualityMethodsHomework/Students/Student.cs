namespace Students
{
    using System;

    public class Student
    {
        private string firstname;
        private string lastname;
        private DateTime dateBirth;

        public Student(string firstname, string lastname, DateTime dateBirth)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.DateBirth = dateBirth;
        }

        public string FirstName
        {
            get
            {
                return this.firstname;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name cannot be null or empty!");
                }

                this.firstname = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastname;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last name cannot be null or empty!");
                }

                this.lastname = value;
            }
        }

        public DateTime DateBirth
        {
            get
            {
                return this.dateBirth;
            }

            set
            {
                DateTime startDate = new DateTime(1900, 1, 1);
                DateTime endDate = DateTime.Now;

                if (value <= startDate || value >= endDate)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("Date of birth must be in the range {0}-{1}",
                        startDate.ToShortDateString(),
                        endDate.ToShortDateString()));
                }

                this.dateBirth = value;
            }
        }

        public bool IsOlderThan(Student student)
        {
            return this.DateBirth.CompareTo(student.DateBirth) < 0;
        }
    }
}