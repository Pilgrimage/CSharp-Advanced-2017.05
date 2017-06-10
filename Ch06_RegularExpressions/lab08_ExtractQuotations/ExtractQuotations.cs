namespace lab08_ExtractQuotations
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractQuotations
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            string pattern = "(\"|')(.*?)\\1";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2].Value);
            }
        }
    }
}
