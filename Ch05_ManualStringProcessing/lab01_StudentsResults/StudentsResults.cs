namespace lab01_StudentsResults
{
    using System;

    public class StudentsResults
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            string headerRow = string.Format("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP",
                "Average");
            Console.WriteLine(headerRow);

            char[] separators = new[] {' ', '-', ',', '\t', '\r', '\n', '!'};

            for (int i = 0; i < num; i++)
            {
                GetAndPrintStudentData(separators);
            }
        }

        private static void GetAndPrintStudentData(char[] separators)
        {
            string[] student = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string name = student[0];
            double cadv = double.Parse(student[1]);
            double coop = double.Parse(student[2]);
            double advoop = double.Parse(student[3]);
            double average = (cadv + coop + advoop) / 3.0;

            string studentRow = string.Format($"{name,-10}|{cadv,7:f2}|{coop,7:f2}|{advoop,7:f2}|{average,7:f4}|");
            Console.WriteLine(studentRow);
        }
    }
}
