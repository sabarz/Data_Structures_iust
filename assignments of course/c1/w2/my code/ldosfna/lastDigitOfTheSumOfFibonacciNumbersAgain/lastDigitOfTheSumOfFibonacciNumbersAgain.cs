using System;

namespace lastDigitOfTheSumOfFibonacciNumbersAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');
            long b1 = long.Parse(a[0])-1;
            long b2 = long.Parse(a[1]);

            int first = 0;
            int second = 1;
            int ans = 1;
            long p = 0;
            long sum = 1;
            int n = 10;

            for (int i = 2; i <= n * n; i++)
            {
                ans = (first + second) % n;
                sum += ans;

                if (ans == 0 && ((ans + second) % n) == 1)
                {
                    p = i;
                    break;
                }

                first = second;
                second = ans;
            }

            long hold = (b1 / p) * sum;

            if (b1 % p == 0)
                hold %= 10;

            else if (b1 % p == 1)
                hold = (hold + 1) % 10;
            else
            {
                first = 0;
                second = 1;
                ans = 1;

                for (int i = 0; i < b1 % p; i++)
                {
                    hold += ans;
                    ans = (first + second) % 10;
                    first = second;
                    second = ans;
                }
            }

            long ans1 = hold % 10;

            if (b1 + 1 == 0)
            {
                ans1 = 0;
            }

            first = 0;
            second = 1;
            ans = 1;
            p = 0;
            sum = 1;
            n = 10;

            for (int i = 2; i <= n * n; i++)
            {
                ans = (first + second) % n;
                sum += ans;

                if (ans == 0 && ((ans + second) % n) == 1)
                {
                    p = i;
                    break;
                }

                first = second;
                second = ans;
            }

            hold = (b2 / p) * sum;

            if (b2 % p == 0)
                hold %= 10;

            else if (b2 % p == 1)
                hold = (hold + 1) % 10;

            else
            {
                first = 0;
                second = 1;
                ans = 1;

                for (int i = 0; i < b2 % p; i++)
                {
                    hold += ans;
                    ans = (first + second) % 10;
                    first = second;
                    second = ans;
                }
            }

            long ans2 = hold % 10;
            
            if (b2 == 0)
            {
                ans2 = 0;
            }

            if (ans2 >= ans1)
            {
                Console.WriteLine(ans2 - ans1); 
            }
            else if(ans2 < ans1)
            {
                Console.WriteLine(ans2 - ans1 + 10);
            }
        }
    }
}
