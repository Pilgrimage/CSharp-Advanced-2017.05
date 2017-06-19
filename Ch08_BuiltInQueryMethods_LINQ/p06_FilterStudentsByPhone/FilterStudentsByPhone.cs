namespace p06_FilterStudentsByPhone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterStudentsByPhone
    {
        public static void Main()
        {
            List<string[]> students = new List<string[]>();
            string pattern1 = "02";
            string pattern2 = "+3592";

            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                students.Add(inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                inputLine = Console.ReadLine();
            }

            //students
            //    .Where(arr => arr[2].StartsWith(pattern1) ||
            //                  arr[2].StartsWith(pattern2))
            //    .ToList()
            //    .ForEach(arr => Console.WriteLine($"{arr[0]} {arr[1]}"));

            students
                .Where(arr => arr[2].StartsWith(pattern1) || arr[2].StartsWith(pattern2))
                .Select(arr => $"{arr[0]} {arr[1]}")
                .ToList()
                .ForEach(x => Console.WriteLine(x));

        }
    }
}
