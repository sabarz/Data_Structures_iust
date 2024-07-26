using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C4
{
    public class Q2Froggie : Processor
    {
        public Q2Froggie(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public virtual long Solve(long n, long p, long[][] numbers)
        {
            throw new NotImplementedException();
        }
    }
}
