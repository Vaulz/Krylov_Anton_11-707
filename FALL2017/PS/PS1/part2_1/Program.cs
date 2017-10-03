using System;

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
