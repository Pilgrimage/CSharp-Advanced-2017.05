namespace lab05_MinEvenNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MinEvenNumber
    {
        public static void Main()
        {
            //// Solution 1
            //List<double> evenNumbers = Console.ReadLine()
            //    .Split()
            //    .Select(double.Parse)
            //    .Where(n => n % 2 == 0)
            //    .ToList();

            //if (evenNumbers.Count>0)
            //{
            //    Console.WriteLine("{0:f2}",evenNumbers.Min());
            //}
            //else
            //{
            //    Console.WriteLine("No match");
            //}


            // Solution 2
            try
            {
                Console.WriteLine("{0:f2}", Console.ReadLine()
                    .Split()
                    .Select(double.Parse)
                    .Where(n => n % 2 == 0)
                    .Min());

            }
            catch (Exception e)
            {
                Console.WriteLine("No match");
            }
        }
    }
}
