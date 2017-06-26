namespace p01
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class p01_Regeh
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            int len = input.Length;
            int index = 0;
            StringBuilder sbOut = new StringBuilder();

            //string pattern = @"\[[^\s^\[]*<(\d+)REGEH(\d+)>[^\s^\]]*]";
            //string pattern = @"\[[^\s^\[^\]]+<(\d+)REGEH(\d+)>[^\s^\[]+]";
            //string pattern = @"\[[^\[^\]]+<(\d+)REGEH(\d+)>[^\[]+?]";
            string pattern = @"\[[^\[^\]]+<(\d+)REGEH(\d+)>[^\[]+?]";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            int mCount = matches.Count;

            if (mCount < 1)
            {
                return;
            }

            foreach (Match match in matches)
            {
                long curInd = long.Parse(match.Groups[1].Value);
                index += (int)curInd % len;

                if (index >= len)
                {
                    index = index - len - 1;
                }

                sbOut.Append(input[index]);

                curInd = long.Parse(match.Groups[2].Value);
                index += (int)curInd % len;

                if (index >= len)
                {
                    index = index - len - 1;
                }
                sbOut.Append(input[(int)index]);
            }

            Console.WriteLine(sbOut);
        }
    }
}
