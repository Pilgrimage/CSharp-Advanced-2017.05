namespace lab04_SpecialWords
{
    using System;
    using System.Linq;

    public class SpecialWords
    {
        public static void Main()
        {
            char[] separators = new char[] { '(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' ', '‘', '’' };

            string[] specialWords = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string[] inLine = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);


            for (int i = 0; i < specialWords.Length; i++)
            {
                var qty = inLine.Where(x => x == specialWords[i]).Count();
                Console.WriteLine($"{specialWords[i]} - {qty}");
            }



            //var words = new Dictionary<string, int>();

            //foreach (var curSWord in specialWords)
            //{
            //    var counter = 0;
            //    var foundIndex = 0;
            //    var indexOfWord = Array.IndexOf(inLine, curSWord, foundIndex);

            //    while (indexOfWord != -1)
            //    {
            //        ++counter;
            //        foundIndex = indexOfWord;
            //        indexOfWord = Array.IndexOf(inLine, curSWord, foundIndex + 1);
            //    }

            //    words.Add(curSWord, counter);
            //}

            //foreach (var words in words)
            //{
            //    Console.WriteLine($"{word.Key} - {word.Value}");
            //}

        }
    }
}
