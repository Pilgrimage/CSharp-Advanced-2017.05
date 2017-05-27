namespace p11_PoisonousPlants2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PoisonousPlants
    {
        public static void Main()
        {
            // Solution by Svetlin Gylov (2016.05)

            int n = int.Parse(Console.ReadLine());
            int[] plants = Console.ReadLine().Split().Select(int.Parse).ToArray();
            // using long break memory limit

            int[] days = new int[n];        // кое растение в кой ден умира

            Stack<int> proximityStack = new Stack<int>(); // Hold indexes of plants

            proximityStack.Push(0);

            for (int i = 1; i < n; i++)
            {
                int maxDays = 0;

                while (proximityStack.Count > 0 && plants[proximityStack.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[proximityStack.Pop()]);
                }

                if (proximityStack.Count>0)
                {
                    days[i] = maxDays + 1;
                }

                proximityStack.Push(i);
            }

            Console.WriteLine(days.Max());
        }
    }
}
