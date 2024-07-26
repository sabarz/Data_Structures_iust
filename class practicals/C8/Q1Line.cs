using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;
using System.Collections;

namespace C8
{
	public class Q1Line : Processor
	{
		public Q1Line(string testDataName) : base(testDataName) {}

		public override string Process(string inStr) => C8Processors.ProcessQ1Line(inStr, Solve);

		public string Solve(long n, long[][] p)
		{
			Hashtable hashtable = new Hashtable();
			long maxx = -1;
			long ans = -1;

			for(int i = 0; i < n; i ++)
            {
				for(int j = i; j < n; j ++)
                {
					double tmp = ((double)p[i][1] - (double)p[j][1]) / ((double)p[i][0] - (double)p[j][0]);
					
					if(!hashtable.ContainsKey(tmp))
					hashtable.Add(tmp , 2);
					
					else
					hashtable[tmp] += 1;
					
					maxx = Math.Max(hashtable[tmp] , maxx);
                }
				ans = Math.Max(ans, maxx);
            }

			return ans.ToString();
		}
	}
}
