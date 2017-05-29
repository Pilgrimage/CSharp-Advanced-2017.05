namespace p11_LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LogsAggregator
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            SortedDictionary<string, SortedDictionary<string, int>> log = new SortedDictionary<string, SortedDictionary<string, int>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] inputLine = Console.ReadLine().Trim().Split();

                string inputIp = inputLine[0];
                string inputName = inputLine[1];
                int inputTime = int.Parse(inputLine[2]);

                if (log.ContainsKey(inputName))
                {
                    if (log[inputName].ContainsKey(inputIp))
                    {
                        log[inputName][inputIp] += inputTime;
                    }
                    else
                    {
                        log[inputName].Add(inputIp, inputTime);
                    }
                }
                else
                {
                    SortedDictionary<string, int> newDict = new SortedDictionary<string, int>();
                    newDict.Add(inputIp, inputTime);
                    log.Add(inputName, newDict);
                }
            }

            foreach (var user in log)
            {
                Console.Write($"{user.Key}: {user.Value.Values.Sum()} [{string.Join(", ", user.Value.Select(x=>x.Key))}]");
                Console.WriteLine();
            }

        }
    }
}
