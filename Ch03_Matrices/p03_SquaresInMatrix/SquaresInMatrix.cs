namespace p03_SquaresInMatrix
{
    using System;
    using System.Linq;

    public class SquaresInMatrix
    {
        public static void Main()
        {
            int[] matrixSize = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            string[][] matrix = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            }

            int numberOfSquares = 0;

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    if (matrix[i][j] == matrix[i][j+1] && 
                        matrix[i+1][j] == matrix[i + 1][j + 1] &&
                        matrix[i][j] == matrix[i+1][j])
                    {
                        numberOfSquares++;
                    }
                }
            }

            Console.WriteLine(numberOfSquares);
        }
    }
}
