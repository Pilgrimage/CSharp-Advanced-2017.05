namespace p11_PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PoisonousPlants
    {
        public static void Main()
        {
            // This code does not work properly - 33/100 

            int plantQty = int.Parse(Console.ReadLine());
            int[] pesticides = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            Queue<int> plants = new Queue<int>(pesticides);

            for (int i = 1; i <= plantQty; i++)
            {
                int dead = KillTheWeak(plants);
                if (dead == 0)
                {
                    Console.WriteLine(i - 1);
                    return;
                }
            }

        }

        private static int KillTheWeak(Queue<int> plants)
        {
            int plantInstantQty = plants.Count;
            int dead = 0;
            bool forDeleting = false;

            for (int i = 1; i <= plantInstantQty; i++)
            {
                int leftPlant = plants.Dequeue();

                if (forDeleting == false)
                {
                    plants.Enqueue(leftPlant);
                }

                if (i == plantInstantQty)
                {
                    break;
                }

                int currentPlant = plants.Peek();
                forDeleting = false;

                if (currentPlant >= leftPlant)
                {
                    forDeleting = true;
                    dead += 1;
                }

            }

            //Console.WriteLine(String.Join("-", plants));
            return dead;
        }

    }
}
