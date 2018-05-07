using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace number_75
{
    public class Product
    {
        public string Name { get; set; }
        public string VendorCode { get; set; }
        public int Price { get; set; }

        public Product(string source)
        {
            var array = source.Split(' ');
            Price = int.Parse(array[0]);
            VendorCode = array[1];
            Name = array[2];
        }

        public override string ToString()
        {
            return $"{Price}\t{VendorCode}\t{Name}";
        }
    }

    public class Order
    {
        public string Country { get; set; }
        public string VendorCode { get; set; }
        public string Category { get; set; }

        public Order(string source)
        {
            var array = source.Split(' ');
            Country = array[1];
            VendorCode = array[0];
            Category = array[2];
        }

        public override string ToString()
        {
            return $"{VendorCode}\t{Country}\t{Category}";
        }
    }

    public class SequenceReader
    {
        public static List<Product> GetProducts(int size)
        {
            var directory = @"D:\ITIS\Programms\Repos\Krylov_Anton_11-707\SPRING2018\LINQ_Tasks\Data";

            var list = new List<string>();

            var products = new List<Product>();

            using (StreamReader sr = new StreamReader($"{directory}\\LINQ_Obj75D.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());

            foreach (var product in list)
            {
                products.Add(new Product(product));
            }

            return products;
        }

        public static List<Order> GetProductsFrom(int size)
        {
            var directory = @"D:\ITIS\Programms\Repos\Krylov_Anton_11-707\SPRING2018\LINQ_Tasks\Data";

            var list = new List<string>();

            var productFroms = new List<Order>();

            using (StreamReader sr = new StreamReader($"{directory}\\LINQ_Obj75B.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());

            foreach (var product in list)
            {
                productFroms.Add(new Order(product));
            }

            return productFroms;
        }
    }

    class Program
    {
        static void Main()
        {
            var products = SequenceReader.GetProducts(10);

            var orders = SequenceReader.GetProductsFrom(10);

            foreach (var item in products)
                Console.WriteLine(item);
            Console.WriteLine();

            foreach (var item in orders)
                Console.WriteLine(item);
            Console.WriteLine();

            var answer = orders
                .Join(products, x => x.VendorCode, x => x.VendorCode, (x, y) => new
                {
                    x.Category,
                    x.VendorCode,
                    y.Name
                })
                .GroupBy(x => new { x.Category, x.Name })
                .Select(x => new
                {
                    x.Key.Name,
                    x.Key.Category,
                    Count = x.Count()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Category);

            foreach (var item in answer)
                Console.WriteLine($"{item.Name} {item.Category} {item.Count}");
            Console.WriteLine();
        }
    }
}