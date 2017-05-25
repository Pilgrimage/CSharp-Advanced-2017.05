namespace lab05_HotPotato
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HotPotato
    {
        public static void Main()
        {
            string[] players = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int step = int.Parse(Console.ReadLine());
            Queue<string> playersName = new Queue<string>(players);

            while (playersName.Count>1)
            {
                for (int i = 0; i < step-1; i++)
                {
                    playersName.Enqueue(playersName.Dequeue());
                }
                Console.WriteLine($"Removed {playersName.Dequeue()}");
            }

            Console.WriteLine($"Last is {playersName.Dequeue()}");

        }
    }
}
