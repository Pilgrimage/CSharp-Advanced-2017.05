namespace p02_DiagonalDifference
{
    using System;
    using System.Linq;

    public class DiagonalDifference
    {
        public static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[][] matrix = new int[matrixSize][];

            for (int i = 0; i < matrixSize; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int primaryD = 0;
            int secondaryD = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                primaryD += matrix[i][i];
                secondaryD += matrix[i][matrixSize - 1 - i];
            }

            Console.WriteLine(Math.Abs(primaryD - secondaryD));
        }
    }
}
