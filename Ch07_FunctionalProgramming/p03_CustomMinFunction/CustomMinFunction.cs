namespace p03_CustomMinFunction
{
    using System;
    using System.Linq;

    public class CustomMinFunction
    {
        public static void Main()
        {

            double[] input = Console.ReadLine()
                            .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                            .Select(double.Parse)
                            .ToArray();

            Func<double[], double> getMin = GetMinValue;
            Action<double> printer = num => Console.WriteLine(num);

            PrintMinimalValue(input,getMin,printer);
        }


        private static double GetMinValue(double[] nums)
        {
            double minNum = double.MaxValue;
            foreach (var num in nums)
            {
                minNum = num < minNum ? num : minNum;
            }
            return minNum;
        }

        private static void PrintMinimalValue(
            double[] input,
            Func<double[], double> getMin,
            Action<double> printer)
        {
            printer(getMin(input));
        }

    }
}
