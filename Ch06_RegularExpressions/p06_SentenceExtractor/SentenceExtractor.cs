namespace p06_SentenceExtractor
{
    using System;
    using System.Text.RegularExpressions;

    public class SentenceExtractor
    {
        public static void Main()
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            // Seems like it works (works in regex101), but not in judge
            //string pattern = $@"(?<=^|[\.!?] )(.*?(?:^|\W){word}(?:$|\W).*?)[\.!?]";

            string patternSentence = "(?<=^|[\\.!?] ).*?[\\.!?]";
            string patternWord = $@"(?:^|\W){word}(?:$|\W)";
            //string patternWord2 = $"\\W*((?i){word}(?-i))\\W*";

            Regex regex = new Regex(patternSentence);

            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                string sentence = match.Groups[0].Value;
                if (Regex.IsMatch(sentence, patternWord, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine(sentence);
                }
            }
        }
    }
}
