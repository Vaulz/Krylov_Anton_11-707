using System;

namespace part1_7
{
    class Program
    {
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
