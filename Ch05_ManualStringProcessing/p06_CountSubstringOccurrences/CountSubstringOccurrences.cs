namespace p06_CountSubstringOccurrences
{
    using System;

    public class CountSubstringOccurrences
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = Console.ReadLine();
            int len = text.Length;

            int count = 0;
            int position = 0;
            int index = 0;

            while (index != -1)
            {
                index = text.IndexOf(pattern, position, StringComparison.OrdinalIgnoreCase);
                if (index >= 0)
                {
                    count++;
                    position = index + 1;
                    if (position > (len - 1))
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
