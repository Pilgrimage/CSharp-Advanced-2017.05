namespace p06_ZippingSlicedFiles
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ZippingSlicedFiles
    {
        private const string srcFilePath = @"..\..\..\Resources\";  // Source file
        private const string srcFileName = @"Neuschwanstein.jpg";  // Source file
        private const string asmFile = @"..\..\Assembled.jpg";
        private const string partsPath = @"..\..\..\Resources\Sliced\";     // Path for partial files
        private static List<string> slicedFileNames = new List<string>();


        public static void Main()
        {

            Console.Write("Please enter number of parts: ");
            int partsNum = int.Parse(Console.ReadLine());

            string srcFile = Path.Combine(srcFilePath, srcFileName);

            Slice(srcFile, partsPath, partsNum);
            Console.Write($"The file {srcFileName} is sliced. Press any key to assemble!");
            Console.ReadKey();
            Assemble(slicedFileNames, asmFile);
            Console.WriteLine($"\nThe Assembled file is created in project folder.");
        }


        public static void Slice(string srcFile, string localPath, int parts)
        {
            using (var src = new FileStream(srcFile, FileMode.Open))
            {
                double srcLength = src.Length;
                long partSize = (long)Math.Ceiling(srcLength / parts);

                long fileOffset = 0;

                string curFilePath;

                long sizeRemaining = src.Length;

                string pattern = @"(\w+).(\w+)";
                Regex fne = new Regex(pattern);
                var matches = fne.Matches(srcFileName);

                for (int i = 0; i < parts; i++)
                {
                    curFilePath = String.Format($@"{partsPath}{matches[0].Groups[1]}.Part-{i}.{matches[0].Groups[2]}.gz");
                    slicedFileNames.Add(curFilePath);

                    using (FileStream writePart = new FileStream(curFilePath, FileMode.Create))
                    {
                        using (GZipStream compressPart = new GZipStream(writePart, CompressionMode.Compress, false))
                        { 
                            
                            long curPartSize = 0;
                        byte[] buffer = new byte[4096];
                            while (curPartSize < partSize)
                            {
                                int readBytes = src.Read(buffer, 0, buffer.Length);
                                if (readBytes == 0)
                                {
                                    break;
                                }

                                compressPart.Write(buffer, 0, readBytes);
                                curPartSize += readBytes;
                            }
                        }
                    }

                    sizeRemaining = (int)src.Length - (i * partSize);

                    if (sizeRemaining < partSize)
                    {
                        partSize = sizeRemaining;
                    }
                    fileOffset += partSize;
                }
            }
        }

        public static void Assemble(List<string> fileNames, string asmFile)
        {
            using (FileStream writeAsm = new FileStream(asmFile, FileMode.Create))
            {
                foreach (var filePart in slicedFileNames)
                {
                    using (FileStream readPart = new FileStream(filePart, FileMode.Open))
                    {
                        using (var compressPart = new GZipStream(readPart, CompressionMode.Decompress, false))
                        {
                        Byte[] bytePart = new byte[4096];
                        while (true)
                        {
                            int readBytes = compressPart.Read(bytePart, 0, bytePart.Length);
                            if (readBytes == 0)
                            {
                                break;
                            }

                            writeAsm.Write(bytePart, 0, readBytes);
                        }
                    }
                }
                }
            }
        }

    }
}
