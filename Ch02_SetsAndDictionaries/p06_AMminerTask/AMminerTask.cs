namespace p06_AMminerTask
{
    using System;
    using System.Collections.Generic;

    public class AMminerTask
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string,long> resources = new Dictionary<string, long>();

            while (input!="stop")
            {
                if (resources.ContainsKey(input))
                {
                    resources[input] += long.Parse(Console.ReadLine());
                }
                else
                {
                    resources.Add(input, long.Parse(Console.ReadLine()));
                }

                input = Console.ReadLine();
            }

            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
