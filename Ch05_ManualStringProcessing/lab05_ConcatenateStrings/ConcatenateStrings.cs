using System.Text;

namespace lab05_ConcatenateStrings
{
    using System;

    public class ConcatenateStrings
    {
        public static void Main()
        {

            int num = int.Parse(Console.ReadLine());

            // Good work solution
            //string[] words = new string[num];
            //for (int i = 0; i < num; i++)
            //{
            //    words[i] = Console.ReadLine();
            //}
            //Console.WriteLine(string.Join(" ", words));


            // Another solution - with StringBuilder
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < num; i++)
            {
                sb.Append(Console.ReadLine()).Append(" ");
                }
            Console.WriteLine(sb);
        }
    }
}
