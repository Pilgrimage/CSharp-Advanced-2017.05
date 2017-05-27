namespace lab02_SoftUniParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftUniParty
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            SortedSet<string> reservations = new SortedSet<string>();
            SortedSet<string> party = new SortedSet<string>();

            while (input !="PARTY")
            {
                reservations.Add(input);
                input = Console.ReadLine();
            }

            while (input != "END")
            {
                party.Add(input);
                input = Console.ReadLine();
            }

            foreach (var guest in party)
            {
                reservations.Remove(guest);
            }

            Console.WriteLine(reservations.Count);
            foreach (var absent in reservations)
            {
                Console.WriteLine(absent);
            }
        }
    }
}
