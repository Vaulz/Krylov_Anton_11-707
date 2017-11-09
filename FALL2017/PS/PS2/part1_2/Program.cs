using System;

namespace part1_2
{
    class Program
    {

        // Часть 1 №2
        // Вычислить сумму ряда с заданной точностью и определить, на каком шаге начинает достигаться эта точность.
        // e^(1/x)
        // Крылов Антон 11-707

        static void Main()
        {
            double x = double.Parse(Console.ReadLine());
            double eps = 0.0000000000000001;
            double result = PowerOfExp(x, eps, out int iterations);
            Console.WriteLine($"Результат вычислений:  {result}. \nЗаданная точность достигнута на {iterations} шаге.");
        }
        static double PowerOfExp(double x, double eps, out int iterations)
        {
            double item = 1,exp=1;
            int k = 1;
            while (item>eps)
            {
                item *= (2 * k * x + 1) / (x * x * (2 * k - 1) * 2 * k * (2*(k - 1) * x + 1));
                exp += item;
                k++;
            }
            iterations = k - 1;
            return exp;
        }
    }
}
