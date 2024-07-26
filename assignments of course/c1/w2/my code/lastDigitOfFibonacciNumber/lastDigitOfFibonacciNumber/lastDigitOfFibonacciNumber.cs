using System;

namespace lastDigitOfFibonacciNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            long b = int.Parse(a);

            int first = 0;
            int second = 1;
            int ans = 1;
            long p = 0;
            int sum = 1;

            for (int i = 2; i <= 100; i++)
            {
                ans = (first + second) % 10;
                sum += ans;

                if (ans == 0 && (ans + second) % 10 == 1)
                {
                    p = i;
                    break;
                }

                first = second;
                second = ans;
            }

            long hold = (b / p) * sum;

            if (b % p == 0)
                Console.WriteLine(hold);

            else if (b % p == 1)
                Console.WriteLine(hold + 1);

            else
            {
                first = 0;
                second = 1;
                ans = 1;

                for (int i = 0; i < b % p; i++)
                {
                    hold += ans;
                    ans = (first + second) % 10;
                    first = second;
                    second = ans;
                }
                Console.WriteLine(hold % 10);
            }
        }
    }
}
