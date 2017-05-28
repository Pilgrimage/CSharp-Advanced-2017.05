namespace p03_PeriodicTable
{
    using System;
    using System.Collections.Generic;

    public class PeriodicTable
    {
        public static void Main()
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < numberOfRows; i++)
            {
                string[] rowWithElements = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                foreach (string element in rowWithElements)
                {
                    elements.Add(element);
                }
            }

            Console.WriteLine(String.Join(" ", elements));
        }
    }
}
