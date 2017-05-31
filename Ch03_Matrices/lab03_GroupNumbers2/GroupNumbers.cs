namespace lab03_GroupNumbers2
{
    using System;
    using System.Linq;

    public class GroupNumbers
    {
        public static void Main()
        {
            // Acceptable solution - with multi-dimensional array

            int[] input = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] matrix = new int[3][];

            matrix[0] = input.Where(x => x % 3 == 0).ToArray();
            matrix[1] = input.Where(x => Math.Abs(x) % 3 == 1).ToArray();
            matrix[2] = input.Where(x => Math.Abs(x) % 3 == 2).ToArray();

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }

        }
    }
}
