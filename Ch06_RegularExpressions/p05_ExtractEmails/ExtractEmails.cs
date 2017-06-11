namespace p05_ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractEmails
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"(?<=\s)[a-zA-Z0-9]+[\w-\.]*@[a-zA-Z]+[a-zA-Z\.-]+\.[a-zA-Z\.-]+[a-zA-Z]";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
