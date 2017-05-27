namespace lab01_ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ParkingLot
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            SortedSet<string> parking = new SortedSet<string>();

            while (input != "END")
            {
                string[] inputParams = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                //string[] inputParams = Regex.Split(input, ", ");

                string carNumber = inputParams[1];

                if (inputParams[0] == "IN")
                {
                    parking.Add(carNumber);
                }
                else
                {
                    parking.Remove(carNumber);
                }

                input = Console.ReadLine();
            }

            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (string number in parking)
                {
                    Console.WriteLine(number);
                }
            }

        }
    }
}
