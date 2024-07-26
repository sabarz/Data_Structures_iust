using System;

namespace _4_longest_common_subsequence_of_two_sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] a = Console.ReadLine().Split(' ');
            int m = int.Parse(Console.ReadLine());
            string[] b = Console.ReadLine().Split(' ');

            int[,] dp = new int[n + 1, m + 1];



            /*for(int i = 0; i < n + 1; i ++)
            {
                dp[i, 0] = 0;
            }

            for (int i = 0; i < m + 1; i++)
            {
                dp[0, i] = 0;
            }
*/
            /*for (int i = 1; i < n + 1; i ++)
            {
                for(int j = 1; j < m + 1; j ++)
                {
                    if(a[i - 1] == b[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1; 
                    }
                    else if(dp[i - 1, j] > dp[i, j - 1])
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                    else
                    {
                        dp[i, j] = dp[i, j - 1];
                    }
                }
            }*/

            Console.WriteLine(dp[n, m]);
        }
    }
}
