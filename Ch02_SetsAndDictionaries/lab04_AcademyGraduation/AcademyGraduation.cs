namespace lab04_AcademyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AcademyGraduation
    {
        public static void Main()
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            SortedDictionary<string,double> studentsScores = new SortedDictionary<string, double>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string studentName = Console.ReadLine();
                double averageScores = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray()
                    .Average();
                studentsScores.Add(studentName,averageScores);
            }

            foreach (var studentsScore in studentsScores)
            {
                Console.WriteLine($"{studentsScore.Key} is graduated with {studentsScore.Value}");
            }
        }
    }
}
