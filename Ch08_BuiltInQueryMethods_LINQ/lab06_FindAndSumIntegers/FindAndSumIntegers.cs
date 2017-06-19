namespace lab06_FindAndSumIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindAndSumIntegers
    {

        public static void Main()
        {
            string input = Console.ReadLine().Trim();

            List<long> numbers = input
                .Split(' ')
                .Select(n =>
                {
                    long value;
                    bool success = long.TryParse(n, out value);
                    return new { value, success };      // create new anonime object - pair
                })
                .Where(b => b.success)
                .Select(x => x.value)       // Select only digital component
                .ToList();

            Console.WriteLine((numbers.Count > 0) ? numbers.Sum().ToString() : "No match");
        }
    }
}
