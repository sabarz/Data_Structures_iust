using System;
using System.Collections.Generic;
namespace _3_maximum_value_of_an_arithmetic_expression
{
    class Program
    {
        static long[,] min;
        static long[,] max;
        static List<char> op;
        static List<long> nums; 
        public static long MINvalue(int i , int j)
        {
            long ans = long.MaxValue; 
            for(int p = i; p < j ; p ++)
            {
                ans =Math.Min(ans ,Math.Min(operation(op[p], min[i, p], max[p + 1, j]), Math.Min(operation(op[p], min[i, p], min[p + 1, j]),
                        Math.Min(operation(op[p], max[i, p], max[p + 1, j]), operation(op[p], max[i, p], min[p + 1, j])))));
            }
            return ans; 
        }
        public static long MAXvalue(int i , int j)
        {
            long ans = long.MinValue; 
            for(int p = i; p < j ; p ++)
            {
                ans = Math.Max(ans, Math.Max(operation(op[p], min[i, p], max[p + 1, j]), Math.Max(operation(op[p], min[i, p], min[p + 1, j]),
                        Math.Max(operation(op[p], max[i, p], max[p + 1, j]), operation(op[p], max[i, p], min[p + 1, j])))));
            }
            return ans; 
        }
        public static long operation(char c , long a , long b)
        {
            if(c == '+')
            {
                return a + b;
            }
            else if(c == '-')
            {
                return a - b;
            }
            else
            {
                return a * b; 
            }
        }
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            op = new List<char>();
            nums = new List<long>();

            for(int i = 0; i < a.Length; i++)
            {
                if(a[i] != '-' && a[i] != '+' && a[i] != '*')
                {
                    nums.Add(long.Parse(a[i].ToString()));
                }
                else
                {
                    op.Add(a[i]); 
                }
            }

            int n = nums.Count;
            min = new long[n, n];
            max = new long[n, n];

            for (int i = 0; i < n; i++)
            {
                min[i, i] = nums[i];
                max[i, i] = nums[i];
            }

            for (int i = 0; i < n - 1; i++)
            {
                for(int j = 0; j < n - i - 1; j++)
                {
                    int p = i + j + 1;
                    min[j ,p] = MINvalue(j, p);
                    max[j ,p] = MAXvalue(j, p);
                }
            }
            Console.WriteLine(max[0, n - 1]); 
        }
    }
}
