using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C6
{
    public class Q1Circle : Processor
    {
        public Q1Circle(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C6Processors.ProcessQ1Circle(inStr, Solve);
        

        public long Solve(SinglyLinkedList llist)
        {
            throw new NotImplementedException();
        }
    }
}
