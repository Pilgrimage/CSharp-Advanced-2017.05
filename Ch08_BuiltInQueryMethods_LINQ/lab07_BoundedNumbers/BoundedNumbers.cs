namespace lab07_BoundedNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BoundedNumbers
    {
        public static void Main()
        {
            List<int> bounds = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(n => bounds.Min() <= n && n <= bounds.Max())
                .ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
