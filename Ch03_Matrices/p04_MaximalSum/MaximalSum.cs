namespace p04_MaximalSum
{
    using System;
    using System.Linq;

    public class MaximalSum
    {
        public static void Main()
        {
            int[] matrixSize = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int curSum = 0;
            int maxRow = 0;
            int maxCol = 0;
            int maxSum = int.MinValue;

            for (int i = 0; i < rows-2; i++)
            {
                for (int j = 0; j < cols-2; j++)
                {
                    curSum = matrix[i][j] + matrix[i][j + 1] + matrix[i][j + 2] +
                             matrix[i+1][j] + matrix[i+1][j + 1] + matrix[i+1][j + 2] +
                             matrix[i+2][j] + matrix[i+2][j + 1] + matrix[i+2][j + 2];
                    if (curSum>maxSum)
                    {
                        maxRow = i;
                        maxCol = j;
                        maxSum = curSum;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[maxRow][maxCol]} {matrix[maxRow][maxCol+1]} {matrix[maxRow][maxCol+2]}");
            Console.WriteLine($"{matrix[maxRow+1][maxCol]} {matrix[maxRow+1][maxCol+1]} {matrix[maxRow+1][maxCol+2]}");
            Console.WriteLine($"{matrix[maxRow+2][maxCol]} {matrix[maxRow+2][maxCol+1]} {matrix[maxRow+2][maxCol+2]}");

        }
    }
}
