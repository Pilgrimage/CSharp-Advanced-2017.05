namespace p01_OddLines
{
    using System;
    using System.IO;

    public class OddLines
    {
        public static void Main()
        {
            string pathToGlobalFolder = @"..\..\..\Resources\";
            string fileName = @"InputTextFile.txt";

            string path = Path.Combine(pathToGlobalFolder, fileName);

            using (StreamReader reader = new StreamReader(path))
            {
                string inputLine = reader.ReadLine();
                int lineNumber = 0;

                while (inputLine != null)
                {
                    if (lineNumber % 2==1)
                    {
                        string printLine = String.Concat($"Line {lineNumber:D2} => ", inputLine);
                        Console.WriteLine(printLine);
                    }

                    inputLine = reader.ReadLine();
                    lineNumber++;
                }

            }
        }
    }
}
