using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace number_58
{
    public class Student
    {
        public string Surname { get; set; }
        public string Initials { get; set; }
        public int[] Points { get; set; }
        public int School { get; set; }

        public Student(string source)
        {
            var array = source.Split(' ');
            Surname = array[0];
            Initials = array[1];
            Points = new int[3];
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i] = int.Parse(array[2 + i]);
            }
            School = int.Parse(array[5]);

        }

        public override string ToString()
        {
            return $"{Surname} {Initials}\t{Points[0]}\t{Points[1]}\t{Points[2]}\t{School}";
        }
    }

    class Program
    {
        public static List<Student> GetStudents()
        {
            var directory = @"D:\ITIS\Programms\Repos\Krylov_Anton_11-707\SPRING2018\LINQ_Tasks\Data";
            var list = new List<string>();
            var students = new List<Student>();
            using (StreamReader sr = new StreamReader($"{directory}\\LINQ_Obj58.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());
            foreach (var student in list)
            {
                students.Add(new Student(student));
            }
            return students;
        }

        static void Main()
        {
            var students = GetStudents();
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var answer = students
                .Where(student => student.Points.Any(point => point < 50))
                .GroupBy(student => student.School, (school, studs) =>
                    new
                    {
                        school,
                        studs = studs
                            .OrderBy(student => student.Surname)
                            .ThenBy(student => student.Initials)
                            .Take(3)
                    })
                .SelectMany(group => group.studs)
                .OrderBy(student => student.Surname)
                .ThenBy(student => student.Initials)
                .ThenBy(student => student.School);

            if (answer.Any())
                foreach (var item in answer)
                    Console.WriteLine($"{item.Surname} {item.Initials} {item.School}");
            else
                Console.WriteLine("Требуемые учащиеся не найдены");
        }
    }
}