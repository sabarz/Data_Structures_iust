using System;

namespace lastDigitOfTheSumOfSquaresOfFibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            long b = long.Parse(a);
            long n = 10;

            long first = 0;
            long second = 1;
            long ans = 1;
            long p = 0;
            long sum = 1;

            for (int i = 2; i <= 1000000000; i++)
            {
                ans = (first + second) % n;
                sum += ans * ans;

                if (ans == 0 && ((ans + second) % n) == 1)
                {
                    p = i;
                    break;
                }

                first = second;
                second = ans;
            }
            Console.WriteLine(p);

            long hold = (b / p) * sum;
            Console.WriteLine(hold);

            if (b % p == 0)
                Console.WriteLine(hold % 10);

            else if (b % p == 1)
                Console.WriteLine((hold + 1) % 10);

            else
            {
                first = 0;
                second = 1;
                ans = 1;

                for (int i = 0; i < b % p; i++)
                {
                    hold += ans * ans;
                    ans = (first + second) % 10;
                    first = second;
                    second = ans;
                }
                Console.WriteLine(hold % 10);
            }
        }
    }
}
