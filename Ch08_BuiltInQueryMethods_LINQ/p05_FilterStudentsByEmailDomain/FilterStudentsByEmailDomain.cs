namespace p05_FilterStudentsByEmailDomain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterStudentsByEmailDomain
    {
        public static void Main()
        {
            List<string[]> students = new List<string[]>();
            string pattern = "@gmail.com";

            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                students.Add(inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                inputLine = Console.ReadLine();
            }

            students
                .Where(arr => arr[2].EndsWith(pattern))
                .ToList()
                .ForEach(arr => Console.WriteLine($"{arr[0]} {arr[1]}"));
        }
    }
}
