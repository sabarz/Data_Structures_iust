using System;

namespace MaxPairwiseProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string[] b = Console.ReadLine().Split(' ');

            int hold = 0;
            long max = -1;

            for(int i = 0; i < long.Parse(a); i++)
            {
                if (long.Parse(b[i]) > max)
                {
                    max = long.Parse(b[i]);
                    hold = i;
                }
            }

            long max2 = -1;

            for (int j = 0; j < long.Parse(a); j++)
            {
                if(hold != j && long.Parse(b[j]) > max2)
                {
                    max2 = long.Parse(b[j]);
                }
            }

            Console.WriteLine(max2 * max);
        }
    }
}

