namespace p12_StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StringMatrixRotation
    {
        public static void Main()
        {
            string commandStr = Console.ReadLine().Trim();
            int degree = (int.Parse(commandStr.Substring(7, (commandStr.Length - 8)))) % 360;
            
            //Console.WriteLine(degree);

            Queue<string> inLines = new Queue<string>();
            int maxLength = 0;

            string input = Console.ReadLine();

            while (input != "END")
            {
                int inputLength = input.Length;
                if (inputLength > maxLength)
                {
                    maxLength = inputLength;
                }
                inLines.Enqueue(input);
                input = Console.ReadLine();
            }

            int rows = inLines.Count;
            int cols = maxLength;

            char[][] matrix = new char[rows][];

            // build normal matrix
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new char[cols];
                string line = inLines.Dequeue().PadRight(cols);

                for (int j = 0; j < cols; j++)
                {
                    matrix[i][j] = line[j];
                }
            }

            // build x90 clockwise matrix
            char[][] matrix90 = new char[cols][];
            for (int i = 0; i < cols; i++)
            {
                matrix90[i] = new char[rows];
            }

            for (int row = 0, row2 = rows - 1; row < rows; row++, row2--)
            {
                for (int col = 0, col2 = cols - 1; col < cols; col++, col2--)
                {
                    matrix90[col][row2] = matrix[row][col];
                }
            }


            switch (degree)
            {
                case 0:
                    {
                        foreach (var mat in matrix)
                        {
                            Console.WriteLine(string.Join("", mat));
                        }
                        break;
                    }
                case 90:
                    {
                        foreach (var mat in matrix90)
                        {
                            Console.WriteLine(string.Join("", mat));
                        }
                        break;
                    }
                case 180:
                    {
                        foreach (var mat in matrix)
                        {
                            Array.Reverse(mat);
                        }
                        for (int i = rows - 1; i >= 0; i--)
                        {
                            Console.WriteLine(string.Join("", matrix[i]));
                        }
                        break;
                    }
                case 270:
                    {
                        for (int r = cols - 1; r >= 0; r--)
                        {
                            for (int c = rows - 1; c >= 0; c--)
                            {
                                Console.Write(matrix90[r][c]);
                            }
                            Console.WriteLine();
                        }
                        break;
                    }
            }

        }

    }
}
