using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2_1
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            int sum=0;
            for (int i = 1; i < n; i++)
                sum += i;
            Console.WriteLine(sum);
        }
    }
}
