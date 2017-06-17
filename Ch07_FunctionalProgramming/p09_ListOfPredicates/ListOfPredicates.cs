namespace p09_ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Predicates
    {
        public static List<Func<int, bool>> predicates = new List<Func<int, bool>>();

        public static void AddPredicate(Func<int, bool> predicate)
        {
            predicates.Add(predicate);
        }

        public static List<int> ApplyPredicates(List<int> numbers)
        {
            List<int> result = new List<int>();

            foreach (int number in numbers)
            {
                bool res = true;
                foreach (var predicate in predicates)
                {
                    if (!predicate(number))
                    {
                        res = false;
                        break;
                    }
                }

                if (res)
                {
                    result.Add(number);
                }
            }
            return result;
        }
    }


    public class ListOfPredicates
    {
        public static void Main()
        {
            int endNum = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();
            for (int i = 1; i <= endNum; i++)
            {
                numbers.Add(i);
            }

            int[] divisors = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (int divisor in divisors)
            {
                Predicates.AddPredicate(n => n % divisor == 0);
            }

            numbers = Predicates.ApplyPredicates(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
