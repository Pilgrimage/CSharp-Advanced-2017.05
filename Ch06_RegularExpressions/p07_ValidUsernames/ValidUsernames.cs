namespace p07_ValidUsernames
{
    using System;
    using System.Text.RegularExpressions;

    public class ValidUsernames
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();
            string[] input = inputLine.Split(new char[] {' ','\\','/','(',')' }, StringSplitOptions.RemoveEmptyEntries);
            string normalized = String.Join(" ", input);

            string pattern = @"\b[a-zA-Z][\w\d]{2,24}\b";

            MatchCollection matches = Regex.Matches(normalized, pattern);

            int numbers = matches.Count;
            int indexOfFirst = -1;
            int maxLenght = 0;

            for (int i = 0; i < numbers-1; i++)
            {
                int currentSum = matches[i].Value.Length + matches[i+1].Value.Length;

                if (currentSum > maxLenght)
                {
                    indexOfFirst = i;
                    maxLenght = currentSum;
                }
            }
            Console.WriteLine(matches[indexOfFirst] + "\n" + matches[indexOfFirst+1]);
        }
    }
}
