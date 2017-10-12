using System;

namespace part4_10
{
    class Program
    {

        // Часть 4 №10
        // Найти длину и значение суммы элементов последовательности простых чисел, в сумме дающих простое число, меньшее 1000
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
            int number,sum=0, lengthOfSequence=0;
            for (number=2; sum+number < 1000; number++)
            {
                if (IsPrimeNumber(number))
                {
                    lengthOfSequence++;
                    if (IsPrimeNumber(sum += number))
                        Console.WriteLine($"Length of the sequence - {lengthOfSequence}, Amount - {sum}");
                }
            }
        }
    }
}
