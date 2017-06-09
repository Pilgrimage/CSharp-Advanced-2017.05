namespace p11_Palindromes
{
    using System;
    using System.Collections.Generic;

    public class Palindromes
    {
        public static void Main()
        {
            char[] separators = new char[] { ' ', '.', ',', '?', '!' };
            string[] words = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            SortedSet<string> pals = new SortedSet<string>();

            for (int i = 0; i < words.Length; i++)
            {
                char[] word = words[i].ToCharArray();
                Array.Reverse(word);
                string revWord = string.Join("", word);
                if (words[i] == revWord)
                {
                    pals.Add(words[i]);
                }
            }
            Console.WriteLine("[{0}]",String.Join(", ", pals));
        }
    }
}
