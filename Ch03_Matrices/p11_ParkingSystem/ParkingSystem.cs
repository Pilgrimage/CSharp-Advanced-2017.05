namespace p11_ParkingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingSystem
    {
        public static void Main()
        {
            string[] size = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(size[0]);
            int cols = int.Parse(size[1]);

            bool[][] parking = new bool[rows][];
            for (int i = 0; i < rows; i++)
            {
                parking[i] = new bool[cols];
            }

            string input = Console.ReadLine();

            while (input != "stop")
            {
                string[] parameters = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                int entryRow = int.Parse(parameters[0]);
                int desiredRow = int.Parse(parameters[1]);
                int desiredCol = int.Parse(parameters[2]);

                //=======================================
                // Where i parked?
                int parkColumn = 0;
                if (parking[desiredRow][desiredCol] == false)
                {
                    parkColumn = desiredCol;
                }
                else
                {
                    for (int i = 1; i < cols-1; i++)
                    {
                        if (((desiredCol - i) > 0) && parking[desiredRow][desiredCol - i] == false)
                        {
                            parkColumn = (desiredCol - i);
                            break;
                        }
                        else if (((desiredCol + i) < cols) && parking[desiredRow][desiredCol + i] == false)
                        {
                            parkColumn = (desiredCol + i);
                            break;
                        }
                    }
                }
                //=========================================

                if (parkColumn == 0)
                {
                    Console.WriteLine($"Row {desiredRow} full");
                }
                else
                {
                    parking[desiredRow][parkColumn] = true;
                    int steps = Math.Abs(entryRow - desiredRow) + 1 + parkColumn;
                    Console.WriteLine(steps);
                }

                input = Console.ReadLine();
            }

        }
    }
}
