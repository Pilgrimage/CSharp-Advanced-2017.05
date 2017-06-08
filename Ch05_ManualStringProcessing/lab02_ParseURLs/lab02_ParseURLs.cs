namespace lab02_ParseURLs
{
    using System;

    public class lab02_ParseURLs
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();

            string[] firstCut = inputLine.Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries);

            if (firstCut.Length == 2)
            {
                string protocol = firstCut[0];

                int firstSlash = firstCut[1].IndexOf("/");

                if (firstSlash != -1)
                {
                    string server = firstCut[1].Substring(0, firstSlash);
                    string resources = firstCut[1].Substring(firstSlash + 1);

                    Console.WriteLine($"Protocol = {protocol}");
                    Console.WriteLine($"Server = {server}");
                    Console.WriteLine($"Resources = {resources}");
                }
                else
                {
                    Console.WriteLine("Invalid URL");
                }

            }
            else
            {
                Console.WriteLine("Invalid URL");
            }
        }
    }
}
