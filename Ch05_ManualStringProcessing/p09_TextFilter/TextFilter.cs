namespace p09_TextFilter
{
    using System;

    public class TextFilter
    {
        public static void Main()
        {
            char[] separators = new char[] { '(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' ', '‘', '’', '\t', '\r', '\n' };
            string[] patterns = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            foreach (var pattern in patterns)
            {
                string replace = new string('*', pattern.Length);
                text = text.Replace(pattern, replace);

            }
            Console.WriteLine(text);
        }
    }
}
