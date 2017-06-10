namespace lab05_ExtractTags
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractTags
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();
            string fullText = "";

            while (inputLine!="END")
            {
                fullText += inputLine;
                inputLine = Console.ReadLine();
            }

            string pattern = @"<.*?>";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(fullText);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }

        }
    }
}
