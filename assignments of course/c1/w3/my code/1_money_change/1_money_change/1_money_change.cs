using System;

namespace _1_money_change
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int ans = 0;

            while(m > 0)
            {
                if(m >= 10)
                {
                    m -= 10;
                    ans++;
                }
                else if(m >= 5)
                {
                    m -= 5;
                    ans++;
                }
                else
                {
                    m -= 1;
                    ans++;
                }
            }

            Console.WriteLine(ans);
        }
    }
}
