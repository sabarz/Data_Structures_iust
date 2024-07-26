using System;

namespace GreatestCommonDivisor
{
    class Program
    {
        static long GCD(long a , long b)
        {
            if (b == 0)
                return a;

             return GCD(b, a % b);
            
        }
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');

            Console.WriteLine(GCD(long.Parse(a[0]), long.Parse(a[1]))) ;
        }
    }
}
