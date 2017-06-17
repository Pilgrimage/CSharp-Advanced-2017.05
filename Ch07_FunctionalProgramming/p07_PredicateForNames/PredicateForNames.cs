namespace p07_PredicateForNames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredicateForNames
    {
        public static void Main()
        {
            int lenLimit = int.Parse(Console.ReadLine());
            List<string> words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Predicate<string> isLonger = w => w.Length > lenLimit;

            words = Filter(words, isLonger);

            Console.WriteLine(string.Join("\n", words));
        }

        private static List<string> Filter(List<string> words, Predicate<string> isLonger)
        {
            List<string> result = new List<string>(words);
            foreach (string word in words)
            {
                if (isLonger(word))
                {
                    result.Remove(word);
                }
            }
            return result;
        }
    }
}
