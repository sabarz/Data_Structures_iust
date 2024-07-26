using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_Parallel_processing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');
            int n = int.Parse(a[0]);
            int m = int.Parse(a[1]);
            a = Console.ReadLine().Split(' ');
            List<List<long>> ans = new List<List<long>>();
            List<List<long>> nmd = new List<List<long>>();
            List<List<long>> hold = new List<List<long>>();
            long[] times = new long[m];
            int index = 0 , cnt = 0;

            for(int i = 0; i < m; i ++)
            {
                times[i] = int.Parse(a[i]);
            }
            
            for (int i = 0; i < n && i < m; i++)
            {
                ans.Add(new List<long>{(long)i, times[i]});
                nmd.Add(new List<long> {(long)i , 0});
            }

            ans = ans.OrderBy(x => x[1]).ToList();

            for (long i = n; i < m; i++)
            {
                if(index % 2 == 0)
                {
                    hold.Add(new List<long> { ans[cnt][0], ans[cnt][1] + times[i] });
                    nmd.Add(new List<long> { ans[cnt][0], ans[cnt][1] });
                }
                else
                {
                    ans.Add(new List<long> { hold[cnt][0], hold[cnt][1] + times[i] });
                    nmd.Add(new List<long> { hold[cnt][0], hold[cnt][1] });
                }

                cnt++;

                if(cnt == n)
                {
                    if(index % 2 == 0)
                    {
                        ans = new List<List<long>>();
                        hold = hold.OrderBy(x => x[1]).ToList();
                    }
                    else
                    {
                        hold = new List<List<long>>();
                        ans = ans.OrderBy(x => x[1]).ToList();
                    }
                    index++;
                    cnt = 0;
                }
            }
            for(int i = 0; i < m; i ++)
            {
                Console.WriteLine(nmd[i][0] + " " + nmd[i][1]);
            }
        }
    }
}
