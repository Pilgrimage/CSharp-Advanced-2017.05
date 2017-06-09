namespace p04_ConvertFromBase10toBaseN
{
    using System;
    using System.Text;
    using System.Numerics;

    public class ConvertFromBase10toBaseN
    {
        public static void Main()
        {
            string[] inputLine = Console.ReadLine().Trim().Split();
            int baseN = int.Parse(inputLine[0]);
            BigInteger numberDec = BigInteger.Parse(inputLine[1]);

            BigInteger numberNbase = new BigInteger(0);

            StringBuilder sb = new StringBuilder();

            while (numberDec > 0)
            {
                sb.Insert(0, numberDec % baseN);
                numberDec /= baseN;
            }

            if (sb.Length ==0)
            {
                sb.Insert(0, "0");
            }

            numberNbase = BigInteger.Parse(sb.ToString());

            Console.WriteLine(numberNbase);
        }

    }
}
