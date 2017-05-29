namespace p07_FixEmails
{
    using System;
    using System.Collections.Generic;

    public class FixEmails
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string,string> emailbook = new Dictionary<string, string>();

            while (input !="stop")
            {
                string name = input;
                string email = Console.ReadLine();
                string emailLower = email.ToLower();

                if (!emailLower.EndsWith("us") && !emailLower.EndsWith("uk"))
                {
                    emailbook.Add(name,email);
                }
                
                input = Console.ReadLine();
            }

            foreach (var man in emailbook)
            {
                Console.WriteLine($"{man.Key} -> {man.Value}");
            }
        }
    }
}
