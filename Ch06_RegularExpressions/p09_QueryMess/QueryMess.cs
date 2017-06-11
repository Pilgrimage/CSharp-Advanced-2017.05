namespace p09_QueryMess
{
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;

    public class QueryMess
    {
        public static void Main()
        {
            Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();

            string pattern = @"([^&=?]*)=([^&=]*)";     // for pairs
            string patternSpaces = @"((%20|\+)+)";

            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                Regex regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(inputLine);
                
                for (int i = 0; i < matches.Count; i++)
                {
                    string field = matches[i].Groups[1].Value;
                    field = Regex.Replace(field, patternSpaces, ch => " ").Trim();
                    //field = string.Join(" ", field.Split(new string[] {"%20", "+"}, StringSplitOptions.RemoveEmptyEntries));

                    string value = matches[i].Groups[2].Value;
                    value = Regex.Replace(value, patternSpaces, ch => " ").Trim();

                    if (!results.ContainsKey(field))
                    {
                        List<string> values = new List<string>();
                        values.Add(value);

                        results.Add(field, values);
                    }
                    else if (results.ContainsKey(field))
                    {
                        results[field].Add(value);
                    }
                }

                foreach (var kvp in results)
                {
                    Console.Write("{0}=[{1}]", kvp.Key, string.Join(", ", kvp.Value));
                }

                Console.WriteLine();

                results.Clear();

                inputLine = Console.ReadLine();
            }

        }
    }
}
