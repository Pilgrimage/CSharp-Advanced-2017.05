namespace p08_CustomComparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class MyComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            //int x = 5;                    // new number
            //int y = 6;                    // number in collection (referent value)
            //int result = x.CompareTo(y);  // return -1, because x < y


            if (x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }
            else if (x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }
            else
            {
                //// Variant 1
                //if (x > y)
                //{
                //    return 1;
                //}
                //else if (x < y)
                //{
                //    return -1;
                //}
                //else
                //{
                //    // Ако сортираме в Dictionary и върнем "0", ще слее ключовете (зашото ключа трябва да е уникален).
                //    // Затова е по-добре да не връщаме "0", а да поправим условието, примерно if (x >= y)
                //    return 0;
                //}

                //// Variant 2
                //return (x >= y) ? 1 : -1;

                // Variant 3
                return x.CompareTo(y);      // Ascending order
                //return y.CompareTo(x);      // Descending order
            }
        }
    }


    public class CustomComparator
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Array.Sort(numbers, new MyComparer());  // We must to initialize new instance of our class "MyComparer"

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
