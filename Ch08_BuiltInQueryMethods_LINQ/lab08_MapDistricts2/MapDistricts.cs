namespace lab08_MapDistricts2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MapDistricts
    {
        public static void Main()
        {
            Dictionary<string,List<long>> towns = new Dictionary<string, List<long>>();

            string[] elements = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            foreach (string element in elements)
            {
                string[] info = element.Split(':');
                string town = info[0];
                long population = long.Parse(info[1]);

                if (!towns.ContainsKey(town))
                {
                    towns.Add(town, new List<long>());
                }
                towns[town].Add(population);
            }

            long bound = long.Parse(Console.ReadLine());

            towns = towns
                .Where(t => t.Value.Sum() > bound)
                .OrderByDescending(t => t.Value.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var town in towns)
            {
                var districts = town.Value.OrderByDescending(x => x).Take(5);
                Console.WriteLine(string.Format("{0}: {1}", town.Key, string.Join(" ", districts)));
            }
        }
    }
}
