namespace p08_RecursiveFibonacci
{
    using System;

    public class RecursiveFibonacci
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(number));
        }

        private static long GetFibonacci(int num)
        {
            if (num < 2) return num;
            if (num == 2) return 1;
            int k = num / 2;
            long a = GetFibonacci(k + 1);
            long b = GetFibonacci(k);
            if (num % 2 == 1)
                return a * a + b * b;
            else
                return b * (2 * a - b);
        }

    }
}
