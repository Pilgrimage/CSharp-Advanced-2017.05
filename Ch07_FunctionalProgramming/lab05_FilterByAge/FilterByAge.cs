namespace lab05_FilterByAge
{
    using System;
    using System.Collections.Generic;

    public class FilterByAge
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 0; i < num; i++)
            {
                string[] pair = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                string name = pair[0];
                int age = int.Parse(pair[1]);
                people.Add(name, age);
            }

            string condition = Console.ReadLine().Trim();
            int ageLimit = int.Parse(Console.ReadLine());
            string format = Console.ReadLine().Trim();


            
            Func<int, bool> tester = CreateTester(condition, ageLimit);

            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            PrintFilteredStudent(people, tester, printer);
            
        }

        private static void PrintFilteredStudent(
            Dictionary<string, int> people,
            Func<int, bool> tester,
            Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in people)
            {
                if (tester(person.Value))
                {
                    printer(person);
                }
            }
        }


        public static Func<int, bool> CreateTester(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return x => x < age;
                case "older":
                    return x => x >= age;
                default:
                    return null;
            }
        }


        public static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine($"{person.Key}");
                case "age":
                    return person => Console.WriteLine($"{person.Value}");
                case "name age":
                    return person =>
                        Console.WriteLine($"{person.Key} - {person.Value}");
                default: return null;
            }
        }
    }
}
