using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C6
{
    public class Q2Truck : Processor
    {
        public Q2Truck(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C6Processors.ProcessQ2Truck(inStr, Solve);
        

        public long Solve(long n ,long[] petr ,long[] dist)
        {
            throw new NotImplementedException();
        }
    }
}
