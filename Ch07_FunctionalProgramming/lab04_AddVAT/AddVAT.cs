namespace lab04_AddVAT
{
    using System;
    using System.Linq;

    public class AddVAT
    {
        public static void Main()
        {
            Console.ReadLine()
                .Trim()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => 1.2*(double.Parse(n)))
                .ToList()
                .ForEach(n => Console.WriteLine($"{n:f2}"));

        }
    }
}
