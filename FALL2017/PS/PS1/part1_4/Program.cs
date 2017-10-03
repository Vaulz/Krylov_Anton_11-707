using System;

namespace part1_4
{
    class Program
    {
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
