namespace lab02_SumNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SumNumbers
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            Console.WriteLine($"{input.Length}\n{input.Sum()}");


            //// Interesting Solution from Ivo Kalidus
            //Console.WriteLine(Console.ReadLine()
            //    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .Select((number, index) => new KeyValuePair<int, int>(index + 1, number))
            //    .Aggregate((a, b) => new KeyValuePair<int, int>(b.Key, a.Value + b.Value)).ToString()
            //    .Trim(new char[] { '[', ']' })
            //    .Replace(", ", "\n"));
        }
    }
}
