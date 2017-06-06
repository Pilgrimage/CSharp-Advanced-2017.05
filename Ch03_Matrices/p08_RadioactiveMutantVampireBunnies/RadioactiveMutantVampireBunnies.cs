namespace p08_RadioactiveMutantVampireBunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RadioactiveMutantVampireBunnies
    {
        public static void Main()
        {
            // I'm ashamed of this code ...
            // But sometimes the result is more important

            int[] size = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int cols = size[1];
            char[][] matrix = new char[rows][];

            Coordinates playerPos = new Coordinates();
            Coordinates lastPos = new Coordinates();

            bool playerWon = false;
            bool playerDied = false;
            string action = "";     // won / dead

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
                if (matrix[i].Contains('P'))
                {
                    playerPos.Row = i;
                    playerPos.Col = Array.IndexOf(matrix[i], 'P');
                }
            }


            string commands = Console.ReadLine().Trim();

            for (int i = 0; i < commands.Length; i++)
            {
                char command = commands[i];

                switch (command)
                {
                    case 'L':
                        playerPos.Col--;

                        if (playerPos.Col < 0)      // Out of matrix
                        {
                            matrix[playerPos.Row][playerPos.Col + 1] = '.';
                            lastPos.Col = playerPos.Col + 1;
                            lastPos.Row = playerPos.Row;
                            matrix = SpreadBunnies(matrix);
                            playerWon = true;
                            action = "won";
                        }
                        else if (matrix[playerPos.Row][playerPos.Col] == 'B')
                        {
                            matrix[playerPos.Row][playerPos.Col + 1] = '.';
                            lastPos = playerPos;
                            matrix = SpreadBunnies(matrix);
                            playerDied = true;
                            action = "dead";
                        }
                        else
                        {
                            matrix[playerPos.Row][playerPos.Col] = 'P';
                            matrix[playerPos.Row][playerPos.Col + 1] = '.';
                            lastPos = playerPos;
                            matrix = SpreadBunnies(matrix);
                            if (matrix[playerPos.Row][playerPos.Col] == 'B')
                            {
                                playerDied = true;
                                action = "dead";
                            }
                        }

                        break;

                    case 'R':
                        playerPos.Col++;

                        if (playerPos.Col > cols - 1)      // Out of matrix
                        {
                            matrix[playerPos.Row][playerPos.Col - 1] = '.';
                            lastPos.Col = playerPos.Col - 1;
                            lastPos.Row = playerPos.Row;
                            matrix = SpreadBunnies(matrix);
                            playerWon = true;
                            action = "won";
                        }
                        else if (matrix[playerPos.Row][playerPos.Col] == 'B')
                        {
                            matrix[playerPos.Row][playerPos.Col - 1] = '.';
                            lastPos = playerPos;
                            matrix = SpreadBunnies(matrix);
                            playerDied = true;
                            action = "dead";
                        }
                        else
                        {
                            matrix[playerPos.Row][playerPos.Col] = 'P';
                            matrix[playerPos.Row][playerPos.Col - 1] = '.';
                            lastPos = playerPos;
                            matrix = SpreadBunnies(matrix);
                            if (matrix[playerPos.Row][playerPos.Col] == 'B')
                            {
                                playerDied = true;
                                action = "dead";
                            }
                        }

                        break;

                    case 'U':
                        playerPos.Row--;

                        if (playerPos.Row < 0)      // Out of matrix
                        {
                            lastPos.Col = playerPos.Col;
                            lastPos.Row = playerPos.Row + 1;
                            matrix[playerPos.Row + 1][playerPos.Col] = '.';
                            matrix = SpreadBunnies(matrix);
                            playerWon = true;
                            action = "won";
                        }
                        else if (matrix[playerPos.Row][playerPos.Col] == 'B')
                        {
                            matrix[playerPos.Row + 1][playerPos.Col] = '.';
                            lastPos = playerPos;
                            matrix = SpreadBunnies(matrix);
                            playerDied = true;
                            action = "dead";
                        }
                        else
                        {
                            matrix[playerPos.Row][playerPos.Col] = 'P';
                            matrix[playerPos.Row + 1][playerPos.Col] = '.';
                            lastPos = playerPos;
                            matrix = SpreadBunnies(matrix);
                            if (matrix[playerPos.Row][playerPos.Col] == 'B')
                            {
                                playerDied = true;
                                action = "dead";
                            }
                        }

                        break;

                    case 'D':
                        playerPos.Row++;

                        if (playerPos.Row > rows - 1)      // Out of matrix
                        {
                            playerPos.Row--;
                            lastPos = playerPos;
                            matrix[playerPos.Row][playerPos.Col] = '.';
                            matrix = SpreadBunnies(matrix);
                            playerWon = true;
                            action = "won";
                        }
                        else if (matrix[playerPos.Row][playerPos.Col] == 'B')
                        {
                            matrix[playerPos.Row - 1][playerPos.Col] = '.';
                            lastPos = playerPos;
                            matrix = SpreadBunnies(matrix);
                            playerDied = true;
                            action = "dead";
                        }
                        else
                        {
                            matrix[playerPos.Row][playerPos.Col] = 'P';
                            matrix[playerPos.Row - 1][playerPos.Col] = '.';
                            lastPos = playerPos;
                            matrix = SpreadBunnies(matrix);
                            if (matrix[playerPos.Row][playerPos.Col] == 'B')
                            {
                                playerDied = true;
                                action = "dead";
                            }
                        }

                        break;

                }

                if (playerDied == true || playerWon == true)
                {
                    GameOver(matrix, lastPos, action);
                    return;
                }

            }
            if (playerDied == false && playerWon == false)
            {
                GameOver(matrix, lastPos, "won");
            }

        }



        private static char[][] SpreadBunnies(char[][] matrix)
        {
            HashSet<Coordinates> newBunnies = new HashSet<Coordinates>();    // HashSet for eliminate duplicates

            int rows = matrix.Length;
            int cols = matrix[0].Length;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i][j] == 'B')
                    {
                        newBunnies.Add(new Coordinates() { Row = (i + 1) > (rows - 1) ? i : (i + 1), Col = j });
                        newBunnies.Add(new Coordinates() { Row = (i - 1) < 0 ? 0 : (i - 1), Col = j });
                        newBunnies.Add(new Coordinates() { Row = i, Col = (j + 1) > (cols - 1) ? j : (j + 1) });
                        newBunnies.Add(new Coordinates() { Row = i, Col = (j - 1) < 0 ? 0 : (j - 1) });

                    }
                }
            }

            foreach (var bunny in newBunnies)
            {
                matrix[bunny.Row][bunny.Col] = 'B';
            }
            return matrix;
        }


        private static void GameOver(char[][] matrix, Coordinates last, string action)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
            Console.WriteLine($"{action}: {last.Row} {last.Col}");
        }

    }

    public class Coordinates
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
