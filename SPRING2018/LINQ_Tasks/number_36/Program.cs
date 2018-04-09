using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace number_36
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
            using (StreamReader sr = new StreamReader($"{directory}\\LINQ_Obj36.txt"))
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

            var answer = inhabitants
                .Where(inhab => inhab.Debt <= inhabitants
                                    .Where(item => item.Floor == inhab.Floor)
                                    .Average(inhabitant => inhabitant.Debt > 0 ? inhabitant.Debt : 0))
                .OrderBy(inhabitant => inhabitant.Floor)
                .ThenBy(inhabitant => inhabitant.Debt);

            foreach (var item in answer)
            {
                Console.WriteLine($"Floor: {item.Floor} {item.Debt}");
            }
        }
    }
}
