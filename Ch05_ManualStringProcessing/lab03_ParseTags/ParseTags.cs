namespace lab03_ParseTags
{
    using System;
    using System.Collections.Generic;

    public class ParseTags
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();

            string openTagPattern = "<upcase>";
            string closeTagPattern = "</upcase>";

            int[] tagScope = new int[2];
            Stack<int[]> tags = new Stack<int[]>();


            int tagOpen = inputLine.IndexOf(openTagPattern);
            int tagClose = inputLine.IndexOf(closeTagPattern);


            while (true)
            {
                if (tagOpen >= 0 && tagClose > tagOpen)
                {
                    tags.Push(new int[] { tagOpen, tagClose });
                }
                else
                {
                    break;
                }
                int temp = tags.Peek()[1];
                tagOpen = inputLine.IndexOf(openTagPattern, temp + 1);
                tagClose = inputLine.IndexOf(closeTagPattern, tagOpen + 1);
            }

            while (tags.Count != 0)
            {
                int[] curTag = tags.Pop();

                int openTagFirstSymbolIndex = curTag[0];
                int openTagLastSymbolIndex = openTagFirstSymbolIndex + openTagPattern.Length-1;

                int closeTagFirstSymbolIndex = curTag[1];
                int closeTagLastSymbolIndex = closeTagFirstSymbolIndex + closeTagPattern.Length-1;

                int textFirstSymbolIndex = openTagLastSymbolIndex + 1;
                int textLastSymbolIndex = closeTagFirstSymbolIndex - 1;

                string newSubStr = inputLine.Substring(textFirstSymbolIndex, textLastSymbolIndex - textFirstSymbolIndex + 1).ToUpper();
                string oldSubStr = inputLine.Substring(openTagFirstSymbolIndex, closeTagLastSymbolIndex - openTagFirstSymbolIndex + 1);

                inputLine = inputLine.Replace(oldSubStr, newSubStr);
            }

            Console.WriteLine(inputLine);
        }
    }
}
