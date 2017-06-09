namespace p14_LettersChangeNumbers
{
    using System;

    public class LettersChangeNumbers
    {
        public static void Main()
        {
            char[] separators = new char[] { ' ', '\n', '\r', '\t' };
            string[] bombs = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            decimal totalSum = 0.0M;
            
            foreach (var bomb in bombs)
            {
                char firstLetter = bomb[0];
                char lastLetter = bomb[bomb.Length - 1];
                decimal groupNumber = decimal.Parse(bomb.Substring(1, bomb.Length - 2));

                decimal groupSumFirst = char.IsUpper(firstLetter) 
                                        ? groupNumber * 1.0M / (firstLetter - 64) 
                                        : groupNumber * 1.0M * (firstLetter - 96);

                decimal groupSumLast = char.IsUpper(lastLetter) 
                                        ? groupSumFirst - (lastLetter - 64) 
                                        : groupSumFirst + (lastLetter - 96);

                totalSum += groupSumLast;
            }

            Console.WriteLine($"{totalSum:F2}");
        }

    }
}
