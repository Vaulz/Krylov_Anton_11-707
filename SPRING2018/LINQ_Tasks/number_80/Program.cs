using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace number_80
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

    public class Purchases
    {
        public string Name { get; set; }
        public string VendorCode { get; set; }
        public int Code { get; set; }

        public Purchases(string source)
        {
            var array = source.Split(' ');
            Code = int.Parse(array[0]);
            VendorCode = array[2];
            Name = array[1];
        }

        public override string ToString()
        {
            return $"{Code}\t{VendorCode}\t{Name}";
        }
    }

    public class SequenceReader
    {
        public static List<Product> GetProducts(int size)
        {
            var directory = @"D:\ITIS\Programms\Repos\Krylov_Anton_11-707\SPRING2018\LINQ_Tasks\Data";

            var list = new List<string>();

            var products = new List<Product>();

            using (StreamReader sr = new StreamReader($"{directory}\\LINQ_Obj80D.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());

            foreach (var product in list)
            {
                products.Add(new Product(product));
            }

            return products;
        }

        public static List<Purchases> GetPurchases(int size)
        {
            var directory = @"D:\ITIS\Programms\Repos\Krylov_Anton_11-707\SPRING2018\LINQ_Tasks\Data";

            var list = new List<string>();

            var purchases = new List<Purchases>();

            using (StreamReader sr = new StreamReader($"{directory}\\LINQ_Obj80E.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());

            foreach (var purchase in list)
            {
                purchases.Add(new Purchases(purchase));
            }

            return purchases;
        }

    }

    class Program
    {
        static void Main()
        {
            var products = SequenceReader.GetProducts(10);

            var purchases = SequenceReader.GetPurchases(10);

            foreach (var item in products)
                Console.WriteLine(item);
            Console.WriteLine();

            foreach (var item in purchases)
                Console.WriteLine(item);
            Console.WriteLine();

            var answer = products
                .GroupJoin(purchases, x => new { x.Name, x.VendorCode }, x => new { x.Name, x.VendorCode },
                    (product, gj) => new { product.Name, product.VendorCode, Total = gj.Count() * product.Price })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.VendorCode);

            foreach (var item in answer)
                Console.WriteLine($"{item.Name} {item.VendorCode} {item.Total}");
            Console.WriteLine();
        }
    }
}