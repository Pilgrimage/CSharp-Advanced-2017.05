namespace p03_MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumElement
    {
        public static void Main()
        {
            int numTotal = int.Parse(Console.ReadLine());
            Stack<int> numStack = new Stack<int>();
            Stack<int> maxNumbers = new Stack<int>();

            while (numTotal != 0)
            {
                int[] command = Console.ReadLine()
                    .Trim()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int numType = command[0];

                switch (numType)
                {
                    case 1:
                    {
                        int numToPush = command[1];
                        numStack.Push(numToPush);

                        if (maxNumbers.Count == 0 || numToPush >= maxNumbers.Peek())
                        {
                            maxNumbers.Push(numToPush);
                        }
                        break;
                    }
                    case 2:
                    {
                        if (numStack.Count == 0)
                        {
                            Console.WriteLine("The stack is empty!");
                            break;
                        }
                        int numAtTop = numStack.Pop();
                        if (numAtTop == maxNumbers.Peek())
                        {
                            maxNumbers.Pop();
                        }
                        break;
                    }
                    case 3:
                    {
                        if (numStack.Count == 0)
                        {
                            Console.WriteLine("The stack is empty!");
                            break;
                        }
                        Console.WriteLine(maxNumbers.Peek());
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Invalid command!");
                        break;
                    }

                }
                numTotal--;
            }

        }
    }
}
