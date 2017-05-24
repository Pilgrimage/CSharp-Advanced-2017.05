namespace lab02_SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleCalculator
    {
        public static void Main()
        {
            string[] inputSequence = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Stack<int> scStack = new Stack<int>();
            int numberOfElements = inputSequence.Length;

            for (int i = 0; i < numberOfElements; i++)
            {
                int operand1;
                int operand2;

                if (i%2==0)
                {
                    operand1 = int.Parse(inputSequence[i]);
                    scStack.Push(operand1);
                }
                else
                {
                    switch (inputSequence[i])
                    {
                        case "+":
                            operand2 = int.Parse(inputSequence[i + 1]);
                            scStack.Push(scStack.Pop() + operand2);
                            i++;
                            break;

                        case "-":
                            operand2 = int.Parse(inputSequence[i + 1]);
                            scStack.Push(scStack.Pop() - operand2);
                            i++;
                            break;
                    }
                }
            }

            Console.WriteLine(scStack.Pop());
        }
    }
}
