using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace number_3
{
    public class FitnesClient
    {
        public int Code { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Duration { get; set; }

        public FitnesClient(string source)
        {
            var tmp = source.Split(' ');
            var array = Array.ConvertAll(tmp, Convert.ToInt32);
            Year = array[1];
            Month = array[0];
            Duration = array[2];
            Code = array[3];
        }

        public override string ToString()
        {
            return $"{Code}\t{Year}\t{Month}\t{Duration}";
        }
    }
    class Program
    {
        public static List<FitnesClient> GetData()
        {
            var directory = @"D:\ITIS\Programms\Repos\Krylov_Anton_11-707\SPRING2018\LINQ_Tasks\Data";
            var list = new List<string>();
            var clients = new List<FitnesClient>();
            using (StreamReader sr = new StreamReader($"{directory}\\LINQ_Obj3.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());
            foreach (var client in list)
            {
                clients.Add(new FitnesClient(client));
            }
            return clients;
        }

        static void Main()
        {
            var source = GetData();       
            foreach (var client in source)
            {
                Console.WriteLine($"{client} ");
            }
            Console.WriteLine();

            var durationByYear = source
                .GroupBy(client => client.Year,
                    (year, duration) => new { year, duration = duration.Sum(client => client.Duration) });

            var answer = durationByYear
                .Where(client => client.duration == durationByYear.Min(duration => duration.duration))
                .OrderBy(client => client.year)
                .First();

            Console.WriteLine($"{answer.year} {answer.duration}");
        }
    }
}