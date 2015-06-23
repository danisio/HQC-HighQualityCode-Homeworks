namespace Task_2
{
    public class Task2
    {
        public void MakePerson(int age)
        {
            Person test = new Person();
            test.Age = age;

            if (age % 2 == 0)
            {
                test.Name = "BigBoy";
                test.Gender = Gender.man;
            }
            else
            {
                test.Name = "@BigGirl@";
                test.Gender = Gender.woman;
            }
        }
    }
}
