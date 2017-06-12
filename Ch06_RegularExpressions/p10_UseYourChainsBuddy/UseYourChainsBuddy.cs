namespace p10_UseYourChainsBuddy
{
    using System;
    using System.Text.RegularExpressions;
    using System.Linq;
    using System.Text;

    public class UseYourChainsBuddy
    {
        public static void Main()
        {
            char[] acceptable = "abcdefghijklmnopqrstuvwxyz1234567890".ToCharArray();
            string inputText = Console.ReadLine();

            string patternTags = @"<p>(.*?)<\/p>";
            string result = "";

            MatchCollection inputTags = Regex.Matches(inputText, patternTags);

            foreach (Match inputTag in inputTags)
            {
                char[] tagText = inputTag.Groups[1].Value.ToCharArray();

                for (int i = 0; i < tagText.Length; i++)
                {
                    if (!acceptable.Contains(tagText[i]))
                    {
                        tagText[i] = ' ';
                    }
                    else if (tagText[i] >= 'a' && tagText[i] <= 'z')
                    {

                        if (tagText[i] <= 'm')
                        {
                            tagText[i] = (char)(tagText[i] + 13);
                        }
                        else
                        {
                            tagText[i] = (char)(tagText[i] - 13);
                        }
                    }

                }
                result += String.Join("", tagText);
            }

            result = Regex.Replace(result, "[ ]{2,}", " ");
            Console.WriteLine(result);
        }
    }
}
