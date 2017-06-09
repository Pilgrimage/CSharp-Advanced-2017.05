using System.Linq;

namespace p01_ReverseString
{
    using System;
    using System.Text;

    public class ReverseString
    {
        public static void Main()
        {
            // Break memory limit
            //char[] inputLine = Console.ReadLine().ToCharArray();
            //Console.WriteLine(string.Join("",inputLine.Reverse()));


            // Break Time limit
            //string inputLine = Console.ReadLine();
            //int len = inputLine.Length;
            //for (int i = len-1; i >=0; i--)
            //{
            //    Console.Write(inputLine[i]);
            //}
            //Console.WriteLine();


            // Break memory limit
            //string inputLine = Console.ReadLine();
            //var reversed = new string(inputLine.Reverse().ToArray());
            //Console.WriteLine(reversed);


            // Break memory limit
            //char[] inputCharArr = Console.ReadLine().ToCharArray();
            //Array.Reverse(inputCharArr);
            //string result = string.Join("", inputCharArr);
            //Console.WriteLine(result);
            

            // Work well
            string inputLine = Console.ReadLine();
            int len = inputLine.Length;
            StringBuilder reversed = new StringBuilder(len);

            for (int i = len - 1; i >= 0; i--)
            {
                reversed.Append(inputLine[i]);
            }
            Console.WriteLine(reversed);
        }
    }
}
