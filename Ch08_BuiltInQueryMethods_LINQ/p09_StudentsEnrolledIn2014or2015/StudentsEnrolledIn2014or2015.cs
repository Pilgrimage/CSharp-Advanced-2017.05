namespace p09_StudentsEnrolledIn2014or2015
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsEnrolledIn2014or2015
    {
        public static void Main()
        {
            List<string[]> marksPlus = new List<string[]>();
            string pattern1 = "14";
            string pattern2 = "15";

            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                marksPlus.Add(inputLine.Split());

                inputLine = Console.ReadLine();
            }

            marksPlus
                .Where(arr => arr[0].EndsWith(pattern1) || arr[0].EndsWith(pattern2))
                .Select(arr => arr.Skip(1))
                .ToList()
                .ForEach(x => Console.WriteLine(string.Join(" ", x)));

        }
    }
}
