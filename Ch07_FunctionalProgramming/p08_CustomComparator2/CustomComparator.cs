namespace p08_CustomComparator2
{
    using System;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class CustomComparator
    {
        public static void Main()
        {
            // Another solution - not from me

            int[] numbers = Regex.Split(Console.ReadLine().Trim(), "\\s+").Select(int.Parse).ToArray();

            Array.Sort(numbers, Comparison);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static int Comparison(int x, int y)
        {
            int first = Math.Abs(x) % 2;
            int second = Math.Abs(y) % 2;

            // Compare if both numbers odd or even 
            // If not - enter, if yes - skip
            if (first != second)
            {
                // even numbers first, because residue 0 is less then residue 1
                return first.CompareTo(second);
            }

            return x.CompareTo(y);
        }
    }
}
