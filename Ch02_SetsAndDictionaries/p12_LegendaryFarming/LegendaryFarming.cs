namespace p12_LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LegendaryFarming
    {
        public static void Main()
        {
            Dictionary<string, int> legendMats = new Dictionary<string, int>();
            legendMats.Add("shards", 0);
            legendMats.Add("fragments", 0);
            legendMats.Add("motes", 0);
            SortedDictionary<string, int> junkMats = new SortedDictionary<string, int>();
            string nameOfLegend = "";

            while (nameOfLegend == "")
            {
                string[] materials = Console.ReadLine().ToLower().Split();

                int numberOfMats = materials.Length;
                string matName = "";
                int matQty = 0;

                for (int i = 0; i < numberOfMats - 1; i += 2)
                {
                    matQty = int.Parse(materials[i]);
                    matName = materials[i + 1];

                    switch (matName)
                    {
                        case "shards":
                            {
                                int newQty = legendMats[matName] + matQty;
                                if (newQty >= 250)
                                {
                                    nameOfLegend = "Shadowmourne";
                                    legendMats[matName] = newQty - 250;
                                }
                                else
                                {
                                    legendMats[matName] = newQty;
                                }
                                break;
                            }

                        case "fragments":
                            {
                                int newQty = legendMats[matName] + matQty;
                                if (newQty >= 250)
                                {
                                    nameOfLegend = "Valanyr";
                                    legendMats[matName] = newQty - 250;
                                }
                                else
                                {
                                    legendMats[matName] = newQty;
                                }
                                break;
                            }

                        case "motes":
                            {
                                int newQty = legendMats[matName] + matQty;
                                if (newQty >= 250)
                                {
                                    nameOfLegend = "Dragonwrath";
                                    legendMats[matName] = newQty - 250;
                                }
                                else
                                {
                                    legendMats[matName] = newQty;
                                }
                                break;
                            }

                        default:
                            if (junkMats.ContainsKey(matName))
                            {
                                junkMats[matName] += matQty;
                            }
                            else
                            {
                                junkMats.Add(matName, matQty);
                            }
                            break;
                    }
                    if (nameOfLegend!="")
                    {
                        break;
                    }
                }
            }

            Console.WriteLine($"{nameOfLegend} obtained!");

            Console.WriteLine(string.Join("\n", legendMats
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(s => $"{s.Key}: {s.Value}")));

            Console.WriteLine(string.Join("\n", junkMats.Select(s => $"{s.Key}: {s.Value}")));
        }
    }
}
