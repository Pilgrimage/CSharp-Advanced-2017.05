namespace p02_BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicStackOperations
    {
        public static void Main()
        {

            int[] parameters = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numbersToPush = parameters[0];
            int numbersToPop = parameters[1];
            int numberToCheck = parameters[2];

            int[] numbersIn = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numStack = new Stack<int>(numbersIn);

            if (numbersIn.Length != numbersToPush)
            {
                Console.WriteLine("Invalid arguments!");
                return;
            }
            else if (numbersToPush <= numbersToPop)
            {
                Console.WriteLine("0");
                return;
            }
            
            for (int i = 0; i < numbersToPop; i++)
            {
                numStack.Pop();
            }

            if (numStack.Contains(numberToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numStack.Min());
            }


        }
    }
}
