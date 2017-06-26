namespace p01_2
{
    using System;
    using System.Text.RegularExpressions;

    class p01_2
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int len = input.Length;
            int index = 0;
            string sbOut = "";

            string pattern = @"\[[^\s^\[]*<(\d+)REGEH(\d+)>[^\s^\]]*]";

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

                sbOut +=input[index];

                curInd = long.Parse(match.Groups[2].Value);
                index += (int)curInd % len;

                if (index >= len)
                {
                    index = index - len - 1;
                }
                sbOut += input[index];
            }

            Console.WriteLine(sbOut);

        }
    }
}
