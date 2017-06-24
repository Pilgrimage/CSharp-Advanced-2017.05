namespace p01_SecondNature
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SecondNature
    {
        public static void Main()
        {
            Stack<int> edels = new Stack<int>(Console.ReadLine()
                //.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Split(' ')
                .Select(int.Parse)
                .Reverse());

            Stack<int> buckets = new Stack<int>(Console.ReadLine()
                //.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Split(' ')
                .Select(int.Parse));

            Queue<int> secondNatures = new Queue<int>();

            while (buckets.Count > 0 && edels.Count > 0)
            {
                int edel = edels.Peek();
                int bucket = buckets.Peek();

                if (edel == bucket)             // second nature
                {
                    secondNatures.Enqueue(edel);
                    edels.Pop();
                    buckets.Pop();
                }
                else if (edel < bucket)         // eliminate edel, transfer rest of water
                {
                    edels.Pop();
                    buckets.Pop();
                    if (buckets.Count > 0)
                    {
                        buckets.Push(buckets.Pop() + bucket - edel);
                    }
                    else
                    {
                        buckets.Push(bucket - edel);
                    }
                }
                else if (edel > bucket)         // edel > bucket (needs more buckets)
                {
                    edels.Push(edels.Pop() - bucket);
                    buckets.Pop();
                }
            }

            if (edels.Count > 0)
            {
                Console.WriteLine(string.Join(" ", edels));
            }

            if (buckets.Count > 0)
            {
                Console.WriteLine(string.Join(" ", buckets));
            }

            if (secondNatures.Count > 0)
            {
                Console.WriteLine(string.Join(" ", secondNatures));
            }
            else
            {
                Console.WriteLine("None");
            }

        }
    }
}
