using System;

namespace _3_edit_distance
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine(); 
            string b = Console.ReadLine();
            int[,] dp = new int[a.Length + 1, b.Length + 1]; 

            for(int i = 0; i < a.Length+ 1; i ++)
            {
                dp[i, 0] = i; 
            }
            for (int i = 0; i < b.Length + 1; i++)
            {
                dp[0, i] = i;
            }

            for(int i = 1 ; i < a.Length + 1 ; i ++)
            {
                for(int j = 1; j < b.Length + 1; j ++)
                {
                    dp[i, j] = Math.Min(dp[i - 1 , j] + 1, dp[i, j - 1] + 1); 
                    if(a[i - 1] == b[j - 1])
                    {
                        dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j - 1]); 
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j - 1] + 1);
                    }
                }
            }

            Console.WriteLine(dp[a.Length, b.Length]); 
        }
    }
}
