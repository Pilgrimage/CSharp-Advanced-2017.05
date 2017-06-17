namespace p05_AppliedArithmetics2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AppliedArithmetics
    {
        public static class Functions
        {
            public static List<int> ExecuteCommand(List<int> collection, Func<int,int> func)
            {
                List<int> result = new List<int>();
                foreach (var num in collection)
                {
                    result.Add(func(num));
                }
                return result;
            }

            public static void Print(List<int> collection, Action<List<int>> action)
            {
                action(collection);
            }

        }


        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine().Trim().ToLower();

            while (command != "end")
            {

                switch (command)
                {
                    case "add":
                        numbers = Functions.ExecuteCommand(numbers, n => n + 1);
                        break;
                    case "subtract":
                        numbers = Functions.ExecuteCommand(numbers, n => n - 1);
                        break;
                    case "multiply":
                        numbers = Functions.ExecuteCommand(numbers, n => n*2);
                        break;
                    case "print":
                        Functions.Print(numbers, arr => Console.WriteLine(string.Join(" ", arr)));
                        break;
                    default:
                        Console.WriteLine(" No such command");
                        break;
                }

                command = Console.ReadLine().Trim().ToLower();
            }
        }
    }
}
