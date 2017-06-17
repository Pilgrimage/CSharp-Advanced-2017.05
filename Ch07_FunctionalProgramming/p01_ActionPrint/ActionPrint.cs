using System.Runtime.InteropServices;

namespace p01_ActionPrint
{
    using System;
    using System.Linq;

    public class ActionPrint
    {
        public static void Main()
        {
            //// Variant with Action<T>
            //Action<string> printer = word => Console.WriteLine(word);

            //Console.ReadLine().Split(new char[] {' ' }, StringSplitOptions.RemoveEmptyEntries)
            //                  .ToList()
            //                  .ForEach(printer);


            // Variant with Func<T,TResult>
            //Func<string, string> printWord = word => 
            //                                        {
            //                                            Console.WriteLine(word);
            //                                            return word;
            //                                        };

            //Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(printWord).ToList();


            // Variant 3
            string[] names = Console.ReadLine().Split();

            Action<string> printName = s => Console.WriteLine(s);
            Action<string> printNameWithPrefix = s => Console.WriteLine($"Sir {s}");

            PrintAllNames(names, printName);
            //PrintAllNames(names, printNameWithPrefix);

        }

        private static void PrintAllNames(string[] names, Action<string> print)
        {
            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
