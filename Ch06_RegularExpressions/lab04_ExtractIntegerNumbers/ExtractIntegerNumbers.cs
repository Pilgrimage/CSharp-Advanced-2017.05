namespace lab04_ExtractIntegerNumbers
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractIntegerNumbers
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            //string pattern = @"(\d+)";
            string pattern = @"\d+";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            //for (int i = 0; i < matches.Count; i++)
            //{
            //    Console.WriteLine($"{matches[i]}");
            //}

            foreach (Match match in matches)
            {
                Console.WriteLine($"{match}");

            }
        }
    }
}
