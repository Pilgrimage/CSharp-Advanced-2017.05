namespace p02_SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetsOfElements
    {
        public static void Main()
        {
            int[] lengths = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < lengths[0]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }

            for (int i = 0; i < lengths[1]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }

            // Moifaing firstSet to be Intersect Set
            firstSet.IntersectWith(secondSet);

            Console.WriteLine(String.Join(" ", firstSet));
        }
    }
}
