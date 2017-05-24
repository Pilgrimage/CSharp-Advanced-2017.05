namespace lab03_DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    public class DecimalToBinaryConverter
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Stack<int> dbcStack = new Stack<int>();

            if (number == 0)
            {
                dbcStack.Push(0);
            }
            else
            {
                while (number > 0)
                {
                    dbcStack.Push(number % 2);
                    number = number / 2;
                }
            }

            string result = String.Join("", dbcStack);
            Console.WriteLine(result);
        }
    }
}
