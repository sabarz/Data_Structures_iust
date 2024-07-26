using System;

namespace _1_money_change_again
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] tmp = new int[n + 4];
            tmp[1] = 1;
            tmp[2] = 2;
            tmp[3] = 1;
            tmp[4] = 1;

            for (int i = 5; i <= n; i++)
            {
                if (tmp[i - 1] <= tmp[i - 3] && tmp[i - 1] <= tmp[i - 4])
                {
                    tmp[i] = tmp[i - 1] + 1;
                }
                else if (tmp[i - 3] <= tmp[i - 1] && tmp[i - 3] <= tmp[i - 4])
                {
                    tmp[i] = tmp[i - 3] + 1;
                }
                else if (tmp[i - 4] <= tmp[i - 1] && tmp[i - 4] <= tmp[i - 3])
                {
                    tmp[i] = tmp[i - 4] + 1;
                }
                //Console.Write(tmp[i] + "  "); 
            }
            Console.WriteLine(tmp[n]); 
        }
    }
}
