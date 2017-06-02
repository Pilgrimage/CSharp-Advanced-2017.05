namespace p06_TargetPractice
{
    using System;
    using System.Linq;

    public class TargetPractice
    {
        public static void Main()
        {
            int[] size = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int cols = size[1];
            char[][] matrix = new char[rows][];
            string snake = Console.ReadLine().Trim();

            // Filling matrix
            int charIndex = 0;
            bool reverse = true;

            for (int i = rows - 1; i >= 0; i--)
            {
                matrix[i] = new char[cols];
                if (reverse)
                {
                    for (int j = cols - 1; j >= 0; j--)
                    {
                        matrix[i][j] = snake[charIndex];
                        charIndex = (charIndex + 1) % snake.Length;
                    }
                    reverse = false;
                }
                else 
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i][j] = snake[charIndex];
                        charIndex = (charIndex + 1) % snake.Length;
                    }
                    reverse = true;
                }
            }
            
            // Read shoot parameters
            int[] shoot = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int posR = shoot[0];
            int posC = shoot[1];
            int radius = shoot[2];

            // Bombing matrix
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    //if (Math.Sqrt(Math.Pow(Math.Abs(posR - i), 2) + Math.Pow(Math.Abs(posC - j), 2)) <= radius)
                    if (Math.Sqrt(Math.Pow((posR - i), 2) + Math.Pow((posC - j), 2)) <= radius)
                    {
                        matrix[i][j] = ' ';
                    }
                }
            }

            // Collapse matrix
            for (int j = 0; j < cols; j++)          // columns
            {
                for (int i = rows - 1; i >= 0; i--) // rows
                {
                    if (matrix[i][j] == ' ')
                    {
                        int tempRowIndex = i;
                        while (matrix[i][j] == ' ')
                        {
                            tempRowIndex--;
                            if (tempRowIndex < 0)
                            {
                                break;
                            }
                            else if (matrix[tempRowIndex][j] != ' ')
                            {
                                matrix[i][j] = matrix[tempRowIndex][j];
                                matrix[tempRowIndex][j] = ' ';
                            }
                        }
                    }
                }
            }

            //  Another (good) solution for collapse matrix from colleague !
            //for (int j = 0; j < cols; j++)
            //{
            //    string realChars = "";
            //    for (int i = rows - 1; i >= 0; i--)
            //    {
            //        if (matrix[i][j] != ' ')
            //            realChars += matrix[i][j];
            //    }
            //    for (int i = 0; i < rows; i++)
            //    {
            //        if (i >= realChars.Length)
            //            matrix[rows - 1 - i][j] = ' ';
            //        else
            //            matrix[rows - 1 - i][j] = realChars[i];
            //    }
            //}


            PrintCharArray(matrix);

        }

        private static void PrintCharArray(char[][] chars)
        {
            foreach (var ch in chars)
            {
                Console.WriteLine(string.Join("", ch));
            }
        }

    }
}
