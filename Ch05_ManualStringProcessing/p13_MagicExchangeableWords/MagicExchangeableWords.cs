namespace p13_MagicExchangeableWords
{
    using System;
    using System.Collections.Generic;

    public class MagicExchangeableWords
    {
        public static void Main()
        {
            string[] number = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string num1 = "";       // num1 is longer string
            string num2 = "";       // num2 is equal or shorter

            if (number[0].Length >= number[1].Length)
            {
                num1 = number[0];
                num2 = number[1];
            }
            else
            {
                num1 = number[1];
                num2 = number[0];
            }

            Console.WriteLine(IsExchangeable(num1, num2) ? "true" : "false");

        }


        public static bool IsExchangeable(string str1, string str2)
        {
            Dictionary<char, char> dict = new Dictionary<char, char>();

            int len1 = str1.Length;
            int len2 = str2.Length;
            int sum = 0;

            for (int i = 0; i < len2; i++)
            {
                char curKey = str2[i];
                char curVal = str1[i];

                if (dict.ContainsKey(curKey))
                {
                    if (!(dict[curKey] == curVal))
                    {
                        return false;       // contains key with another value
                    }
                }
                else if (dict.ContainsValue(curVal))
                {
                    return false;       // doesn't contains key, but contains value
                }
                else
                {
                    dict.Add(curKey, curVal);
                }
            }

            for (int i = len2; i < len1; i++)
            {
                if (!dict.ContainsValue(str1[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
