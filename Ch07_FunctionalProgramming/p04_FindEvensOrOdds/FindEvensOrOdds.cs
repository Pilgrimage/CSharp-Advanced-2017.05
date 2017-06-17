namespace p04_FindEvensOrOdds
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class FindEvensOrOdds
    {
        public static void Main()
        {
            int[] borders = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            int lowBorder = borders[0];
            int highBorder = borders[1];

            string condition = Console.ReadLine().Trim().ToLower();

            Predicate<int> checker = n => false;

            if (condition == "even")
            {
                checker = n => n % 2 == 0;
            }
            else if (condition == "odd")
            {
                checker = n => n % 2 != 0;
            }

            Queue<int> result = Generator(lowBorder, highBorder, checker);
            Console.WriteLine(string.Join(" ", result));


            //******************************************
            // How to create a sequence... - Enumerable.Range(int start, int count)
            //
            //var numbers = Enumerable.Range(lowBorder, (highBorder-lowBorder+1));
        }


        private static Queue<int> Generator(int start, int stop, Predicate<int> checker)
        {
            Queue<int> result = new Queue<int>();

            for (int i = start; i <= stop; i++)
            {
                if (checker(i))
                {
                    result.Enqueue(i);
                }
            }
            return result;
        }
    }
}
