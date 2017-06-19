namespace lab01_TakeTwo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TakeTwo
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(n => n >= 10 && n <= 20)
                .Distinct()
                .Take(2)
                .ToList();

            Console.WriteLine(string.Join(" ", numbers));


            //// Another solution - in one line, but not so pure
            //Console.ReadLine()
            //    .Split()
            //    .Select(int.Parse)
            //    .Where(n => n >= 10 && n <= 20)
            //    .Distinct()
            //    .Take(2)
            //    .ToList()
            //    .ForEach(n => Console.Write(n + " "));
        }
    }
}
