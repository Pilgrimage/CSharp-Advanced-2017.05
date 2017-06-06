namespace p02_LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        public static void Main()
        {
            string pathToLocalFolder = @"..\..\";               // for input file
            string pathToGlobalFolder = @"..\..\..\Resources\"; // for output file
            string inputFileName = @"InputTextFile.txt";
            string outputFileName = @"NumberedTextFile.txt";

            string pathForInput = Path.Combine(pathToGlobalFolder, inputFileName);
            string pathForOutput = Path.Combine(pathToLocalFolder, outputFileName);

            using (StreamReader reader = new StreamReader(pathForInput))
            {
                using (StreamWriter writer = new StreamWriter(pathForOutput))
                {
                    string inputLine = reader.ReadLine();
                    int lineNumber = 0;

                    while (inputLine != null)
                    {
                        string newLine = String.Concat($"Line {lineNumber:D2} => ", inputLine);
                        writer.WriteLine(newLine);

                        inputLine = reader.ReadLine();
                        lineNumber++;
                    }
                }
            }
        }

    }
}