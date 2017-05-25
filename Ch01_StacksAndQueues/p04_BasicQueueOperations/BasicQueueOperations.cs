namespace p04_BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicQueueOperations
    {
        public static void Main()
        {

            int[] parameters = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numbersToEnq = parameters[0];
            int numbersToDeq = parameters[1];
            int numberToCheck = parameters[2];

            int[] numbers = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (numbers.Length != numbersToEnq)
            {
                Console.WriteLine("Invalid arguments!");
                return;
            }
            else if (numbersToEnq <= numbersToDeq)
            {
                Console.WriteLine("0");
                return;
            }

            Queue<int> numQueue = new Queue<int>(numbers);

            //for (int i = 0; i < numbersToEnq; i++)
            //{
            //    numQueue.Enqueue(numbers[i]);
            //}

            for (int i = 0; i < numbersToDeq; i++)
            {
                numQueue.Dequeue();
            }

            if (numQueue.Contains(numberToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numQueue.Min());
            }


        }
    }
}
