using System;

namespace _5_longest_common_subsequence_of_three_sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] a = Console.ReadLine().Split(' ');
            int m = int.Parse(Console.ReadLine());
            string[] b = Console.ReadLine().Split(' ');
            int x = int.Parse(Console.ReadLine());
            string[] c = Console.ReadLine().Split(' ');

            int[,,] dp = new int[n + 1, m + 1,x + 1];

            for (int i = 0; i < n + 1; i++)
            {
                dp[i, 0, 0] = 0;
            }

            for (int i = 0; i < m + 1; i++)
            {
                dp[0, i, 0] = 0;
            }
            
            for (int i = 0; i < x + 1; i++)
            {
                dp[0, 0, i] = 0;
            }

            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < m + 1; j++)
                {
                    for (int l = 1; l < x + 1; l++)
                    {
                        if (a[i - 1] == b[j - 1] && a[i - 1] == c[l - 1])
                        {
                            dp[i, j, l] = dp[i - 1, j - 1, l - 1] + 1;
                        }
                        else
                        {
                            dp[i, j, l] = Math.Max(dp[i, j, l - 1], Math.Max(dp[i - 1, j, l], dp[i, j - 1, l])); 
                        }
                    }
                }
            }

            Console.WriteLine(dp[n, m , x]);
        }
    }
}
