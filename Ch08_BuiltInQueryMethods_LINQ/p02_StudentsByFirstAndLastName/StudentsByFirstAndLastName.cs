namespace p02_StudentsByFirstAndLastName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByFirstAndLastName
    {
        public static void Main()
        {
            List<string[]> names = new List<string[]>();

            string inputLine = Console.ReadLine();

            while (inputLine!="END")
            {
                names.Add(inputLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries));
                inputLine = Console.ReadLine();
            }

            names
                .Where(arr => (arr[0].CompareTo(arr[1]))==-1)
                .ToList()
                .ForEach(arr => Console.WriteLine($"{arr[0]} {arr[1]}"));
        }
    }
}
