namespace p01_StudentsByGroup2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByGroup
    {
        public static void Main()
        {
            // Solution from video

            List<string[]> group = new List<string[]>();
            string targetGroup = "2";
            string inputLine = Console.ReadLine();

            while (inputLine!="END")
            {
                group.Add(inputLine.Split());

                inputLine = Console.ReadLine();
            }

            group
                .Where(arr => arr[2]== targetGroup)
                .OrderBy(arr => arr[0])
                .ToList()
                .ForEach(arr => Console.WriteLine($"{arr[0]} {arr[1]}"));
        }
    }
}
