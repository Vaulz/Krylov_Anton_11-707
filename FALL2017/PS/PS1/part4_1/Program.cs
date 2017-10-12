using System;

namespace part4_1
{
    class Program
    {

        // Часть 4 №1
        // Разложить чётное целое число на сумму двух простых чисел. Нужно вывести пару с наименьшим простым числом
        // Крылов Антон 11-707

        // Проверка на простоту числа
        static bool IsPrimeNumber(int number)
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;

            }
            return true;
        }

        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int primeNumberOne=0, primeNumberTwo=0;
            if (number % 2 == 0)
            {
                for (int i = 2; i < number / 2; i++)
                {
                    if (IsPrimeNumber(i))
                        if (IsPrimeNumber(number - i))
                        {
                            primeNumberOne = i;
                            primeNumberTwo = number - i;
                            Console.WriteLine($"{primeNumberOne} + {primeNumberTwo}");
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine($"{number} is not even number");
            }
        }
    }
}