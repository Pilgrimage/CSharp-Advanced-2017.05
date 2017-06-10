namespace lab06_ValidUsernames
{
    using System;
    using System.Text.RegularExpressions;

    public class ValidUsernames
    {
        public static void Main()
        {
            string pattern = @"^[a-zA-Z0-9-_]{3,16}$";
            //string pattern = @"^[\w\d-]{3,16}$";
            
            Regex regex = new Regex(pattern);

            string inputLine = Console.ReadLine();

            while (inputLine !="END")
            {
                bool result = regex.IsMatch(inputLine);

                Console.WriteLine("{0}", result ? "valid" : "invalid");
                inputLine = Console.ReadLine();
            }

        }
    }
}
