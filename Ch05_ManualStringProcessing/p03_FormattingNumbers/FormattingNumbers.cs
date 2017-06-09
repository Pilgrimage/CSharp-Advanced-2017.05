namespace p03_FormattingNumbers
{
    using System;

    public class FormattingNumbers
    {
        public static void Main()
        {
            char[] separators = new char[] { '(', ')', '[', ']', '<', '>', ',', '!', '?', ' ', '‘', '’', '\t', '\r', '\n' };
            string[] numbers = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int a = int.Parse(numbers[0]);
            double b = double.Parse(numbers[1]);
            double c = double.Parse(numbers[2]);
            string binary = Convert.ToString(a, 2);

            if (binary.Length<10)
            {
                binary = binary.PadLeft(10, '0');
            }
            else if (binary.Length>10)
            {
                binary = binary.Substring(0, 10);
            }

            string rowFormat = string.Format("|{0,-10:X}|{1,10}|{2,10:f2}|{3,-10:f3}|",a , binary, b ,c );
            Console.WriteLine(rowFormat);
        }
    }
}
