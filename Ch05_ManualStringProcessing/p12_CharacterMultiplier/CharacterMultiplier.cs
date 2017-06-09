namespace p12_CharacterMultiplier
{
    using System;

    public class CharacterMultiplier
    {
        public static void Main()
        {
            string[] number = Console.ReadLine().Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
            string num1 = "";       // num1 is longer string
            string num2 = "";       // num2 is equal or shorter

            if (number[0].Length >= number[1].Length)
            {
                num1 = number[0];
                num2 = number[1];
            }
            else
            {
                num1 = number[1];
                num2 = number[0];
            }

            char[] num1c = num1.ToCharArray();
            char[] num2c = num2.ToCharArray();

            int len1 = num1.Length;
            int len2 = num2.Length;
            int sum = 0;

            for (int i = 0; i < len1; i++)
            {
                int digit1 = num1c[i];
                int digit2 = i>=len2 ? 1 : num2c[i];
                sum += digit1 * digit2;
            }

            Console.WriteLine(sum);
        }
    }
}
