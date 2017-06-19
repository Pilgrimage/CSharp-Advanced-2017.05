namespace p12_LittleJohn
{
    using System;
    using System.Text.RegularExpressions;

    public class LittleJohn
    {
        public static void Main()
        {
            string pattern = @"[>]{0,2}(>----->)[>]?";
            int arrowSmall = 0;
            int arrowMedium = 0;
            int arrowBig = 0;

            Regex arrow = new Regex(pattern);
            for (int i = 0; i < 4; i++)
            {
                MatchCollection matches = arrow.Matches(Console.ReadLine());

                foreach (Match match in matches)
                {
                    switch (match.Length)
                    {
                        case 7: arrowSmall++;
                            break;
                        case 8: 
                        case 9: arrowMedium++;
                            break;
                        case 10: arrowBig++;
                            break;
                    }
                }
            }

            int startDec = int.Parse($"{arrowSmall}{arrowMedium}{arrowBig}");
            string startBinary = Convert.ToString(startDec, 2);

            char[] startBinaryChar = startBinary.ToCharArray();
            Array.Reverse(startBinaryChar);

            string binaryFull = startBinary + string.Join("", startBinaryChar);

            Console.WriteLine(Convert.ToInt32(binaryFull, 2));
        }
    }
}
