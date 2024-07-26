using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C2
{
    public class Q1FlowerShop : Processor
    {
        public Q1FlowerShop(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long a = first[0];
            long b = first[1];
            long [] p = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(a, b, p).ToString();
        }
        public static long Solve(long a, long b, long[] p)
        {
            long counter = b , ans = 0 , tmp = 1;
            Array.Sort(p);
            for(long i = a-1; i >= 0 ; i ++)
            {
                if(counter > 0)
                {
                    counter--;
                    ans += p[i] * tmp ;
                }
                else if(counter == 0)
                {
                    counter = b - 1;
                    tmp++;
                    ans += p[i] * tmp;
                }
            }

            return ans;
        }
    }
}
