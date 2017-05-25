namespace lab04_MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    public class MatchingBrackets
    {
        public static void Main()
        {
            string inputSequence = Console.ReadLine();
            int isLength = inputSequence.Length;
            Stack<int> openBrackets = new Stack<int>();

            for (int i = 0; i < isLength; i++)
            {
                if (inputSequence[i] == '(')
                {
                    openBrackets.Push(i);
                }
                else if (inputSequence[i] == ')')
                {
                    int obIndex = openBrackets.Pop();
                    string subExpression = inputSequence.Substring(obIndex, i - obIndex + 1);
                    Console.WriteLine(subExpression);
                }
            }
        }
    }
}
