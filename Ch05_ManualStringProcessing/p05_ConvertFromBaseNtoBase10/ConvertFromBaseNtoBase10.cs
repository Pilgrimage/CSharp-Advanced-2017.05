namespace p05_ConvertFromBaseNtoBase10
{
    using System;
    using System.Numerics;

    public class ConvertFromBaseNtoBase10
    {
        public static void Main()
        {
            string[] inputLine = Console.ReadLine().Trim().Split();
            int baseN = int.Parse(inputLine[0]);
            char[] numberNbase = inputLine[1].ToCharArray();

            int len = numberNbase.Length;

            BigInteger numberDec = new BigInteger(0);

            for (int i = len - 1, n = 0; i >= 0; i--, n++)
            {
                int digit = (int)Char.GetNumericValue(numberNbase[n]);
                numberDec += BigInteger.Multiply(digit, BigInteger.Pow(baseN, i));
            }

            Console.WriteLine(numberDec);
        }
    }
}
