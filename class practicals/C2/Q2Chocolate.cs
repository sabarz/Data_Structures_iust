
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C2
{
    public class Q2Chocolate : Processor
    {
        public Q2Chocolate(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public static long Solve(long n, long[] a)
        {
            throw new NotImplementedException();
        }
    }
}
