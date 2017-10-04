using System;

namespace part2_15
{
    class Program
    {

        // Часть 2 №15
        // Найти самую часто повторяющуюся цифру в k-ичной системе счисления (k от 2 до 5) десятичного натурального числа n (n<=10^9)
        // Крылов Антон 11-707

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int digitZero = 0, digitOne = 0, digitTwo = 0, digitThree = 0, digitFour = 0;
            while (n >0)
            {
                switch (n%k)
                {
                    case 0:
                        digitZero++;
                        break;
                    case 1:
                        digitOne++;
                        break;
                    case 2:
                        digitTwo++;
                        break;
                    case 3:
                        digitThree++;
                        break;
                    case 4:
                        digitFour++;
                        break;
                }
                n /= k;
            }
            int answer = Math.Max(Math.Max(Math.Max(Math.Max(digitZero, digitOne), digitTwo), digitThree), digitFour);
            if(answer==digitZero)
                Console.WriteLine("Digit 0");
            if (answer == digitOne)
                Console.WriteLine("Digit 1");
            if (answer == digitTwo)
                Console.WriteLine("Digit 2");
            if (answer == digitThree)
                Console.WriteLine("Digit 3");
            if (answer == digitFour)
                Console.WriteLine("Digit 4");
        }
    }
}
