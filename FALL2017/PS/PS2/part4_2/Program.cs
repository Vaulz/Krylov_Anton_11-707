using System;

namespace part4_1
{
    class Program
    {
        static void Main()
        {
            double a = 0.5;
            double b = 2;
            int n = 10000000;
            Console.WriteLine("Integral №2 by using :");
            Console.WriteLine($"1. Method of left rectangles  : {GetLeftRectangleIntegral(n, a, b)}");
            Console.WriteLine($"2. Method of right rectangles : {GetRightRectangleIntegral(n, a, b)}");
            Console.WriteLine($"3. Method of trapeze : \t        {GetTrapezeIntegral(n, a, b)}");
            Console.WriteLine($"4. Method of Simpson : \t        {GetSimpsonIntegral(n, a, b)}");
            Console.WriteLine($"5. Method of Monte-Carlo : \t{GetMonteCarloIntegral(n, a, b)}");
            Console.WriteLine("Approximate value of integral : 0,308488");
        }
        static double Function(double argument)
        {
            return Math.Cos(1/argument + argument*argument/4);
        }
        static double GetLeftRectangleIntegral(int n, double a, double b)
        {
            double sum = 0;
            double segment = (b - a) / n;
            for (int i = 0; i < n; i++)
            {
                sum += Function(a + i * segment);
            }
            sum *= segment;
            return sum;
        }
        static double GetRightRectangleIntegral(int n, double a, double b)
        {
            double sum = 0;
            double segment = (b - a) / n;
            for (int i = 0; i < n; i++)
            {
                sum += Function(b - i * segment);
            }
            sum *= segment;
            return sum;
        }
        static double GetTrapezeIntegral(int n, double a, double b)
        {
            double sum = 0;
            double segment = (b - a) / n;
            for (int i = 0; i < n - 1; i++)
            {
                sum += Function(a + i * segment) + Function(a + (i + 1) * segment);
            }
            sum *= 1.0 / 2 * segment;
            return sum;
        }
        static double GetSimpsonIntegral(int n, double a, double b)
        {
            double sum = Function(a) + Function(b);
            double segment = (b - a) / n;
            for (int i = 1; i < n - 1; i++)
            {
                sum += (i % 2 + 1) * 2 * Function(a + i * segment);
            }
            sum *= segment / 3;
            return sum;
        }
        static double GetMonteCarloIntegral(int n, double a, double b)
        {
            double sum = 0;
            double segment = (b - a) / n;
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                sum += Function(a + random.Next(0, n) * segment);
            }
            sum *= segment;
            return sum;
        }
    }
}