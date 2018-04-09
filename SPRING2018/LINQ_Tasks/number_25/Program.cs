using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace number_25
{
    public class Inhabitant
    {
        public string Surname { get; set; }
        public double Debt { get; set; }
        public int Apartment { get; set; }
        public int Floor { get; set; }

        public Inhabitant(string source)
        {
            var array = source.Split(' ');
            Debt = double.Parse(array[0]);
            Apartment = int.Parse(array[1]);
            Surname = array[2];
            Floor = ((Apartment - 1) % 36) / 4 + 1;

        }
        public override string ToString()
        {
            return $"{Debt}\t\t{Apartment}\t{Surname}";
        }
    }

    class Program
    {
        public static List<Inhabitant> GetInhabitants()
        {
            var directory = @"D:\ITIS\Programms\Repos\Krylov_Anton_11-707\SPRING2018\LINQ_Tasks\Data";
            var list = new List<string>();
            var inhabitants = new List<Inhabitant>();
            using (StreamReader sr = new StreamReader($"{directory}\\LINQ_Obj25.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());
            foreach (var inhabitant in list)
            {
                inhabitants.Add(new Inhabitant(inhabitant));
            }
            return inhabitants;
        }


        static void Main()
        {
            var inhabitants = GetInhabitants();
            foreach (var inhabitant in inhabitants)
            {
                Console.WriteLine(inhabitant);
            }
            Console.WriteLine();

            var ans = inhabitants
                .GroupBy(inhabitant => (inhabitant.Apartment - 1) / 36 + 1,
                    (entrance, indebtedness) => new
                    {
                        entrance,
                        indebtedness = indebtedness.Sum(y => y.Debt)
                    });

            var answer = ans.Where(x => Math.Abs(x.indebtedness - ans.Max(y => y.indebtedness)) < 0.001);

            Console.WriteLine(answer.First().entrance);
        }
    }
}