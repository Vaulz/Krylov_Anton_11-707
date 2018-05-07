using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace number_47
{
    public class PetrolStation
    {
        public string Company { get; set; }
        public int Price { get; set; }
        public int Brand { get; set; }
        public string Street { get; set; }

        public PetrolStation(string source)
        {
            var array = source.Split(' ');
            Company = array[0];
            Price = int.Parse(array[1]);
            Brand = int.Parse(array[2]);
            Street = array[3];

        }

        public override string ToString()
        {
            return $"{Company}\t{Price}\t{Brand}\t{Street}";
        }
    }

    class Program
    {
        public static List<PetrolStation> GetPetrolStations()
        {
            var directory = @"D:\ITIS\Programms\Repos\Krylov_Anton_11-707\SPRING2018\LINQ_Tasks\Data";
            var list = new List<string>();
            var petrolStations = new List<PetrolStation>();
            using (StreamReader sr = new StreamReader($"{directory}\\LINQ_Obj47.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());
            foreach (var petrolStation in list)
            {
                petrolStations.Add(new PetrolStation(petrolStation));
            }
            return petrolStations;
        }

        static void Main()
        {
            var petrolStations = GetPetrolStations();
            petrolStations = petrolStations.OrderBy(x => x.Street).ThenBy(y => y.Company).ToList();
            foreach (var item in petrolStations)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var answer = petrolStations.GroupBy(station => new { station.Street, station.Company },
                    (station, count) => new { station, count = count.Count() })
                .Where(station => station.count >= 2)
                .OrderBy(petrolStation => petrolStation.station.Company)
                .ThenBy(petrolStation => petrolStation.station.Street);

            if (answer.Any())
                foreach (var item in answer)
                    Console.WriteLine($"{item.station.Company}\t{item.station.Street} {item.count}");
            else
                Console.WriteLine("Нет");
        }
    }
}