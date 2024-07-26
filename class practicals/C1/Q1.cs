using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace C1
{
    public class Q1 : Processor
    {
        public Q1(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long n = first[0];
            long x = first[1];
            long [] a = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(n, a, x).ToString();
        }

        public long Solve(long n, long[] a, long x)
        {
            int hold = 0 , ans = 0;
            Array.Sort(a);

            for(int i = n-1; i = 0; i --)
            {
                if(a[i] > x)
                {
                    hold += a[i] - x;
                    ans++;
                }
                else if(a[i] < x && hold - x + a[i] > 0)
                {
                    hold -= x - a[i];
                    ans++;
                }
                else if(hold <= 0)
                {
                    break;
                }
            }

            return ans;
        }
    }
}
