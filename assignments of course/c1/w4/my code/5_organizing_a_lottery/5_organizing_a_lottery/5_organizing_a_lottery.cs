using System;
using System.Collections.Generic;
using System.Linq;

namespace _5_organizing_a_lottery
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');
            int n = int.Parse(a[0]);
            int m = int.Parse(a[1]);
            List<List<int>> segment = new List<List<int>>();
            int[] ans = new int[m];

            for (int i = 0; i < n; i++)
            {
                List<int> hold = new List<int>();
                a = Console.ReadLine().Split(' ');
                segment.Add(new List<int> { int.Parse(a[0]), -2 });
                segment.Add(new List<int> { int.Parse(a[1]), 100000001 });
            }

            a = Console.ReadLine().Split(' ');
            int c = 0;

            for (int i = n; i < m + n; i++)
            {
                List<int> hold = new List<int>();
                segment.Add(new List<int> { int.Parse(a[c]), i - n });
                c++;
            }

            List<List<int>> FinalSegment = new List<List<int>>();
            FinalSegment = segment.OrderBy(x => x[0]).ThenBy(y => y[1]).ToList();
            int counter = 0;

            for (int i = 0; i < n * 2 + m; i++)
            {
                if (FinalSegment[i][1] == -2)
                {
                    counter++;
                }
                else if (FinalSegment[i][1] == 100000001)
                {
                    counter--;
                }
                else
                {
                    ans[FinalSegment[i][1]] = counter;
                }
            }

            for (int i = 0; i < m; i++)
            {
                Console.Write(ans[i] + " ");
            }
        }
    }
}
