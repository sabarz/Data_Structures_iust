using System;
using System.Collections.Generic;
using System.Linq; 

namespace _2_primitive_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[] tmp = new long[n + 4];
            tmp[1] = 0;
            tmp[2] = 1;
            tmp[3] = 1;

            for (long i = 4; i <= n; i++)
            {
                if (i % 2 == 0 && i % 3 == 0)
                {
                    if (tmp[i / 3] <= tmp[i / 2] && tmp[i / 3] <= tmp[i - 1])
                    {
                        tmp[i] = tmp[i / 3] + 1;
                    }
                    else if (tmp[i / 2] <= tmp[i / 3] && tmp[i / 2] <= tmp[i - 1])
                    {
                        tmp[i] = tmp[i / 2] + 1;
                    }
                    else if (tmp[i - 1] <= tmp[i / 3] && tmp[i - 1] <= tmp[i / 2])
                    {
                        tmp[i] = tmp[i - 1] + 1;
                    }
                }
                else if (i % 3 == 0)
                {
                    if (tmp[i - 1] < tmp[i / 3])
                    {
                        tmp[i] = tmp[i - 1] + 1;
                    }
                    else
                    {
                        tmp[i] = tmp[i / 3] + 1;
                    }
                }
                else if (i % 2 == 0)
                {
                    //tmp[i] = Math.Min(stmp[i - 1], stmp[i / 2]); 

                    if (tmp[i - 1] < tmp[i / 2])
                    {
                        tmp[i] = tmp[i - 1] + 1;
                    }
                    else
                    {
                        tmp[i] = tmp[i / 2] + 1;
                    }
                }
                else if (i % 2 != 0 && i % 3 != 0)
                {
                    tmp[i] = tmp[i - 1] + 1;
                }
            }
            List<long> ans = new List<long>();
            ans.Add(n);
            while (n > 1)
            {
                if (n % 2 == 0 && n % 3 == 0)
                {
                    if (tmp[n - 1] <= tmp[n / 3] && tmp[n - 1] <= tmp[n / 2])
                    {
                        n--;
                        ans.Add(n);
                    }
                    else if (tmp[n / 2] <= tmp[n / 3] && tmp[n / 2] <= tmp[n - 1])
                    {
                        n /= 2;
                        ans.Add(n);
                    }
                    else if (tmp[n / 3] <= tmp[n / 2] && tmp[n / 3] <= tmp[n - 1])
                    {
                        n /= 3;
                        ans.Add(n);
                    }
                }
                else if (n % 3 == 0)
                {
                    if (tmp[n - 1] < tmp[n / 3])
                    {
                        n--;
                        ans.Add(n);
                    }
                    else
                    {
                        n /= 3;
                        ans.Add(n);
                    }
                }

                else if (n % 2 == 0)
                {
                    if (tmp[n - 1] < tmp[n / 2])
                    {
                        n--;
                        ans.Add(n);
                    }
                    else
                    {
                        n /= 2;
                        ans.Add(n);
                    }
                }
                else if (n % 2 != 0 && n % 3 != 0)
                {
                    n--;
                    ans.Add(n);
                }

            }
            ans.Reverse();
            for (int i = 0; i < ans.Count; i++)
            {
                Console.WriteLine(ans[i]); 
            }
        }
    }
}

