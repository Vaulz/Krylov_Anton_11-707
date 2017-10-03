using System;

namespace part3_14
{
    class Program
    {
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
