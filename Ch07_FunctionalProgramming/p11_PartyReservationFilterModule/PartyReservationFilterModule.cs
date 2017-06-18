namespace p11_PartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PartyReservationFilterModule
    {
        private static List<string> partisans = new List<string>();
        private static Dictionary<string, HashSet<string>> filters = new Dictionary<string, HashSet<string>>();

        public static void Main()
        {
            partisans = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            filters = InitFilterList(filters);

            string input = Console.ReadLine();

            while (input != "Print")
            {
                string[] inputParts = input.Trim().Split(';');
                string command = inputParts[0];
                string filter = inputParts[1];
                string arg = inputParts[2];

                if (command == "Add filter")
                {
                    filters[filter].Add(arg);
                }
                else if (command == "Remove filter")
                {
                    if (filters[filter].Contains(arg))
                    {
                        filters[filter].Remove(arg);
                    }
                }

                input = Console.ReadLine();
            }

            partisans = ApplyFilters(partisans);

            Console.WriteLine(string.Join(" ", partisans));

        }


        private static Dictionary<string, HashSet<string>> InitFilterList(Dictionary<string, HashSet<string>> filters)
        {
            filters.Add("Starts with", new HashSet<string>());
            filters.Add("Ends with", new HashSet<string>());
            filters.Add("Length", new HashSet<string>());
            filters.Add("Contains", new HashSet<string>());
            return filters;
        }

        private static List<string> ApplyFilters(List<string> names)
        {
            List<string> result = new List<string>(names);
            if (filters["Starts with"].Count > 0)
            {
                result = ApplyStartsWith(result);
            }
            if (filters["Ends with"].Count > 0)
            {
                result = ApplyEndssWith(result);
            }
            if (filters["Length"].Count > 0)
            {
                result = ApplyLength(result);
            }
            if (filters["Contains"].Count > 0)
            {
                result = ApplyContains(result);
            }
            return result;
        }

        private static List<string> ApplyStartsWith(List<string> names)
        {
            List<string> result = new List<string>(names);
            foreach (string arg in filters["Starts with"])
            {
                result = result.Where(x => !x.StartsWith(arg)).ToList();
            }
            return result;
        }

        private static List<string> ApplyEndssWith(List<string> names)
        {
            List<string> result = new List<string>(names);
            foreach (string arg in filters["Ends with"])
            {
                result = result.Where(x => !x.EndsWith(arg)).ToList();
            }
            return result;
        }

        private static List<string> ApplyLength(List<string> names)
        {
            List<string> result = new List<string>(names);
            foreach (string arg in filters["Length"])
            {
                result = result.Where(x => x.Length != int.Parse(arg)).ToList();
            }
            return result;
        }

        private static List<string> ApplyContains(List<string> names)
        {
            List<string> result = new List<string>(names);
            foreach (string arg in filters["Contains"])
            {
                result = result.Where(x => !x.Contains(arg)).ToList();
            }
            return result;
        }
    }
}
