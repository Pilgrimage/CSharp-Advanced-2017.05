namespace p04_ReplaceAtag
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ReplaceAtag
    {
        public static void Main()
        {
            // Replace   <a href =…>…</ a> 
            // with      [URL href =…]…[/URL]. 
            // example :    <a href="http://softuni.bg">SoftUni</a>
            //              [URL href=http://softuni.bg]SoftUni[/URL]

            Queue<string> result = new Queue<string>();

            string inputLine = Console.ReadLine();

            string pattern = @"<a\s*?href\s*?=(.*?)>(.*?)<\/a>";
            string replace = @"[URL href=$1]$2[/URL]";

            while (inputLine != "end")
            {
                inputLine = Regex.Replace(inputLine, pattern, replace);
                result.Enqueue(inputLine);

                inputLine = Console.ReadLine();
            }

            Console.WriteLine(string.Join("\n", result));
        }
    }
}
