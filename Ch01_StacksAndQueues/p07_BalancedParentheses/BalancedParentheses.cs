namespace p07_BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParentheses
    {
        public static void Main()
        {
            string inputSequence = Console.ReadLine().Trim();
            int isLength = inputSequence.Length;

            if (isLength % 2 == 1)
            {
                Console.WriteLine("NO");
                return;
            }

            Stack<char> isStack = new Stack<char>();

            for (int i = 0; i < isLength; i++)
            {
                char currChar = inputSequence[i];

                if (currChar=='(' || currChar == '[' || currChar == '{')
                {
                    isStack.Push(currChar);
                }
                else
                {
                    char openBracket = isStack.Pop();

                    switch (openBracket)
                    {
                        case '[':
                            if (currChar != ']')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;

                        case '(':
                            if (currChar != ')')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;

                        case '{':
                            if (currChar != '}')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
