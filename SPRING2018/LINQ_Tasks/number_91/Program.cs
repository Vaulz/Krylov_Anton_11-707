using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace number_91
{
    class Program
    {
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

        public class Customer
        {
            public int Year { get; set; }
            public int Code { get; set; }
            public string Street { get; set; }

            public Customer(string source)
            {
                var array = source.Split(' ');
                Year = int.Parse(array[0]);
                Code = int.Parse(array[1]);
                Street = array[2];
            }

            public override string ToString()
            {
                return $"{Year}\t{Code}\t{Street}";
            }
        }

        public class SequenceReader
        {
            public static List<Purchases> GetPurchases(int size)
            {
                var directory = @"D:\ITIS\Programms\Repos\Krylov_Anton_11-707\SPRING2018\LINQ_Tasks\Data";

                var list = new List<string>();

                var purchases = new List<Purchases>();

                using (StreamReader sr = new StreamReader($"{directory}\\LINQ_Obj91E.txt"))
                    while (!sr.EndOfStream)
                        list.Add(sr.ReadLine());

                foreach (var purchase in list)
                {
                    purchases.Add(new Purchases(purchase));
                }

                return purchases;
            }

            public static List<Customer> GetCustomers(int size)
            {
                var directory = @"D:\ITIS\Programms\Repos\Krylov_Anton_11-707\SPRING2018\LINQ_Tasks\Data";

                var list = new List<string>();

                var customers = new List<Customer>();

                using (StreamReader sr = new StreamReader($"{directory}\\LINQ_Obj91A.txt"))
                    while (!sr.EndOfStream)
                        list.Add(sr.ReadLine());

                foreach (var customer in list)
                {
                    customers.Add(new Customer(customer));
                }

                return customers;
            }

            public static List<Order> GetProductsFrom(int size)
            {
                var directory = @"D:\ITIS\Programms\Repos\Krylov_Anton_11-707\SPRING2018\LINQ_Tasks\Data";

                var list = new List<string>();

                var orders = new List<Order>();

                using (StreamReader sr = new StreamReader($"{directory}\\LINQ_Obj91B.txt"))
                    while (!sr.EndOfStream)
                        list.Add(sr.ReadLine());

                foreach (var product in list)
                {
                    orders.Add(new Order(product));
                }
                return orders;
            }
        }

        static void Main()
        {
            var goods = SequenceReader.GetPurchases(10);

            var customers = SequenceReader.GetCustomers(10);

            var orders = SequenceReader.GetProductsFrom(10);

            foreach (var item in goods)
                Console.WriteLine(item);
            Console.WriteLine();

            foreach (var item in customers)
                Console.WriteLine(item);
            Console.WriteLine();

            foreach (var item in orders)
                Console.WriteLine(item);
            Console.WriteLine();

            var result = goods.Join(customers, x => x.Code, x => x.Code, (x, y) => new
                {
                    x.VendorCode,
                    y.Street
                }).Join(orders, x => x.VendorCode, x => x.VendorCode, (x, y) => new
                {
                    x.Street,
                    y.Category,
                })
                .GroupBy(x => new { x.Street, x.Category })
                .Select(x => new
                {
                    x.Key.Street,
                    x.Key.Category,
                    Count = x.Count()
                })
                .OrderBy(x => x.Street)
                .ThenBy(x => x.Category);

            foreach (var item in result)
                Console.WriteLine($"{item.Street} {item.Category} {item.Count}");
            Console.WriteLine();
        }
    }
}