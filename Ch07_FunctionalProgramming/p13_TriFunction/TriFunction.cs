namespace p13_TriFunction
{
    using System;

    public class TriFunction
    {
        public static void Main()
        {
            int border = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> isWinner = IsWinner;
            Action<string> print = s => Console.WriteLine(s);

            Winner(names, border, isWinner, print);
        }
        
        private static void Winner(string[] names, int border, Func<string, int, bool> isWinner, Action<string> print)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (isWinner(names[i], border))
                {
                    print(names[i]);
                    return;
                }
            }
        }

        private static bool IsWinner(string name, int border)
        {
            int sum = 0;
            foreach (var ch in name)
            {
                sum += ch;
            }
            return (sum >= border) ? true : false;
        }
    }
}
