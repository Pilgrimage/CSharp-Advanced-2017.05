namespace lab01_SumMatrixElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumMatrixElements
    {
        public static void Main()
        {
            int[] arrSize = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] arrEllements = new int[arrSize[0]][];

            for (int i = 0; i < arrSize[0]; i++)
            {
                arrEllements[i] = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int sum = 0;

            foreach (var element in arrEllements)
            {
                sum += element.Sum();
            }

            Console.WriteLine($"{arrEllements.Length}\n{arrEllements[1].Length}\n{sum}");
        }
    }
}
