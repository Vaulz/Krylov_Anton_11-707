using System;

namespace part1_8
{
    class Program
    {

        // Часть 1 №8
        // Вычислить сумму ряда с заданной точностью и определить, на каком шаге начинает достигаться эта точность.
        // sinh(x)
        // Крылов Антон 11-707

        static void Main()
        {
            double x = double.Parse(Console.ReadLine());
            double eps = 0.0000000000000001;
            double result = PowerOfExp(x, eps, out int iterations);
            Console.WriteLine($"Результат вычислений: \t{result}. \nТабличное значение: \t{Math.Sinh(x)}. \nЗаданная точность достигнута на {iterations} шаге.");
        }
        static double PowerOfExp(double x, double eps, out int iterations)
        {
            double item = x, sinh = x;
            int k = 1;
            while (item > eps)
            {
                item *=x*x/(2*k*(2*k+1));
                sinh += item;
                k++;
            }
            iterations = k - 1;
            return sinh;
        }
    }
}