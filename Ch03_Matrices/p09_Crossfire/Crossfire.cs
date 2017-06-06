namespace p09_Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Crossfire
    {
        public static void Main()
        {

            // Experiments.... don't work

            int[] size = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int cols = size[1];


            // Initialize List structure
            List<List<int>> spaceL = new List<List<int>>();
            int mValue = 0;
            for (int i = 0; i < rows; i++)
            {
                List<int> newRow = new List<int>();
                for (int j = 0; j < cols; j++)
                {
                    mValue++;
                    newRow.Add(mValue);
                }
                spaceL.Add(newRow);
            }

            PrintSpace(spaceL);

            // Get the parameters of a shoot

            string input = Console.ReadLine().Trim();

            while (input != "Nuke it from orbit")
            {
                int[] shoot = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int shootR = shoot[0];
                int shootC = shoot[1];
                int radius = shoot[2];

                spaceL = ShootIt(spaceL, input);


                input = Console.ReadLine().Trim();

            }


            PrintSpace(spaceL);
        }


        private static List<List<int>> ShootIt(List<List<int>> space, string input)
        {
            int[] shoot = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int shootR = shoot[0];
            int shootC = shoot[1];
            int radius = shoot[2];
            int rows = space.Count;
            int rowCols = space[shootR].Count;

            // IsMatrixAffected?
            long blastRMin = (long)shootR - radius;
            long blastRMax = (long)shootR + radius;
            long blastCMin = (long)shootC - radius;
            long blastCMax = (long)shootC + radius;

            int blastRMinNorm = (blastRMin < int.MinValue) ? int.MinValue : (int)blastRMin;
            int blastRMaxNorm = (blastRMax > int.MaxValue) ? int.MaxValue : (int)blastRMax;
            int blastCMinNorm = (blastCMin < int.MinValue) ? int.MinValue : (int)blastCMin;
            int blastCMaxNorm = (blastCMax > int.MaxValue) ? int.MaxValue : (int)blastCMax;

            // Row=R


            if (blastRMinNorm>(rows-1) && blastRMaxNorm<0 &&
                blastCMinNorm>(rowCols-1) && blastCMaxNorm<0)
            {
                Console.WriteLine("matrix is not affected");
                return space;
            }







            return space;
        }



        private static void PrintSpace(List<List<int>> space)
        {
            foreach (var row in space)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
