namespace p13_SrabskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class SrabskoUnleashed
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, int>> chalga = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            string pattern = @"(.*?) @(.*?) (\d+) (\d+)";

            while (input != "End")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string singer = match.Groups[1].ToString();
                    string venue = match.Groups[2].ToString();
                    int revenue = int.Parse(match.Groups[3].ToString()) * int.Parse(match.Groups[4].ToString());

                    if (chalga.ContainsKey(venue))
                    {
                        if (chalga[venue].ContainsKey(singer))
                        {
                            chalga[venue][singer] += revenue;
                        }
                        else
                        {
                            chalga[venue].Add(singer, revenue);
                        }
                    }
                    else
                    {
                        chalga.Add(venue, new Dictionary<string, int>());
                        chalga[venue].Add(singer, revenue);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var venue in chalga)
            {
                Console.WriteLine(venue.Key);

                Console.WriteLine(string.Join("\n", venue.Value
                    .OrderByDescending(x => x.Value)
                    .Select(s => $"#  {s.Key} -> {s.Value}")));
            }
        }
    }
}
