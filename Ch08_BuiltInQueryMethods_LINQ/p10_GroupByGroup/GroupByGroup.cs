namespace p10_GroupByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Person
    {
        public string Name { get; set; }
        public int Group { get; set; }

        public Person(string name, int group)
        {
            this.Name = name;
            this.Group = group;
        }
    }


    public class GroupByGroup
    {
        public static void Main()
        {
            List<Person> students = new List<Person>();

            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                string[] input = inputLine.Split();
                string name = $"{input[0]} {input[1]}";
                int group = int.Parse(input[2]);

                students.Add(new Person(name, group));

                inputLine = Console.ReadLine();
            }

            students
                .GroupBy(p => p.Group)
                .OrderBy(x => x.Key)
                .ToList()
                .ForEach(gr => Console.WriteLine($"{gr.Key} - {string.Join(", ", gr.Select(n=>n.Name))}"));


            //// Variant with separate print (from video)
            //foreach (var group in grouped)
            //{
            //    Console.WriteLine(group.Key + " - ");
            //    var sb = new StringBuilder();
            //    foreach (var person in group)
            //    {
            //        sb.Append(person.Name).Append(", ");
            //    }
            //    sb.Length -= 2;           // cut last ", "
            //    Console.WriteLine(sb);
            //}

        }
    }
}
