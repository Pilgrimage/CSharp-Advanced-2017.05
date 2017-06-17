namespace p10_PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredicateParty
    {
        public static void Main()
        {
            List<string> partisans = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> subSet = new List<string>();

            string input = Console.ReadLine();

            while (input != "Party!")
            {
                string[] commandFull = input.Split();
                string command = commandFull[0];
                string criteria = commandFull[1];
                string argument = commandFull[2];

                subSet = GetAffectedSubset(partisans, criteria, argument);

                if (command == "Remove")
                {
                    partisans = partisans.Except(subSet).ToList();
                }
                else if (command == "Double")
                {
                    foreach (var item in subSet)
                    {
                        int index = partisans.LastIndexOf(item);
                        partisans.Insert(index, item);
                    }
                }

                subSet.RemoveAll(x => true);

                input = Console.ReadLine();
            }

            if (partisans.Count > 0)
            {
                Console.WriteLine("{0} are going to the party!", string.Join(" ", partisans));
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }


        public static List<string> GetAffectedSubset(List<string> names, string criteria, string arg)
        {
            List<string> result = new List<string>();

            switch (criteria)
            {
                case "StartsWith":
                    result = names.Where(x => x.StartsWith(arg)).ToList();
                    break;
                case "EndsWith":
                    result = names.Where(x => x.EndsWith(arg)).ToList();
                    break;
                case "Length":
                    result = names.Where(x => x.Length == int.Parse(arg)).ToList();
                    break;
                default:
                    Console.WriteLine("No such command");
                    break;
            }

            return result;
        }
    }
}
