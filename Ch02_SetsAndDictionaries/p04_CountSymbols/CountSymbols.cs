namespace p04_CountSymbols
{
    using System;
    using System.Collections.Generic;

    public class CountSymbols
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            SortedSet<char> chars = new SortedSet<char>(input);
            SortedDictionary<char,int> charFrequency = new SortedDictionary<char, int>();

            foreach (var ch in chars)
            {
                charFrequency.Add(ch,0);
            }

            foreach (char ch in input)
            {
                charFrequency[ch] += 1;
            }

            foreach (var chFr in charFrequency)
            {
                Console.WriteLine($"{chFr.Key}: {chFr.Value} time/s");
            }

        }
    }
}
