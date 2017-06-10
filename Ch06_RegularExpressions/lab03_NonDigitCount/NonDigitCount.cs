namespace lab03_NonDigitCount
{
    using System;
    using System.Text.RegularExpressions;

    public class NonDigitCount
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            string pattern = @"\D";
            //string pattern = @"[^0-9]";
            //string pattern = @"[^0123456789]";

            Regex regex = new Regex(pattern);

            int count = regex.Matches(text).Count;

            Console.WriteLine($"Non-digits: {count}");
        }
    }
}
