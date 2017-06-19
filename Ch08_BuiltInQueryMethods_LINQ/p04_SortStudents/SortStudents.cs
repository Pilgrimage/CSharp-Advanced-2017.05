namespace p04_SortStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SortStudents
    {
        public static void Main()
        {
            List<string[]> names = new List<string[]>();

            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                names.Add(inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                inputLine = Console.ReadLine();
            }

            names
                .OrderBy(arr => arr[1])
                .ThenByDescending(arr => arr[0])
                .ToList()
                .ForEach(arr => Console.WriteLine($"{arr[0]} {arr[1]}"));
        }
    }
}
