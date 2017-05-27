namespace lab03_CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSameValuesInArray
    {
        public static void Main()
        {
            string inputSequence = Console.ReadLine().Replace(',', '.');

            double[] input = inputSequence.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            SortedSet<double> values = new SortedSet<double>(input);
            SortedDictionary<double, int> valueRating = new SortedDictionary<double, int>();

            foreach (var value in values)
            {
                valueRating.Add(value, 0);
            }

            foreach (var value in input)
            {
                valueRating[value] += 1;
            }

            foreach (var value in valueRating.Keys)
            {
                //string valueRenorm = value.ToString().Replace('.', ',');
                Console.WriteLine($"{value} - {valueRating[value]} times");
            }
        }
    }
}
