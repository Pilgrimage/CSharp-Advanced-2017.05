namespace p02_NaturesProphet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Flower
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public Flower(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }

    public class NaturesProphet
    {
        public static void Main()
        {
            int[] size = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int cols = size[1];

            int[][] garden = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                garden[i] = new int[cols];
            }

            List<Flower> flowers = new List<Flower>();

            string input;

            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] newFlower = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                flowers.Add(new Flower(newFlower[0], newFlower[1]));
            }

            foreach (Flower flower in flowers.OrderBy(x => x.Row).ThenBy(x => x.Col))
            {
                int row = flower.Row;
                int col = flower.Col;
                
                for (int j = 0; j < cols; j++)                  // increase row
                {
                    garden[row][j] += 1;
                }

                for (int i = 0; i < rows; i++)                  // increase colimn
                {
                    garden[i][col] += 1;
                }

                garden[row][col] -= 1;                          // compensate double increasing

            }


            foreach (var row in garden)
            {
                Console.WriteLine(string.Join(" ", row));
            }

        }
    }
}
