namespace p07_SumBigNumbers
{
    using System;
    using System.Linq;
    using System.Text;

    public class SumBigNumbers
    {
        public static void Main()
        {
            string number1 = Console.ReadLine().TrimStart('0');
            string number2 = Console.ReadLine().TrimStart('0');
            string num1 = "";       // num1 is longer string
            string num2 = "";       // num2 is equal or shorter

            if (number1.Length >= number2.Length)
            {
                num1 = number1;
                num2 = number2;
            }
            else
            {
                num1 = number2;
                num2 = number1;
            }
            int len1 = num1.Length;
            int len2 = num2.Length;
            int transfer = 0;

            StringBuilder sbr = new StringBuilder(0);

            for (int i = len1 - 1, j = len2 - 1; i >= 0; i--, j--)
            {
                int digit1 = (int)Char.GetNumericValue(num1[i]);
                int digit2 = (j < 0) ? 0 : (int)Char.GetNumericValue(num2[j]);

                int subtotal = digit1 + digit2 + transfer;
                transfer = 0;
                if (subtotal > 9)
                {
                    transfer = 1;
                    subtotal = subtotal % 10;
                }

                sbr.Append(subtotal);

            }

            if (transfer == 1)
            {
                sbr.Append(transfer);
            }

            char[] sum = sbr.ToString().ToCharArray();
            Console.WriteLine(string.Join("", sum.Reverse()));

        }
    }
}
