namespace p01_UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class UniqueUsernames
    {
        public static void Main()
        {
            int numebrOfNames = int.Parse(Console.ReadLine());
            HashSet<string> uniqueNames = new HashSet<string>();

            for (int i = 0; i < numebrOfNames; i++)
            {
                string name = Console.ReadLine();
                uniqueNames.Add(name);
            }

            foreach (var uniqueName in uniqueNames)
            {
                Console.WriteLine(uniqueName);
            }
        }
    }
}
