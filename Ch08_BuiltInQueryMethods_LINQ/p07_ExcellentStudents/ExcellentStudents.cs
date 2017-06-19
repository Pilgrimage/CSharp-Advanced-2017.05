namespace p07_ExcellentStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExcellentStudents
    {
        public static void Main()
        {
            // Lazy solution

            List<string[]> students = new List<string[]>();
            string pattern = "6";

            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                students.Add(inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                inputLine = Console.ReadLine();
            }

            students
                .Where(arr => arr.Contains(pattern))
                .ToList()
                .ForEach(arr => Console.WriteLine($"{arr[0]} {arr[1]}"));
        }
    }
}
