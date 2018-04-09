using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace number_14
{
    public class Enrollee
    {
        public string Surname { get; set; }
        public int Year { get; set; }
        public int School { get; set; }

        public Enrollee(string source)
        {
            var array = source.Split(' ');
            Surname = array[0];
            Year = int.Parse(array[1]);
            School = int.Parse(array[2]);
        }

        public override string ToString()
        {
            return $"{Year}\t{School}\t{Surname}";
        }
    }

    class Program
    {
        public static List<Enrollee> GetEnrollees()
        {
            var directory = @"D:\ITIS\Programms\Repos\Krylov_Anton_11-707\SPRING2018\LINQ_Tasks\Data";
            var list = new List<string>();
            var clients = new List<Enrollee>();
            using (StreamReader sr = new StreamReader($"{directory}\\LINQ_Obj14.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());
            foreach (var client in list)
            {
                clients.Add(new Enrollee(client));
            }
            return clients;
        }

        static void Main()
        {
            var enrollees = GetEnrollees();
            foreach (var enrollee in enrollees)
            {
                Console.WriteLine($"{enrollee}");
            }
            Console.WriteLine();

            var group = enrollees
                .GroupBy(enrolle => enrolle.Year, (year, count) => new { year, count = count.Count() });

            var ans = group.Where(x => x.count == group.Max(y => y.count));

            Console.WriteLine($"{ans.First().count} {ans.Count()}");
        }
    }
}