namespace P03_WordCount
{
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Linq;

    public class WordCount

    {
        public static void Main()
        {
            // I didn't split words by Unicode Character 'HORIZONTAL ELLIPSIS' (U+2026)
            // I had to use regex...

            //char[] separators = new[]
            //{  '\n', '\r', '\t', '.', ',', ';', ':', '!','¡' , '(', ')', '"', '-', '\\', '/', '[', ']', ' ', '?','¿' , '`', '_', '{', '}', '<', '>', '\u2026','\u8230', '\ue280' ,'…', '\u0085'};

            List<string> allWords = new List<string>();
            Dictionary<string, int> findWords = new Dictionary<string, int>();
            
            // Read text
            using (StreamReader readerText = new StreamReader(@"..\..\text.txt"))
            {
                string inputLine = readerText.ReadLine();

                while (inputLine != null)
                {
                    string pattern = @"\b(\w+[']?\w?)\b";
                    var matches = Regex.Matches(inputLine.ToLower(), pattern);

                    foreach (var word in matches)
                    {
                        allWords.Add(word.ToString());
                    }

                    inputLine = readerText.ReadLine();
                }
            }

            // Read words for searching & Check
            using (StreamReader readerWords = new StreamReader(@"..\..\words.txt"))
            {
                string inputWord = readerWords.ReadLine();

                while (inputWord != null)
                {
                    string word = inputWord.Trim().ToLower();
                    if (!findWords.ContainsKey(word))
                    {
                        int count = allWords.Where(x => x == word).Count();
                        findWords.Add(word, count);
                    }
                    inputWord = readerWords.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(@"..\..\result.txt"))
            {
                foreach (var word in findWords.OrderByDescending(x=> x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }

        }
    }
}
