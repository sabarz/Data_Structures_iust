using System;
using System.Collections.Generic;

namespace _6_maximum_number_of_prizes
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = int.Parse(Console.ReadLine());
            List<int> ans = new List<int>();
            int counter = 1;
            int i = 0;

            while(n > 0)
            {
                if(n - counter >= 0)
                {
                    ans.Add(counter);
                    n -= counter;
                    counter++;
                    i++;
                }
                else
                {
                    ans[i-1] += (int)n;
                    n = 0;
                }
            }

            Console.WriteLine(i);
            for(int j = 0; j  < i; j++)
            {
                Console.Write(ans[j] + " ");
            }
        }
    }
}
