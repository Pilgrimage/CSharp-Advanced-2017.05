namespace p04_AshesOfRoses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class AshesOfRoses
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, long>> regions = new Dictionary<string, Dictionary<string, long>>();

            //string pattern = @"\bGrow.*?<([A-Z][a-z]*)>.*?<([A-Za-z0-9]+)>.*?(\d+)";      // 90/100 test 10 and zero test 2
            //string pattern = @"\bGrow[\s]<([A-Z][a-z]*)>[\s]<([A-Za-z0-9]+)>[\s](\d+)";   // 90/100 test 10
            //string pattern = @"\bGrow <([A-Z][a-z]+)> <([A-Za-z0-9]+)> (\d+)$";           // 90/100 test 10
            //string pattern = @"^Grow\s*<([A-Z][a-z]*)>\s<([a-zA-Z0-9]*)>\s([0-9]+)$";       // work !!!
            string pattern = @"^Grow[\s]<([A-Z][a-z]*)>[\s]<([A-Za-z0-9]*)>[\s](\d+)$";   // work !!! - first ^ and last $


            Regex regex = new Regex(pattern);
            string input;


            while ((input = Console.ReadLine()) != "Icarus, Ignite!")
            {
                Match match = regex.Match(input);

                if (match.Groups.Count < 4)
                {
                    continue;
                }

                string name = match.Groups[1].Value;
                string color = match.Groups[2].Value;
                long qty = long.Parse(match.Groups[3].Value);

                if (!regions.ContainsKey(name))
                {
                    regions.Add(name, new Dictionary<string, long>() { { color, qty } });
                }
                else if (!regions[name].ContainsKey(color))
                {
                    regions[name].Add(color, qty);
                }
                else
                {
                    regions[name][color] += qty;
                }
            }


            foreach (var kvp in regions.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(n => n.Key))
            {
                Console.WriteLine(kvp.Key);

                foreach (var item in kvp.Value.OrderBy(x => x.Value).ThenBy(n => n.Key))
                {
                    Console.WriteLine($"*--{item.Key} | {item.Value}");
                }
            }

        }
    }
}
