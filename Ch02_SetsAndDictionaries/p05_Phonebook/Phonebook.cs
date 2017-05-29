namespace p05_Phonebook
{
    using System;
    using System.Collections.Generic;

    public class Phonebook
    {
        public static void Main()
        {
            string[] inputString = Console.ReadLine().Split('-');

            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            while (inputString[0] != "search")
            {
                if (phonebook.ContainsKey(inputString[0]))
                {
                    phonebook[inputString[0]] = inputString[1];
                }
                else
                {
                    phonebook.Add(inputString[0], inputString[1]);
                }

                inputString = Console.ReadLine().Split('-');
            }

            string man = Console.ReadLine();

            while (man != "stop")
            {
                if (phonebook.ContainsKey(man))
                {
                    Console.WriteLine($"{man} -> {phonebook[man]}");
                }
                else
                {
                    Console.WriteLine($"Contact {man} does not exist.");
                }

                man = Console.ReadLine();
            }
        }
    }
}
