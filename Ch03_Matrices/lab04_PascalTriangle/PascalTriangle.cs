namespace lab04_PascalTriangle
{
    using System;

    public class PascalTriangle
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            long[][] pascal = new long[size][];

            for (int i = 0; i < size; i++)
            {
                pascal[i] = new long[i+1];
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (j==0 || j==i)
                    {
                        pascal[i][j] = 1;
                    }
                    else
                    {
                        pascal[i][j] = pascal[i - 1][j - 1] + pascal[i - 1][j];
                    }
                }
            }

            foreach (var row in pascal)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
