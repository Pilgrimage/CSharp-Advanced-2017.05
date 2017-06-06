namespace p09_Crossfire2
{
    using System;
    using System.Linq;

    public class Crossfire
    {
        public static void Main()
        {
            int[] size = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int cols = size[1];

            // Initialize matrix
            int[][] space = new int[rows][];
            int mValue = 0;
            for (int i = 0; i < rows; i++)
            {
                space[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    mValue++;
                    space[i][j] = mValue;
                }
            }


            string input = Console.ReadLine().Trim();

            while (input != "Nuke it from orbit")
            {

                int[] shoot = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int shootR = shoot[0];
                int shootC = shoot[1];
                int radius = shoot[2];

                ShootIt(space, shootR, shootC, radius);
                space = Collapse(space);

                input = Console.ReadLine().Trim();
            }

            PrintSpace(space);
        }


        private static void ShootIt(int[][] space, int shootR, int shootC, int radius)
        {
            for (int i = (shootR - radius); i <= (shootR + radius); i++)
            {
                if (i >= 0 && i < space.Length && shootC >= 0 && shootC < space[i].Length)
                {
                    space[i][shootC] = 0;
                }
            }

            for (int j = (shootC - radius); j <= (shootC + radius); j++)
            {
                if (shootR >= 0 && shootR < space.Length && j >= 0 && j < space[shootR].Length)
                {
                    space[shootR][j] = 0;
                }
            }
        }

        private static int[][] Collapse(int[][] space)
        {
            for (int i = 0; i < space.Length; i++)
            {
                for (int j = 0; j < space[i].Length; j++)
                {
                    if (space[i][j] < 1)
                    {
                        space[i] = space[i].Where(n => n > 0).ToArray();
                    }
                }

                if (space[i].Count() < 1)
                {
                    space = space.Take(i).Concat(space.Skip(i + 1)).ToArray();
                    i--;
                }
            }
            return space;
        }


        private static void PrintSpace(int[][] space)
        {
            foreach (var row in space)
            {
                Console.WriteLine(string.Join(" ", row.Where(c => c != 0)));
            }
        }
    }
}
