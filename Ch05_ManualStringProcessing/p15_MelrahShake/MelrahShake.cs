namespace p15_MelrahShake
{
    using System;

    public class MelrahShake
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = Console.ReadLine();

            while (true)
            {
                int firstIndex = text.IndexOf(pattern);
                int lastIndex = text.LastIndexOf(pattern);

                if (firstIndex == -1 || firstIndex == lastIndex)
                {
                    break;
                }

                text = text.Remove(lastIndex, pattern.Length);
                text = text.Remove(firstIndex, pattern.Length);
                Console.WriteLine("Shaked it.");

                if (pattern.Length == 1)
                {
                    break;
                }

                pattern = pattern.Remove(pattern.Length / 2, 1);
            }

            Console.WriteLine("No shake." + Environment.NewLine + text);
        }
    }
}
