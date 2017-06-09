namespace p16_ExtractHyperlinks
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractHyperlinks
    {
        public static void Main()
        {
            // with thanks to martinski74

            string inputLine = Console.ReadLine();
            string text = "";

            string pattern = @"<a.*?(?<!"">)href\s*?=\s*?([""'])?(\S.*?)(?:>|class|\1)";
            
            while (inputLine != "END")
            {
                text +=inputLine;
                inputLine = Console.ReadLine();
            }

            
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);


            string fix;
            
            foreach (Match item in matches)
            {
                fix = item.Groups[2].ToString();
                fix = Regex.Replace(fix, @"\s{2,}", " ");

                Console.WriteLine(fix);
            }



        }
    }
}
