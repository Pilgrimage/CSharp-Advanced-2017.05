namespace lab04_AverageOfDoubles
{
    using System;
    using System.Linq;

    public class AverageOfDoubles
    {
        public static void Main()
        {
            double average = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .Average();

            Console.WriteLine($"{average:f2}");
        }
    }
}
