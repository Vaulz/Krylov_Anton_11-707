using System;

namespace Number4
{
    class Program
    {
        static void Main()
        {
            DNF example = new DNF("x1&x2&x3&x4&x5^x1&x2^x1^x3&-x4^-x3&x5&x1");
            Console.WriteLine(example);

            bool[] s = new[] { true, true, false, true, true };
            Console.WriteLine(example.Value(s));

            example.Insert(new Konj("x4&x2"));
            Console.WriteLine(example);

            DNF dnf = new DNF("x1^x5&-x3");
            example.Disj(dnf);
            Console.WriteLine(example);

            example.SortByLength();
            Console.WriteLine(example);

            DNF incorrect =new DNF("x6");
        }
    }
}