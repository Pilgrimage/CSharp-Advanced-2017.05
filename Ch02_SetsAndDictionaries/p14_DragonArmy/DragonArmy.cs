namespace p14_DragonArmy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DragonArmy
    {
        public static void Main()
        {
            Dictionary<string, SortedDictionary<string, int[]>> allDragons = new Dictionary<string, SortedDictionary<string, int[]>>();

            int numLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numLines; i++)
            {
                string[] drgParams = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                string drgType = drgParams[0];
                string drgName = drgParams[1];
                int drgDamage = int.Parse(drgParams[2] == "null" ? "45" : drgParams[2]);
                int drgHealth = int.Parse(drgParams[3] == "null" ? "250" : drgParams[3]);
                int drgArmor = int.Parse(drgParams[4] == "null" ? "10" : drgParams[4]);

                if (allDragons.ContainsKey(drgType))
                {
                    if (allDragons[drgType].ContainsKey(drgName))
                    {
                        allDragons[drgType][drgName][0] = drgDamage;
                        allDragons[drgType][drgName][1] = drgHealth;
                        allDragons[drgType][drgName][2] = drgArmor;
                    }
                    else
                    {
                        int[] newStats = new int[] { drgDamage, drgHealth, drgArmor };
                        allDragons[drgType].Add(drgName, newStats);
                    }
                }
                else
                {
                    allDragons.Add(drgType,new SortedDictionary<string, int[]>());
                    int[] newStats = new int[] { drgDamage, drgHealth, drgArmor };
                    allDragons[drgType].Add(drgName, newStats);
                }
            }

            foreach (var dtype in allDragons)
            {
                double damAvg = dtype.Value.Values.Select(x => x[0]).Average();
                double hltAvg = dtype.Value.Values.Select(x => x[1]).Average();
                double armAvg = dtype.Value.Values.Select(x => x[2]).Average();

                Console.WriteLine($"{dtype.Key}::({damAvg:f2}/{hltAvg:f2}/{armAvg:f2})");


                Console.WriteLine(string.Join("\n", dtype.Value
                    .Select(s => $"-{s.Key} -> damage: {s.Value[0]}, health: {s.Value[1]}, armor: {s.Value[2]}")));

            }

        }
    }
}
