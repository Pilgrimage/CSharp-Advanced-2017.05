namespace p08_FullDirectoryTraversal
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;

    public class FullDirectoryTraversal
    {
        public static void Main()
        {
            Console.Write("Please enter full path to Directory to be listed: ");
            string folder = Console.ReadLine();
            ;
            while (true)
            {
                if (Directory.Exists(Path.GetDirectoryName(folder)))
                {
                    break;
                }
                Console.WriteLine("Please, enter valid path to Directory: ");
                folder = Console.ReadLine();
            }

            string[] filePaths = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);

            List<FileInfo> files = filePaths.Select(path => new FileInfo(path)).ToList();

            var sortedFiles = files.OrderBy(f => f.Length)
                .GroupBy(f => f.Extension)
                .OrderByDescending(c => c.Count())
                .ThenBy(g => g.Key);

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullReportFileName = Path.Combine(desktopPath, "report.txt");

            StreamWriter writer = new StreamWriter(fullReportFileName);

            foreach (var group in sortedFiles)
            {
                writer.WriteLine(group.Key);

                foreach (var file in group)
                {
                    writer.WriteLine($"--{file.Name} - {(file.Length / 1024.0):F3}kb");
                }
            }

            writer.Close();

            Console.WriteLine($"Information is saved in file  {fullReportFileName}");
        }
    }
}
