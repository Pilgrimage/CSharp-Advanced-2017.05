namespace p05_AppliedArithmetics3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AppliedArithmetics
    {
        public static class Functions
        {
            public static void Print(List<int> collection, Action<int> act, Action<int> lastElementAct)
            {
                for (int i = 0; i < collection.Count - 1; i++)
                {
                    act(collection[i]);
                }
                lastElementAct(collection[collection.Count - 1]);
            }
            
            public static List<int> ApplyFunc(List<int> collection, Func<int, int> func)
            {
                List<int> result = new List<int>();
                foreach (var item in collection)
                {
                    result.Add(func(item));
                }
                return result;
            }
        }


        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();

            while (input != "end")
            {
                switch (input)
                {
                    case "add":
                        numbers = Functions.ApplyFunc(numbers, n => n + 1);
                        break;
                    case "subtract":
                        numbers = Functions.ApplyFunc(numbers, n => n - 1);
                        break;
                    case "multiply":
                        numbers = Functions.ApplyFunc(numbers, n => n * 2);
                        break;
                    case "print":
                        Functions.Print(numbers, n => Console.Write(n + " "), n => Console.WriteLine(n));
                        break;
                    default:
                        Console.WriteLine(" No such command");
                        break;
                }

                input = Console.ReadLine();
            }

        }
    }
}
