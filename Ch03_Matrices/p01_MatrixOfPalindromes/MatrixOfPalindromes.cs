namespace p01_MatrixOfPalindromes
{
    using System;
    using System.Linq;

    public class MatrixOfPalindromes
    {
        public static void Main()
        {

            //char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            int[] parameters = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = parameters[0];
            int cols = parameters[1];

            string[][] palindroms = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                palindroms[i] = new string[cols];

                for (int j = 0; j < cols; j++)
                {
                    string border = ((char)(97 + i)).ToString();
                    string inner = ((char)(97 + i + j)).ToString();
                    //palindroms[i][j] = alphabet[i].ToString() + alphabet[i+j].ToString() + alphabet[i].ToString();
                    palindroms[i][j] = border + inner + border;
                    Console.Write(palindroms[i][j] + " ");
                }
                Console.WriteLine();
            }

            //foreach (var palindrom in palindroms)
            //{
            //    Console.WriteLine(string.Join(" ", palindrom));
            //}
        }
    }
}
