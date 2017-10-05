using System;

namespace Example2
{
    class Program
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double y;
            Console.WriteLine(Max(a, b, c) + SecondExpression(a, b));
        }

        static double Max(double a, double b, double c)
        {

            if ((a + b + c) / 3 > a * b * c)
                return (a + b + c) / 3;
            else
                return a * b * c;
        }

        static double SecondExpression(double a, double b)
        {
            if (a - b > 0)
                if (a < b)
                    return a / (a - b);
                else
                    return b / (a - b);
            else if (a < b)
                return a / -1 * (a - b);
            else
                return b / -1 * (a - b);
        }
    }
}
