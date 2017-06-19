using System.Runtime.InteropServices;

namespace p11_StudentsJoinedToSpecialties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StudentSpecialty
    {
        public string SpecialtyName { get; set; }
        public int FacultyNumber { get; set; }

        public StudentSpecialty(string specialtyName, int facultyNumber)
        {
            this.SpecialtyName = specialtyName;
            this.FacultyNumber = facultyNumber;
        }
    }


    public class Student
    {
        public string StudentName { get; set; }
        public int FacultyNumber { get; set; }

        public Student(string studentName, int facultyNumber)
        {
            this.StudentName = studentName;
            this.FacultyNumber = facultyNumber;
        }
    }


    public class StudentsJoinedToSpecialties
    {
        public static void Main()
        {

            List<Student> students = new List<Student>();
            List<StudentSpecialty> specialties = new List<StudentSpecialty>();

            string input;

            while ((input = Console.ReadLine()) != "Students:")
            {
                string[] inputParts = input.Split();
                int facultyNumber = int.Parse(inputParts[2]);
                string specialtyName = inputParts[0] + " " + inputParts[1];

                specialties.Add(new StudentSpecialty(specialtyName, facultyNumber));
            }


            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputParts = input.Split();
                int facultyNumber = int.Parse(inputParts[0]);
                string studentName = inputParts[1] + " " + inputParts[2];

                students.Add(new Student(studentName, facultyNumber));
            }


            specialties
                .Join(students, sp => sp.FacultyNumber, 
                                st => st.FacultyNumber, 
                                (sp, st) => new
                                    {
                                        Name = st.StudentName,
                                        FacNum = st.FacultyNumber,
                                        Specialty = sp.SpecialtyName
                                    })
                .OrderBy(n => n.Name)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} {x.FacNum} {x.Specialty}"));
        }
    }
}
