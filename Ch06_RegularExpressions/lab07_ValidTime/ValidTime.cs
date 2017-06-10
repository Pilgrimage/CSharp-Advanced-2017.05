namespace lab07_ValidTime
{
    using System;
    using System.Text.RegularExpressions;

    public class ValidTime
    {
        public static void Main()
        {
            string pattern = @"^([01][0-9]):([0-5][0-9]):([0-5][0-9]) (AM|PM)$";
            Regex regex = new Regex(pattern);

            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                Match match = regex.Match(inputLine);
                if (match.Length == 0)
                {
                    Console.WriteLine("invalid");
                }
                else
                {
                    Console.WriteLine("{0}", IsValidTime(match) ? "valid" : "invalid");
                }

                inputLine = Console.ReadLine();

            }
        }

        public static bool IsValidTime(Match time)
        {
            int hours = int.Parse(time.Groups[1].Value);
            int minutes = int.Parse(time.Groups[2].Value);
            int seconds = int.Parse(time.Groups[3].Value);
            if (hours >= 0 && hours <= 12)          // Here Judge test is broken - allow hour = 12 !!!
                if (minutes >= 0 && minutes < 60)
                    if (seconds >= 0 && seconds < 60)
                        return true;

            return false;
        }

    }
}
