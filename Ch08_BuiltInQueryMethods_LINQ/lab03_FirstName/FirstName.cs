namespace lab03_FirstName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FirstName
    {
        public static void Main()
        {
            List<string> names = Console.ReadLine()
                .Split()
                .OrderBy(s => s)
                .ToList();

            List<string> letters = Console.ReadLine()
                .ToLower()
                .Split()
                .OrderBy(s => s)
                .ToList();

            string winner = "";

            foreach (var letter in letters)
            {
                //string result = names.Where(w => w.ToLower().StartsWith(letter)).FirstOrDefault();
                string result = names.FirstOrDefault(w => w.ToLower().StartsWith(letter));

                if (result!=null)
                {
                    winner = result;
                    break;
                }
            }

            Console.WriteLine((winner == "") ? "No match" : winner);
        }
    }
}
