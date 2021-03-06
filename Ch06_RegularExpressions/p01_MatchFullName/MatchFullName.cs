﻿namespace p01_MatchFullName
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchFullName
    {
        public static void Main()
        {
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b"; ;

            Regex regex = new Regex(pattern);

            string inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                Match match = regex.Match(inputLine);
                if (match.Length!=0)
                {
                Console.WriteLine(match.Value);
                }

                inputLine = Console.ReadLine();
            }
        }
    }
}
