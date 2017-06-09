namespace p08_MultiplyBigNumber
{
    using System;
    using System.Linq;
    using System.Text;

    public class MultiplyBigNumber
    {
        public static void Main()
        {
            //string num1 = Console.ReadLine().TrimStart('0');
            char[] num1 = Console.ReadLine().TrimStart('0', ' ').ToCharArray();
            int num2 = int.Parse(Console.ReadLine());
            Array.Reverse(num1);

            if (num2 == 0)
            {
                Console.WriteLine("0");
                return;
            }

            int len = num1.Length;
            int transfer = 0;

            StringBuilder sb = new StringBuilder(0);

            for (int i = 0; i < len; i++)
            {
                int digit1 = (int)Char.GetNumericValue(num1[i]);

                int subtotal = digit1*num2 + transfer;
                transfer = 0;

                if (subtotal > 9)
                {
                    transfer = subtotal/10;
                    subtotal = subtotal % 10;
                }

                sb.Append(subtotal);

                if (transfer > 0 && i==(len-1))
                {
                    sb.Append(transfer);
                }
            }

            char[] sum = sb.ToString().ToCharArray();
            Console.WriteLine(string.Join("", sum.Reverse()));

        }
    }
}
