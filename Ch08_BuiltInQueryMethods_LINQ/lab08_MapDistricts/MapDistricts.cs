namespace lab08_MapDistricts
{
    using System;
    using System.Linq;

    public class MapDistricts
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            long bound = long.Parse(Console.ReadLine());

            input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(c =>
                  {
                    string[] tokens = c.Split(':');
                    string cityCode = tokens[0];
                    long cityPopulation = long.Parse(tokens[1]);
                    return new { cityCode,
                                 cityPopulation };        // new IEnumerable anonimous object
                  })
                .GroupBy(
                    c => c.cityCode,
                    c=> c.cityPopulation,
                    (city,population) => new {          // new  anonimous object with two properties, populations becomes List<>
                        CityCode = city,
                        Populations = population.ToList()
                    })
                .Where(x => x.Populations.Sum()>=bound)
                .OrderByDescending(x => x.Populations.Sum())
                .ToList()
                .ForEach(x => Console.WriteLine($@"{x.CityCode}: {string.Join(" ", x.Populations.OrderByDescending(p=>p).Take(5))}"));
        }
    }
}
