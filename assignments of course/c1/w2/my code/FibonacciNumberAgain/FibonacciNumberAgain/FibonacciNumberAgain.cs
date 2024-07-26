using System;

namespace FibonacciNumberAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');
            long b = long.Parse(a[0]);
            int n = int.Parse(a[1]);

            int first = 0;
            int second = 1;
            int ans = 1;
            long p = 0;

            for (int i = 2; i <= n * n; i++)
            {
                ans = (first + second) % n;

                if (ans == 0 && (ans + second) % n == 1)
                {
                    p = i;
                    break; 
                }

                first = second;
                second = ans;
            }

            long hold = b % p;
            first = 0;
            second = 1;
            
            for (int i = 2; i <= hold; i ++)
            {
                ans = (first + second) % n;
                first = second;
                second = ans;
            }

            if (hold == 0)
                Console.WriteLine("0");

            else if(hold == 1)
                Console.WriteLine("1");

            else
                Console.WriteLine(ans);
        }
    }
}

