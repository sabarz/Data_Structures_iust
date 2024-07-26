using System;
using System.Collections.Generic;
using System.Linq;

namespace _1_maximum_amount_of_gold
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');
            int W = int.Parse(a[0]); 
            a = Console.ReadLine().Split(' ');
            int n = a.Length;
            int[] weight = new int[n + 1];
            int[,] dp = new int[n + 1, W + 1]; 

            for(int i = 0; i < n; i ++)
            {
                weight[i + 1] = int.Parse(a[i]); 
            }
            Console.WriteLine(weight.LongLength);

/*            for(int i = 0; i < n + 1; i ++)
            {
                dp[i, 0] = 0;
            }
            for(int i = 0; i < W + 1; i ++)
            {
                dp[0, i] = 0;
            }
*/
            for (int j = 1; j < W + 1; j++)
            {
                for (int i = 1; i < n + 1 ; i++)
                {
                    if (weight[i] <= j)
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j - weight[i]] + weight[i], dp[i - 1, j]);
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            Console.WriteLine(dp[n, W]); 
        }
    }
}
