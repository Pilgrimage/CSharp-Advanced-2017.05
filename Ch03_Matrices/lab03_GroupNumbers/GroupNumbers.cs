namespace lab03_GroupNumbers
{
    using System;
    using System.Linq;

    public class GroupNumbers
    {
        public static void Main()
        {
            // This solution is prity sly !!!

            //var watch = System.Diagnostics.Stopwatch.StartNew();

            int[] input = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string residue0 = "";
            string residue1 = "";
            string residue2 = "";

            foreach (var num in input)
            {
                int rest = num % 3;
                if (rest == 0)
                {
                    residue0 = residue0 + num.ToString() + " ";
                }
                else if (rest == 1 || rest == -1)
                {
                    residue1 = residue1 + num.ToString() + " ";
                }
                else
                {
                    residue2 = residue2 + num.ToString() + " ";
                }
            }

            Console.WriteLine(residue0.TrimEnd());
            Console.WriteLine(residue1.TrimEnd());
            Console.WriteLine(residue2.TrimEnd());

            //watch.Stop();
            //Console.WriteLine(watch.ElapsedTicks);
        }
    }
}
