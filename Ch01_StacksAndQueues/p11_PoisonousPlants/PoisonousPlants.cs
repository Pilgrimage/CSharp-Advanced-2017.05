namespace p11_PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PoisonousPlants
    {
        public static void Main()
        {
            int plantQty = int.Parse(Console.ReadLine());
            Queue<Plant> plants = new Queue<Plant>();
            long[] pesticides = Console.ReadLine().Trim().Split().Select(long.Parse).ToArray();

            for (int i = 1; i <= plantQty; i++)
            {
                Plant newPlant = new Plant(pesticides[i - 1], i);
                plants.Enqueue(newPlant);
            }


            for (int i = 1; i <= plantQty; i++)
            {
                int dead = KillTheWeak(plants);
                if (dead == 0)
                {
                    Console.WriteLine(i-1);
                    return;
                }
                //Console.WriteLine($"Day {i} -> {dead} plants died");
            }

        }

        private static int KillTheWeak(Queue<Plant> plants)
        {
            int plantInstantQty = plants.Count;
            Plant leftPlant;
            Plant currentPlant;
            int dead = 0;
            bool forDeleting = false;

            for (int i = 1; i < plantInstantQty; i++)
            {
                leftPlant = plants.Dequeue();
                if (forDeleting)
                {
                    plants.Enqueue(leftPlant);
                }
                currentPlant = plants.Peek();

                if (currentPlant.PlantPesticide > leftPlant.PlantPesticide)
                {
                    forDeleting = true;
                    dead += 1;
                }
                else
                {
                    forDeleting = false;
                }

            }
            return dead;
        }

    }
    public class Plant
    {
        private int plantNumber;
        private long plantPesticide;

        public Plant(long plantPesticide, int plantNumber)
        {
            this.PlantNumber = plantNumber;
            this.PlantPesticide = plantPesticide;
        }

        public long PlantPesticide
        {
            get { return plantPesticide; }
            set {plantPesticide = value;}
        }

        public int PlantNumber
        {
            get { return plantNumber; }
            set { plantNumber = value; }
        }
    }

}
