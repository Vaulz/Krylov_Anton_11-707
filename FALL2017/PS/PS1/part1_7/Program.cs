using System;

namespace part1_7
{
    class Program
    {

        // Часть 1 №7
        // По длинам трёх отрезков определить могут ли отрезки являться сторонами треугольника (YES|NO)
        // Крылов Антон 11-707

        static void Main()
        {
            var firstSegment = double.Parse(Console.ReadLine());
            var secondSegment = double.Parse(Console.ReadLine());
            var thirdSegment = double.Parse(Console.ReadLine());
            if (firstSegment + secondSegment > thirdSegment && firstSegment + thirdSegment > secondSegment && secondSegment + thirdSegment > firstSegment)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}
