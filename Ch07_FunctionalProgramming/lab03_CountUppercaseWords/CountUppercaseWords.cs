namespace lab03_CountUppercaseWords
{
    using System;
    using System.Linq;

    public class CountUppercaseWords
    {
        public static void Main()
        {
            Func<string, bool> isFirstUpper = word => char.IsUpper(word[0]);

            Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(isFirstUpper)
                .ToList()
                .ForEach(word => Console.WriteLine(word));


            //// Interesting Solution from Ivo Kalidus
            //Console.WriteLine(string.Join("\n",
            //    Console.ReadLine()
            //    .Trim()
            //    .Split()
            //    .Where(x => x.StartsWith(char.ToUpper(x[0]).ToString()))));
        }
    }
}
