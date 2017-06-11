namespace p08_ExtractHyperlinks
{
    using System;
    using System.Text.RegularExpressions;
    using System.Text;

    public class ExtractHyperlinks
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            while (inputLine!="END")
            {
                sb.Append(inputLine);
                inputLine = Console.ReadLine();
            }

            string fullText = sb.ToString();

            string pattern = @"<a[\s\S]*?\s+href\s*={0,1}\s*([""'])?([\s\S]*?)(?:>|class|\1)[\s\S]*?<\/a>";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(fullText);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2].Value);
            }

        }
    }
}
