using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace number_69
{
    public class Data
    {
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string Subject { get; set; }
        public int Grade { get; set; }
        public int Mark { get; set; }

        public Data(string source)
        {
            var array = source.Split(' ');
            Grade = int.Parse(array[0]);
            Subject = array[1];
            Surname = array[2];
            Initials = array[3];
            Mark = int.Parse(array[4]);
        }

        public override string ToString()
        {
            return $"{Grade}\t{Subject}\t\t\t{Surname} {Initials}\t{Mark}";
        }
    }

    class Program
    {
        public static List<Data> GetData()
        {
            var directory = @"D:\ITIS\Programms\Repos\Krylov_Anton_11-707\SPRING2018\LINQ_Tasks\Data";
            var list = new List<string>();
            var students = new List<Data>();
            using (StreamReader sr = new StreamReader($"{directory}\\LINQ_Obj69.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());

            foreach (var data in list)
            {
                students.Add(new Data(data));
            }
            return students;
        }

        static void Main()
        {
            var datas = GetData();
            foreach (var item in datas)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var ans = datas
                .Where(data => data.Mark == 2)
                .GroupBy((data => data.Grade), (grade, students) => new
                {
                    grade,
                    students,
                    max = students.GroupBy(student => new { student.Surname, student.Initials },
                        (student, count) => new { student, count = count.Count() }).Max(item => item.count)
                })
                .Select(item => new
                {
                    students = item.students
                        .GroupBy(data => new { data.Surname, data.Initials }, (key, marksCount) => new { key, marksCount = marksCount.Count() })
                        .Where(item2 => item.max == item2.marksCount)
                        .Select(group => new
                        {
                            surname = group.key.Surname,
                            initials = group.key.Initials,
                            group.marksCount
                        })
                })
                .SelectMany(group => group.students)
                .OrderBy(student => student.surname)
                .ThenBy(student => student.initials);

            if (ans.Any())
                foreach (var item in ans)
                    Console.WriteLine($"{item.surname} {item.initials} {item.marksCount}");
            else
                Console.WriteLine("Требуемые учащиеся не найдены");
        }
    }
}