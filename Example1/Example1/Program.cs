using System;

namespace Example1
{
    class Program
    {
        static void Main()
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            {
                if ((x>=0 && x<=1 && y<=0 && y>=-1) || ((y>x)&&(x>=-1 && x<=0 && y>=-1 && y<=0))||((y>=0&&y<=1&&x>=-1&&x<0)&& y<=x*x))
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }
    }
}
