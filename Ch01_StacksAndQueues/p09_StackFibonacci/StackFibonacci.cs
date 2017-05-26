namespace p09_StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class StackFibonacci
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Stack<long> fibStack = new Stack<long>();

            fibStack.Push(0);
            fibStack.Push(1);
            long prev1 = 1;
            long prev2 = 0;

            for (int i = 2; i <= number; i++)
            {
                fibStack.Push(prev1 + prev2);
                prev2 = prev1;
                prev1 = fibStack.Peek();
            }


            // Another (Full Stack) Solution

            //for (int i = 2; i <= number; i++)
            //{
            //    prev1 = fibStack.Pop();
            //    prev2 = fibStack.Peek();
            //    fibStack.Push(prev1);

            //    fibStack.Push(prev1 + prev2);
            //}

            Console.WriteLine(fibStack.Peek());         
        }
    }
}
