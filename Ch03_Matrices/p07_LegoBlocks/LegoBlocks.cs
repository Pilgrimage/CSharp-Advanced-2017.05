namespace p07_LegoBlocks
{
    using System;
    using System.Linq;

    public class LegoBlocks
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[][] arrOne = new int[size][];
            int[][] arrTwo = new int[size][];

            for (int i = 0; i < size; i++)
            {
                arrOne[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int i = 0; i < size; i++)
            {
                arrTwo[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            // Reverse matrix Two
            for (int i = 0; i < size; i++)
            {
                Array.Reverse(arrTwo[i]);
            }


            bool rectPossible = false;
            int sumRowsLength = arrOne[0].Length + arrTwo[0].Length;

            for (int i = 1; i < size; i++)
            {
                if ((arrOne[i].Length + arrTwo[i].Length) != sumRowsLength)
                {
                    break;
                }
                else if (i == (size - 1))
                {
                    rectPossible = true;
                }
            }

            if (rectPossible)
            {
                int[][] arrSum = new int[size][];

                for (int i = 0; i < size; i++)
                {
                    arrSum[i] = new int[sumRowsLength];
                    arrOne[i].CopyTo(arrSum[i], 0);
                    arrTwo[i].CopyTo(arrSum[i], arrOne[i].Length);

                    Console.WriteLine("[{0}]", string.Join(", ", arrSum[i]));
                }
            }
            else
            {
                int totalNumberOfCells = GetTotalCellsNumber(arrOne) + GetTotalCellsNumber(arrTwo);
                Console.WriteLine($"The total number of cells is: {totalNumberOfCells}");
            }
        }

        private static int GetTotalCellsNumber(int[][] matrix)
        {
            int result = 0;
            foreach (var array in matrix)
            {
                result += array.Length;
            }
            return result;
        }
    }
}
