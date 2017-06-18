namespace p12_InfernoIII
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class InfernoIII
    {
        private static List<string> filters = new List<string>();
        private static HashSet<int> indexOfExtracted = new HashSet<int>();

        public static void Main()
        {
            // video exercise 00:25:00

            int[] gems = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int gemsCount = gems.Length;

            string input = Console.ReadLine();

            while (input != "Forge")
            {
                string[] inputParts = input.Split(';');
                string command = inputParts[0];
                string filter = inputParts[1];
                string arg = inputParts[2];

                string filterFull = filter + ";" + arg;

                if (command == "Exclude")
                {
                    filters.Add(filterFull);
                }
                else if (command == "Reverse")
                {
                    int index = filters.LastIndexOf(filterFull);
                    filters.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Incorrect command!");
                }

                input = Console.ReadLine();
            }

            if (filters.Count > 0)
            {
                ApplyFilters(gems);
            }

            List<int> result = new List<int>();

            for (int i = 0; i < gemsCount; i++)
            {
                if (!indexOfExtracted.Contains(i))
                {
                    result.Add(gems[i]);
                }
            }

            //result = gems.Where((x, index) => !indexOfExtracted.Contains(index)).ToList();

            Console.WriteLine(string.Join(" ", result));
        }


        private static void ApplyFilters(int[] gems)
        {
            foreach (string filter in filters)
            {
                ApplyFilter(gems, filter);
            }
        }

        private static void ApplyFilter(int[] gems, string filerFull)
        {
            string[] filterSplited = filerFull.Split(';');
            string filter = filterSplited[0];
            int arg = int.Parse(filterSplited[1]);
            int gemsCount = gems.Length;

            switch (filter)
            {
                case "Sum Left":
                    for (int i = 0; i < gemsCount; i++)
                    {
                        int left = (i == 0) ? 0 : gems[i - 1];
                        if ((left + gems[i]) == arg)
                        {
                            indexOfExtracted.Add(i);
                        };
                    }
                    break;

                case "Sum Right":
                    for (int i = 0; i < gemsCount; i++)
                    {
                        int right = (i == gemsCount - 1) ? 0 : gems[i + 1];
                        if ((right + gems[i]) == arg)
                        {
                            indexOfExtracted.Add(i);
                        };
                    }
                    break;

                case "Sum Left Right":
                    for (int i = 0; i < gemsCount; i++)
                    {
                        int left = (i == 0) ? 0 : gems[i - 1];
                        int right = (i == gemsCount - 1) ? 0 : gems[i + 1];
                        if ((right + left + gems[i]) == arg)
                        {
                            indexOfExtracted.Add(i);
                        };
                    }
                    break;
            }
        }

    }
}
