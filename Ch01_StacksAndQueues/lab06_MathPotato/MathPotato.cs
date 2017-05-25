namespace lab06_MathPotato
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MathPotato
    {
        public static void Main()
        {
            string[] players = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int step = int.Parse(Console.ReadLine());
            Queue<string> playersName = new Queue<string>(players);
            int cycle = 1;

            while (playersName.Count > 1)
            {
                for (int i = 0; i < step - 1; i++)
                {
                    playersName.Enqueue(playersName.Dequeue());
                }

                if (IsPrime(cycle))
                {
                    Console.WriteLine($"Prime {playersName.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {playersName.Dequeue()}");
                }

                cycle++;

            }

            Console.WriteLine($"Last is {playersName.Dequeue()}");

        }

        private static bool IsPrime(int num)
        {
            if (num == 1) return false;
            if (num == 2) return true;

            var upperLimit = (int)Math.Floor(Math.Sqrt(num));

            for (int i = 2; i <= upperLimit; ++i)
            {
                if (num % i == 0) return false;
            }

            return true;
        }
    }
}
