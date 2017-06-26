namespace p04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Patient
    {
        public string Department { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public int BedNum { get; set; }

        public Patient(string department, string doctorName, string patientName, int bedNum)
        {
            this.Department = department;
            this.DoctorName = doctorName;
            this.PatientName = patientName;
            this.BedNum = bedNum;
        }
    }

    public class Hospital
    {
        public static void Main()
        {
            List<Patient> hospital = new List<Patient>();
            string input;

            while ((input = Console.ReadLine()) != "Output")
            {
                string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 4)
                {
                    string departmentIn = parts[0];
                    string doctorNameIn = parts[1] + " " + parts[2];
                    string patientNameIn = parts[3];
                    int bedNumIn;

                    if (hospital.Count(x => x.Department == departmentIn) == 0)
                    {
                        bedNumIn = 1;
                    }
                    else
                    {
                        bedNumIn = hospital.Where(x => x.Department == departmentIn).Max(x => x.BedNum) + 1;
                    }

                    if (bedNumIn <= 60)
                    {
                        hospital.Add(new Patient(departmentIn, doctorNameIn, patientNameIn, bedNumIn));
                    }
                }
            }


            while ((input = Console.ReadLine()) != "End")
            {
                string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 1)
                {
                    Print(hospital, parts[0]);
                }
                else if (parts.Length == 2)
                {
                    int room = 0;
                    if (int.TryParse(parts[1], out room))
                    {
                        Print(hospital, parts[0], room);
                    }
                    else
                    {
                        Print(hospital, parts[0], parts[1]);
                    }
                }
            }
        }

        private static void Print(List<Patient> hospital, string department)
        {
            foreach (var patient in hospital.Where(x => x.Department == department))
            {
                Console.WriteLine(patient.PatientName);
            }
        }

        private static void Print(List<Patient> hospital, string department, int room)
        {
            int bedMin = (room - 1) * 3 + 1;        // Room 3 => 7
            int bedMax = room * 3;                  // Room 3 => 9
            foreach (var patient in hospital.Where(x => x.Department == department)
                                            .Where(b => b.BedNum >= bedMin && b.BedNum <= bedMax)
                                            .OrderBy(x => x.PatientName))
            {
                Console.WriteLine(patient.PatientName);
            }
        }

        private static void Print(List<Patient> hospital, string doctorF, string doctorL)
        {
            string fullName = doctorF + " " + doctorL;
            foreach (var patient in hospital.Where(x => x.DoctorName == fullName).OrderBy(x => x.PatientName))
            {
                Console.WriteLine(patient.PatientName);
            }

        }

    }
}
