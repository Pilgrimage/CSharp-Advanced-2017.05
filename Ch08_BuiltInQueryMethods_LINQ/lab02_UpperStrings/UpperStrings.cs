namespace lab02_UpperStrings
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class UpperStrings
    {
        public static void Main()
        {
            Console.ReadLine()
                .ToUpper()
                .Split(';')
                .ToList()
                .ForEach(s => Console.WriteLine(s));


            //// Variant 2
            //List<string> words = Console.ReadLine()
            //                        .Split()
            //                        .ToList();

            //words.Select(w=>w.ToUpper())
            //     .ToList()
            //     .ForEach(w => Console.WriteLine(w + " "));
        }
    }
}
