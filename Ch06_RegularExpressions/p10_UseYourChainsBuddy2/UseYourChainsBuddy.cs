namespace p10_UseYourChainsBuddy2
{
    using System;
    using System.Text.RegularExpressions;

    public class UseYourChainsBuddy
    {
        public static void Main()
        {
            string inputText = Console.ReadLine();

            string patternTags = @"<p>(.*?)<\/p>";
            string patternText = @"[^a-z0-9]+";
            string preResult = "";

            MatchCollection inputTags = Regex.Matches(inputText, patternTags);

            foreach (Match inputTag in inputTags)
            {
                string tagContent = Regex.Replace(inputTag.Groups[1].Value, patternText, " ");
                preResult += tagContent;
            }
            
            char[] text = preResult.ToCharArray();
            int len = text.Length;

            for (int i = 0; i < len; i++)
            {
                if (text[i] >= 'a' && text[i] <= 'm')
                {
                    text[i] = (char)(text[i] + 13);
                }
                else if (text[i] >= 'n' && text[i] <= 'z')
                {
                    text[i] = (char)(text[i] - 13);
                }
            }

            Console.WriteLine(string.Join("", text));
        }
    }
}
