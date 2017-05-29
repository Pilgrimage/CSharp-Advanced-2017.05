namespace p10_PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PopulationCounter
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, long>> statistica = new Dictionary<string, Dictionary<string, long>>();

            while (input != "report")
            {
                string[] parameters = input.Split('|');
                string city = parameters[0];
                string country = parameters[1];
                long cityPopulation = long.Parse(parameters[2]);

                if (statistica.ContainsKey(country))
                {
                    statistica[country].Add(city, cityPopulation);
                }
                else
                {
                    Dictionary<string, long> newCity = new Dictionary<string, long>();
                    newCity.Add(city, cityPopulation);
                    statistica.Add(country, newCity);
                }

                input = Console.ReadLine();
            }

            foreach (var cntry in statistica.OrderByDescending(x=>x.Value.Values.Sum()))
            {
                Console.WriteLine($"{cntry.Key} (total population: {cntry.Value.Values.Sum()})");

                foreach (var item in cntry.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"=>{item.Key}: {item.Value}");
                }
            }

        }
    }
}
