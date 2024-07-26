using System;
using System.Collections.Generic;
using System.Linq;

namespace _3_network_simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');
            int size = int.Parse(a[0]);
            int n = int.Parse(a[1]);
            int[] starts = new int[n];
            int[] ends = new int[n];
            int[] ans = new int[n];

            for(int i = 0; i < n; i ++)
            {
                a = Console.ReadLine().Split(' ');
                starts[i] = int.Parse(a[0]);
                ends[i] = int.Parse(a[1]);
            }

            List<int> stack = new List<int>();
            int cnt = -1;
            for(int i = 0; i < size && i < n; i ++)
            {
                if (starts[i] <= cnt)
                {
                    ans[i] = cnt;
                    stack.Add(cnt + ends[i]); 
                }
                else
                {
                    ans[i] = starts[i];
                    stack.Add(starts[i] + ends[i]);
                }

                if (i == 0)
                    cnt = ends[i] + starts[i];

                else
                    cnt += ends[i]; 
            }

            for(int i = size; i < n; i ++)
            {
                if(starts[i] >= stack[0])
                {
                    if(starts[i] > stack[size - 1])
                    {
                        ans[i] = starts[i];
                        stack.RemoveAt(0);
                        stack.Add(starts[i] + ends[i]);
                        stack = stack.OrderBy(x => x).ToList();
                    }
                    else
                    {
                        ans[i] = stack[size - 1];
                        stack.RemoveAt(0);
                        stack.Add(ans[i] + ends[i]);
                        stack = stack.OrderBy(x => x).ToList();
                    }    
                }
                else
                {
                    ans[i] = -1;
                }
            }

            for(int i = 0; i < n; i ++)
            {
                Console.WriteLine(ans[i]); 
            }
        }
    }
}
