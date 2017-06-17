namespace p06_ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseAndExclude
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int divider = int.Parse(Console.ReadLine());

            Stack<int> result = new Stack<int>();
            Predicate<int> isForDelete = n => n % divider != 0;

            result = ReverseExclude(numbers, isForDelete);

            Console.WriteLine(string.Join(" ", result));
        }

        private static Stack<int> ReverseExclude(List<int> numbers, Predicate<int> checker)
        {
            Stack<int> result = new Stack<int>();
            foreach (int number in numbers)
            {
                if (checker(number))
                {
                    result.Push(number);
                }
            }
            return result;
        }
    }
}
