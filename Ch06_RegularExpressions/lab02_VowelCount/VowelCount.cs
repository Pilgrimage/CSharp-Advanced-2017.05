namespace lab02_VowelCount
{
    using System;
    using System.Text.RegularExpressions;

    public class VowelCount
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            string pattern = @"[aeiouyAEIOUY]";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            Console.WriteLine($"Vowels: {matches.Count}");
        }
    }
}
