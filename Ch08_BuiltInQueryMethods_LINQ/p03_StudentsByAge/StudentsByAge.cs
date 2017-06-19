namespace p03_StudentsByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }


    public class StudentsByAge
    {
        public static void Main()
        {
            List<Student> students = new List<Student>();
            int lowBound = 18;
            int hiBound = 24;

            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                string[] input = inputLine.Split();
                students.Add(new Student(input[0], input[1], int.Parse(input[2])));

                inputLine = Console.ReadLine();
            }
            
            students
                .Where(s => s.Age >= lowBound && s.Age<= hiBound)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName} {s.Age}"));
        }
    }
}
