namespace SchoolTests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void SchoolCreate_ShoudNotThrow_WhenNameIsValid()
        {
            var school = new School("Telerik Academy");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolCreate_ShouldThrow_WhenNameIsNull()
        {
            var school = new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolCreate_ShouldThrow_WhenNameIsEmpty()
        {
            var school = new School(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolCreate_ShouldThrow_WhenNameIsWhiteSpace()
        {
            var school = new School("   ");
        }

        [TestMethod]
        public void School_ShouldReturnNameCorrectly()
        {
            var school = new School("Telerik Academy");
            
            Assert.AreEqual("Telerik Academy", school.Name);
        }

        [TestMethod]
        public void SchoolAddNewCourse_ShouldWorkProperly_WhenNameIsValid()
        {
            var school = new School("Telerik Academy");
            var course = new Course("HQC");
            
            school.AddNewCourse(course);
            
            Assert.AreSame(course, school.Courses.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolAddNewCourse_ShouldThrow_WhenCourseIsNull()
        {
            var school = new School("Telerik Academy");
            
            school.AddNewCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolAddNewCourse_ShouldThrow_WhenCourseIsAddedTwice()
        {
            var school = new School("Telerik Academy");
            var course = new Course("HQC");
            
            school.AddNewCourse(course);
            school.AddNewCourse(course);
        }

        [TestMethod]
        public void StudentCreate_ShouldNotThrow_WhenStudentIsValid()
        {
            var student = new Student("Ivan Ivanov", 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentCreate_ShouldThrow_WhenNameIsNull()
        {
            var student = new Student(null, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentCreate_ShouldThrow_WhenNameIsEmpty()
        {
            var student = new Student(string.Empty, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentCreate_ShouldThrow_WhenNameIsWhiteSpace()
        {
            var student = new Student("   ", 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentCreate_ShouldThrow_WhenUniqueNumberIsLowerThanMin()
        {
            var student = new Student("Ivan Ivanov", 9999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentCreate_ShouldThrow_WhenUniqueNumberIsHigherThanMax()
        {
            var student = new Student("Ivan Ivanov", 100000);
        }

        [TestMethod]
        public void Student_ShouldReturnNameCorrectly()
        {
            var student = new Student("Ivan Ivanov", 10000);

            Assert.AreEqual("Ivan Ivanov", student.Name);
        }

        [TestMethod]
        public void Student_ShouldReturnUniqueNumberCorrectly()
        {
            var student = new Student("Ivan Ivanov", 10000);

            Assert.AreEqual(10000, student.UniqueNumber);
        }

        [TestMethod]
        public void CourseCreate_ShouldNotThrow_WhenNameIsValid()
        {
            var course = new Course("HQC");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseCreate_ShouldThrow_WhenNameIsNull()
        {
            var course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseCreate_ShouldThrow_WhenNameIsEmpty()
        {
            var course = new Course(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseCreate_ShouldThrow_WhenNameIsWhiteSpace()
        {
            var course = new Course("   ");
        }

        [TestMethod]
        public void Course_ShouldReturnNameCorrectly()
        {
            var course = new Course("HQC");
            
            Assert.AreEqual("HQC", course.Name);
        }

        [TestMethod]
        public void CourseAddStudent_ShouldWorkProperly_WnenStudentIsValid()
        {
            var course = new Course("HQC");
            var student = new Student("Ivan Ivanov", 10000);
            
            course.AddStudent(student);
            
            Assert.AreSame(student, course.Students.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseAddStudent_ShouldThrow_WhenStudentIsNull()
        {
            var course = new Course("HQC");
            
            course.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CourseAddStudent_ShouldThrow_WhenCourseIsFull()
        {
            var course = new Course("HQC");

            for (int i = 1; i <= 31; i++)
            {
                course.AddStudent(new Student(i.ToString(), 10000 + 1));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseAddStudent_ShouldThrow_WhenStudentIsAddedTwice()
        {
            var course = new Course("HQC");
            var student = new Student("Ivan Ivanov", 10000);

            course.AddStudent(student);
            course.AddStudent(student);
        }

        [TestMethod]
        public void CourseRemoveStudent_ShouldWorkProperly_WhenStudentIsValid()
        {
            var course = new Course("HQC");
            var student = new Student("Ivan Ivanov", 10000);

            course.AddStudent(student);
            course.RemoveStudent(student);

            Assert.AreEqual(0, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseRemoveStudent_ShouldThrow_WhenStudentIsNull()
        {
            var course = new Course("HQC");
            
            course.RemoveStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseRemoveStudent_ShouldThrowWhenNoSuchStudent()
        {
            var course = new Course("HQC");
            var student = new Student("Ivan Ivanov", 10000);

            course.RemoveStudent(student);
        }
    }
}
