using System;

namespace part3_7
{
    class Program
    {
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
