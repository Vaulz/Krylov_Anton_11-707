using System;

namespace part3_14
{
    class Program
    {

        // Часть 3 №14
        // Считывая числа пока не встретится 0, найти длину самой длинной последовательности чётных чисел
        //	Крылов Антон 11-707

        static void Main()
        {
            int sequenceLength = 0, maxSequenceLength = 0;
            int k=int.Parse(Console.ReadLine());
            while (k!= 0)
            {
                if (k % 2 == 0)
                    sequenceLength++;
                else
                {
                    if (maxSequenceLength<sequenceLength)
                        maxSequenceLength = sequenceLength;
                    sequenceLength = 0;
                }
                k = int.Parse(Console.ReadLine());
            }
            if (maxSequenceLength < sequenceLength)
                maxSequenceLength = sequenceLength;
            Console.WriteLine(maxSequenceLength);
        }
    }
}
