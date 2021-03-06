﻿using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        using (var reader = new StreamReader("../../Program.cs"))
        {
            using (var writer = new StreamWriter("../../reversed.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    for (int i = line.Length - 1; i >= 0; i--)
                    {
                        writer.Write(line[i]);
                    }

                    writer.WriteLine();

                    //// Alternative solution (XPX)
                    //char[] reversed = line.ToCharArray();
                    //writer.WriteLine(string.Join("",reversed.Reverse()));

                    line = reader.ReadLine();
                }
            }
        }
        // The result is Trimmed !!!
    }
}
