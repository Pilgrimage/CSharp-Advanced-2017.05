namespace p03_NMS
{
    using System;
    using System.Text;

    public class NMS
    {
        public static void Main()
        {
            StringBuilder sbIn = new StringBuilder();
            StringBuilder sbInCaseInSens = new StringBuilder();
            StringBuilder sbOut = new StringBuilder();

            string input;

            while ((input=Console.ReadLine())!= "---NMS SEND---")
            {
                sbIn.Append(input);
                sbInCaseInSens.Append(input.ToLower());
            }

            int fullLen = sbIn.Length;
            string delimiter = Console.ReadLine();

            sbOut.Append(sbIn[0]);

            for (int i = 1; i < fullLen; i++)
            {
                if (sbInCaseInSens[i] < sbInCaseInSens[i-1])
                {
                    sbOut.Append(delimiter);
                }
                sbOut.Append(sbIn[i]);
            }

            Console.WriteLine(string.Join("", sbOut.ToString()));
        }
    }
}
