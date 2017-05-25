namespace p01_ReverseNumbersWithAStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbersWithAStack
    {
        public static void Main()
        {
            int[] numbersIn = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbers = new Stack<int>(numbersIn);

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
