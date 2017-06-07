namespace p04_CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        public static void Main()
        {
            // All files are in project folder

            string pathToLocalFolder = @"..\..\";               // for input file
            string pathToGlobalFolder = @"..\..\..\Resources\"; // for output file
            string inputFileName = @"BeautyLips.jpg";
            string outputFileName = @"Duplicate.jpg";

            string pathToSourceFile = Path.Combine(pathToGlobalFolder, inputFileName);
            string pathToDuplicateFile = Path.Combine(pathToLocalFolder, outputFileName);


            using (FileStream sourceStream = new FileStream(pathToSourceFile, FileMode.Open))
            {
                double fileLength = sourceStream.Length;
                using (FileStream duplicateStream = new FileStream(pathToDuplicateFile, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    int inputBlock = sourceStream.Read(buffer, 0, buffer.Length);

                    while (inputBlock!=0)
                    {
                        duplicateStream.Write(buffer, 0, inputBlock);
                        Console.WriteLine("{0:P}", Math.Min(sourceStream.Position/fileLength, 1));
                        inputBlock = sourceStream.Read(buffer, 0, buffer.Length);
                    }
                }
            }
            Console.WriteLine($"File \"{pathToSourceFile}\" was copied to \"{pathToDuplicateFile}\".");
        }
    }
}
