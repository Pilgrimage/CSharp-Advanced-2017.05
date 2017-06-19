namespace p01_StudentsByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Group { get; set; }

        public Student(string firstName, string lastName, int group)
        {
            FirstName = firstName;
            LastName = lastName;
            Group = group;
        }
    }

    public class StudentsByGroup
    {
        public static void Main()
        {
            List<Student> students = new List<Student>();
            int targetGroup = 2;

            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                string[] input = inputLine.Split();
                students.Add(new Student(input[0], input[1], int.Parse(input[2])));

                inputLine = Console.ReadLine();
            }

            students.Where(g => g.Group == targetGroup)
                    .OrderBy(s => s.FirstName)
                    .ToList()
                    .ForEach(n => Console.WriteLine($"{n.FirstName} {n.LastName}"));
        }
    }
}
