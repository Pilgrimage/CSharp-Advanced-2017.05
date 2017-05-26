namespace p10_SimpleTextEditor2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleTextEditor
    {
        public static void Main()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            Stack<string> prevWorkText = new Stack<string>();

            string workingText = "";

            //  1 someString - appends someString to the end of the text
            //  2 count - erases the last count elements from the text
            //  3 index - returns the element at position index from the text
            //  4 - undoes the last not undone command of type 1/2 and returns the text to the state before that operation

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandFull = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                int command = int.Parse(commandFull[0]);

                switch (command)
                {
                    case 1:
                        prevWorkText.Push(workingText);
                        workingText = String.Concat(workingText, commandFull[1]);
                        break;

                    case 2:
                        int count = int.Parse(commandFull[1]);
                        prevWorkText.Push(workingText);
                        workingText = workingText.Remove(workingText.Length - count);
                        break;

                    case 3:
                        int charIndex = int.Parse(commandFull[1]);
                        Console.WriteLine(workingText[charIndex - 1]);
                        break;

                    case 4:
                        workingText = prevWorkText.Pop();
                        break;
                }

            }
        }
    }
}
