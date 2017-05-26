namespace p06_TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TruckTour
    {
        public static void Main()
        {
            int numberOfStations = int.Parse(Console.ReadLine());
            Queue<GasPump> pumps = new Queue<GasPump>();

            for (int i = 0; i < numberOfStations; i++)
            {
                int[] pumpInfo = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
                GasPump pump = new GasPump(pumpInfo[1], pumpInfo[0], i);
                pumps.Enqueue(pump);
            }


            int startStation = 0;
            int restFuel = 0;


            for (int i = 0; i < numberOfStations; i++)
            {
                GasPump current = pumps.Dequeue();
                pumps.Enqueue(current);

                if (i == 0)
                {
                    startStation = current.indexOfPump;
                    restFuel = 0;
                }

                int fuel = (restFuel + current.AmountOfGas);

                if (fuel >= current.DistanceToNext)
                {
                    restFuel = fuel - current.DistanceToNext;
                }
                else
                {
                    i = -1;
                }
            }

            Console.WriteLine(startStation);
            // This code will work only if the task has a solution !!
        }

        public class GasPump
        {
            private int distanceToNext;
            private int amountOfGas;
            public readonly int indexOfPump;

            public GasPump(int distanceToNext, int amountOfGas, int index)
            {
                this.DistanceToNext = distanceToNext;
                this.AmountOfGas = amountOfGas;
                this.indexOfPump = index;
            }

            public int DistanceToNext
            {
                get { return distanceToNext; }
                set { distanceToNext = value; }
            }
            public int AmountOfGas
            {
                get { return amountOfGas; }
                set { amountOfGas = value; }
            }
        }
    }
}
