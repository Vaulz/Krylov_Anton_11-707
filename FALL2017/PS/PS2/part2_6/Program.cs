using System;


namespace part2_6
{
    class Program
    {

        // Часть 2 №6
        // Вычислить значение числа Пи через биномиальные коэффициенты №2 
        // Крылов Антон 11-707

        static void Main()
        {
            double eps = 0.0000000000000001;
            double result = NumberPI(eps, out int iterations);
            Console.WriteLine($"Результат вычислений: \t{result}. \nТабличное значение: \t{Math.PI}. \nЗаданная точность достигнута на {iterations} шаге.");
        }
        static double NumberPI(double eps, out int iterations)
        {
            double item = -6, pi = -6;
            int k = 1;
            while (Math.Abs(item) > eps)
            {
                item *=((50*k-6)*k*(2*k-1))/((50*k-56)*3*(3*k-1.0)*(3*k-2));
                pi += item;
                k++;

            }
            iterations = k;
            return pi;
        }
    }
}
