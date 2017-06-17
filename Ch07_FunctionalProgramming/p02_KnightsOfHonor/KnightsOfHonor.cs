namespace p02_KnightsOfHonor
{
    using System;
    using System.Linq;

    public class KnightsOfHonor
    {
        public static void Main()
        {
            // Variant with Action<T>
            Action<string> printer = word => Console.WriteLine($"Sir {word}");

            Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                              .ToList()
                              .ForEach(printer);


            // Variant with Func<T,TResult>
            //Func<string, string> printWord = word =>
            //{
            //    Console.WriteLine($"Sir {word}");
            //    return word;
            //};

            //Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(printWord).ToList();
        }
    }
}
