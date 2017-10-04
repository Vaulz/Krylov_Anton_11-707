using System;

namespace part1_4
{
    class Program
    {

        // Часть 1 №4
        // По паре координат шахматной доски (каждая координата на отдельной строке) определить, возможен ли ход из одной позиции в другую ладьёй (YES|NO)
        // Крылов Антон 11-707

        static void Main()
        {
            string firstCoord = Console.ReadLine();
            string secondCoord = Console.ReadLine(); 
            if (firstCoord[0] == secondCoord[0] || firstCoord[1] == secondCoord[1])
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");

        }
    }
}
