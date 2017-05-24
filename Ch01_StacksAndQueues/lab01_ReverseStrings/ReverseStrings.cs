namespace lab01_ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class ReverseStrings
    {
        public static void Main()
        {
            string inputString = Console.ReadLine();
            Stack<char> rsStack = new Stack<char>();
            int inputStringLength = inputString.Length;

            for (int i = 0; i < inputStringLength; i++)
            {
                rsStack.Push(inputString[i]);
            }

            Console.WriteLine(String.Join("",rsStack));
        }
    }
}
