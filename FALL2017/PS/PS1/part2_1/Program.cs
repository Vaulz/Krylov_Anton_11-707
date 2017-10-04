using System;

namespace part2_1
{
    class Program
    {

        // Часть 2 №1
        // По заданному натуральному числу вычислить сумму чисел, меньших его
        // Крылов Антон 11-707

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
