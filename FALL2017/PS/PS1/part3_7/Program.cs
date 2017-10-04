using System;

namespace part3_7
{
    class Program
    {

        // Часть 3 №7
        // На вход подаётся последовательность из n целых чисел (по модулю <=10^9) 
        // Определить является ли последовательность строго убывающей (каждый элемент < предыдущего)
        // Крылов Антон 11-707

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int previousNumber = int.Parse(Console.ReadLine());
            int number;
            string answer = "YES";
            for (int i = 1; i < n; i++)
            {
                number = int.Parse(Console.ReadLine());
                if (number>previousNumber)
                {
                    answer = "NO";
                    break;
                }
                previousNumber = number;
            }
            Console.WriteLine(answer);
        }
    }
}
