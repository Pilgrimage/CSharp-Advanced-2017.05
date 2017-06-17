namespace p05_AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AppliedArithmetics
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine().Trim().ToLower();

            while (command != "end")
            {
                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
                else
                {
                    numbers = numbers.ExecuteCommand(command);
                }

                command = Console.ReadLine().Trim().ToLower();
            }
        }
    }


    public static class CollectionExtensions
    {
        public static List<int> ExecuteCommand(this List<int> numbers, string command)
        {
            List<int> result = new List<int>(numbers);

            switch (command)
            {
                case "add":
                    result = numbers.Select(n => n + 1).ToList();
                    break;
                case "subtract":
                    result = numbers.Select(n => n - 1).ToList();
                    break;
                case "multiply":
                    result = numbers.Select(n => n * 2).ToList();
                    break;
                default:
                    Console.WriteLine(" No such command");
                    break;
            }

            return result;
        }
    }
}


