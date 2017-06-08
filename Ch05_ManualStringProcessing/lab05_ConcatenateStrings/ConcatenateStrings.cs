namespace lab05_ConcatenateStrings
{
    using System;

    public class ConcatenateStrings
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            string[] words = new string[num];

            for (int i = 0; i < num; i++)
            {
                words[i] = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", words));
        }
    }
}
