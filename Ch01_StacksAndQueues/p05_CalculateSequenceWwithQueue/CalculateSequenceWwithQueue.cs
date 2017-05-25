namespace p05_CalculateSequenceWwithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CalculateSequenceWwithQueue
    {
        public static void Main()
        {
            long num = long.Parse(Console.ReadLine());
            Queue<long> calcQueue = new Queue<long>();
            Queue<long> printQueue = new Queue<long>();

            calcQueue.Enqueue(num);
            printQueue.Enqueue(num);

            for (int i = 0; i < 17; i++)
            {
                long numBase = calcQueue.Dequeue();

                long s1 = numBase + 1;
                calcQueue.Enqueue(s1);
                printQueue.Enqueue(s1);

                long s2 = 2 * numBase + 1;
                calcQueue.Enqueue(s2);
                printQueue.Enqueue(s2);

                long s3 = numBase + 2;
                calcQueue.Enqueue(s3);
                printQueue.Enqueue(s3);
            }

            Console.WriteLine(String.Join(" ", printQueue.Take(50)));

        }
    }
}
