using System;

namespace part3_2
{
    class Program
    {
        static void Main()
        {
            double number = double.Parse(Console.ReadLine());
            double eps = 0.000000000001;
            double result =(RootOfNumber(number,eps));
            Console.WriteLine($"Корень квадратный из числа {number} : {result}. \nТабличное значение: {Math.Sqrt(number)}.");
        }

        static double RootOfNumber(double x,double eps)
        {
            double previousNumber=0;
            double currentNumber = x;
            while (Math.Abs(currentNumber - previousNumber) >= eps)
            {
                previousNumber = currentNumber;
                currentNumber=1.0/2.0 * (previousNumber + x / previousNumber);
            }
            return currentNumber;
        }
    }
}
