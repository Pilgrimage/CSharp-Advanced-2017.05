namespace p02_MatchPhoneNumber
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchPhoneNumber
    {
        public static void Main()
        {
            string pattern = @"(?<=^|\s)[\+]359( |-)2\1\d{3}\1\d{4}\b";

            Regex regex = new Regex(pattern);

            string inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                Match match = regex.Match(inputLine);
                if (match.Length != 0)
                {
                    Console.WriteLine(match.Value);
                }

                inputLine = Console.ReadLine();
            }
        }
    }
}
