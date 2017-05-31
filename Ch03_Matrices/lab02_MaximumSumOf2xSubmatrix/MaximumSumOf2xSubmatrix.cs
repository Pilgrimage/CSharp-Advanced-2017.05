namespace lab02_MaximumSumOf2xSubmatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumSumOf2xSubmatrix
    {
        public static void Main()
        {
            int[] arrSize = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int fullRows = arrSize[0];
            int fullCols = arrSize[1];

            int[][] arrEllements = new int[fullRows][];

            for (int i = 0; i < fullRows; i++)
            {
                arrEllements[i] = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            if (fullRows < 2 || fullCols < 2)
            {
                return;
            }

            int curSum = 0;
            int maxRowIndex = 0;
            int maxColIndex = 0;
            int maxSum = 0;


            for (int i = 0; i < fullRows - 1; i++)
            {
                for (int j = 0; j < fullCols - 1; j++)
                {
                    curSum = arrEllements[i][j] + arrEllements[i + 1][j] + arrEllements[i][j + 1] + arrEllements[i + 1][j + 1];
                    if (curSum>maxSum)
                    {
                        maxSum = curSum;
                        maxRowIndex = i;
                        maxColIndex = j;
                    }
                }
            }

            Console.WriteLine($"{arrEllements[maxRowIndex][maxColIndex]} {arrEllements[maxRowIndex][maxColIndex + 1]}");
            Console.WriteLine($"{arrEllements[maxRowIndex + 1][maxColIndex]} {arrEllements[maxRowIndex + 1][maxColIndex + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
