namespace p08_WeakStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> Marks { get; set; }

        public Student(string firstName, string lastName, List<int> marks)
        {
            FirstName = firstName;
            LastName = lastName;
            this.Marks = new List<int>(marks);
        }
    }


    public class WeakStudents
    {
        public static void Main()
        {
            List<Student> students = new List<Student>();
            int pattern = 3;

            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                string[] input = inputLine.Split();

                List<int> marks = input.Where((s, index) => index > 1).Select(int.Parse).ToList();

                students.Add(new Student(input[0], input[1], marks));

                inputLine = Console.ReadLine();
            }


            students
                //.Where(stud => stud.Marks.Where(m => m <= pattern).Count() > 1)
                .Where(stud => stud.Marks.Count(m => m <= pattern) > 1)
                .ToList()
                .ForEach(stud => Console.WriteLine($"{stud.FirstName} {stud.LastName}"));


            // Solution from video
            //var group = new List<string[]>();
            //var inputLine = Console.ReadLine();

            //while (inputLine != "END")
            //{
            //    group.Add(inputLine.Split(' '));
            //    inputLine = Console.ReadLine();
            //}

            //group
            //    .Where(arr => arr.Skip(2).Count(mark => int.Parse(mark) <= 3) >= 2)
            //    .ToList()
            //    .ForEach(arr => Console.WriteLine($"{arr[0]} {arr[1]}"));
        }
    }
}
