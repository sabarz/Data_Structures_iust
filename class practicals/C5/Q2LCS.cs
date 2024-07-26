using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C5
{
    public class Q2LCS : Processor
    {
        public Q2LCS(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);


        public virtual long Solve(string a, string b)
        {
            throw new NotImplementedException();
        }
    }
}
