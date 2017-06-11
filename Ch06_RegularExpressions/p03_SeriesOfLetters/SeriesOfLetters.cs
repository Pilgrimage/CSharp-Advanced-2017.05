namespace p03_SeriesOfLetters
{
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;

    public class SeriesOfLetters
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            // Solution with RegEx
            string pattern = @"([A-Za-z])\1+";

            Regex regex = new Regex(pattern);
            Match match = regex.Match(text);

            while (match.Length!=0)
            {
                string old = match.Value;
                string replace = match.Groups[1].Value;
                text = Regex.Replace(text, old, replace);

                //match = regex.Match(text);
                match = match.NextMatch();
            }
            Console.WriteLine(text);


            //// Solution with Queue
            //Queue<char> sequence = new Queue<char>(text);
            //char lastChar = '1';

            //foreach (char ch in sequence)
            //{
            //    if (ch !=lastChar)
            //    {
            //        Console.Write(ch);
            //        lastChar = ch;
            //    }
            //}
            //Console.WriteLine();


            // Another solution from RAstardzhiev
            // var result = Regex.Replace(text, @"([A-Za-z])\1+", m => m.Groups[1].Value);  // Both variations work Identically
            // var result = Regex.Replace(text, @"([A-Za-z])\1+", "$1");                    // Both variations work Identically

        }
    }
}
