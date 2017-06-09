namespace p02_StringLength
{
    using System;

    public class StringLength
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();

            string inputLineExtended = inputLine + new string('*', 20);

            Console.WriteLine(inputLineExtended.Substring(0,20));
        }
    }
}
