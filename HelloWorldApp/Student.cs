namespace ConsoleApp1
{
    public class Student
    {
        // Properties
        public string Name { get; private set; }
        public int Age { get; private set; }

        // Constructor
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
