namespace p10_UnicodeCharacters
{
    using System;

    public class UnicodeCharacters
    {
        public static void Main()
        {
            char[] text = Console.ReadLine().ToCharArray();

            foreach (var ch in text)
            {
                Console.Write($"\\u{((ushort)ch):x4}");
            }
            Console.WriteLine();
        }
    }
}
