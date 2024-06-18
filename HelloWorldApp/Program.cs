using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Program
    {
        private static List<Student> students = new List<Student>();

        public static void Main(string[] args)
        {
            string input;
            Console.WriteLine("Enter command (l, d [name], a [name] [age]): ");

            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                var command = input.Split(' ');

                switch (command[0])
                {
                    case "l":
                        ListStudents();
                        break;

                    case "d":
                        if (command.Length > 1)
                        {
                            string nameToDelete = string.Join(" ", command.Skip(1));
                            DeleteStudent(nameToDelete);
                        }
                        else
                        {
                            Console.WriteLine("Please provide a name to delete.");
                        }
                        break;

                    case "a":
                        if (command.Length > 2 && int.TryParse(command.Last(), out int age))
                        {
                            string name = string.Join(" ", command.Skip(1).Take(command.Length - 2));
                            AddStudent(name, age);
                        }
                        else
                        {
                            Console.WriteLine("Please provide a valid name and age to add.");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }

                Console.WriteLine("Enter command (l, d [name], a [name] [age]): ");
            }
        }

        static void ListStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
            }
            else
            {
                Console.WriteLine("Students:");
                foreach (var student in students)
                {
                    Console.WriteLine($"Name: {student.Name}, Age: {student.Age}");
                }
            }
        }

        static void DeleteStudent(string name)
        {
            var studentsToDelete = students.Where(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
            if (studentsToDelete.Count == 0)
            {
                Console.WriteLine($"No students found with name '{name}' to delete.");
            }
            else
            {
                foreach (var student in studentsToDelete)
                {
                    students.Remove(student);
                    Console.WriteLine($"Deleted student: Name = {student.Name}, Age = {student.Age}");
                }
            }
        }

        static void AddStudent(string name, int age)
        {
            students.Add(new Student(name, age));
            Console.WriteLine($"Added student: Name = {name}, Age = {age}");
        }
    }
}
