namespace p09_UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserLogs
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            SortedDictionary<string, Dictionary<string, int>> sumLog = new SortedDictionary<string, Dictionary<string, int>>();

            while (input != "end")
            {
                string[] inputParts = input.Trim().Split();

                int ipPartLength = inputParts[0].Length;
                string ipAddress = inputParts[0].Substring(3, ipPartLength - 3);

                int msgPartLength = inputParts[1].Length;
                string message = inputParts[1].Substring(9, msgPartLength - 10);

                int userPartLength = inputParts[2].Length;
                string username = inputParts[2].Substring(5, userPartLength - 5);

                if (sumLog.ContainsKey(username))
                {
                    if (sumLog[username].ContainsKey(ipAddress))
                    {
                        sumLog[username][ipAddress] += 1;
                    }
                    else
                    {
                        sumLog[username].Add(ipAddress, 1);
                    }
                }
                else
                {
                    Dictionary<string, int> newDict = new Dictionary<string, int>();
                    newDict.Add(ipAddress, 1);
                    sumLog.Add(username, newDict);
                }

                input = Console.ReadLine();
            }

            foreach (var user in sumLog)
            {
                Console.WriteLine($"{user.Key}:");

                // Variant 1 
                //int numberOfIps = user.Value.Count;
                //int i = 0;

                //foreach (var log in user.Value)
                //{
                //    i = i + 1;
                //    if (i < numberOfIps)
                //    {
                //        Console.Write($"{log.Key} => {log.Value}, ");
                //    }
                //    else
                //    {
                //        Console.WriteLine($"{log.Key} => {log.Value}.");

                //    }
                //}

                // Variant 2
                Console.WriteLine("{0}.", string.Join(", ", user.Value.Select(a => $"{a.Key} => {a.Value}")));
            }
        }
    }
}
