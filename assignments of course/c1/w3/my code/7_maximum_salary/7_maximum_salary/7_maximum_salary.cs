using System;
using System.Collections.Generic;
using System.Linq;

namespace _7_maximum_salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] a = Console.ReadLine().Split(' ');
            int[] nums = new int[n];

            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(a[i]);
            }

            for (int i = 0; i < n ; i++)
            {
                for (int j = 0; j < n - 1 ; j++)
                {
                    string h1 = nums[j + 1].ToString() + nums[j].ToString();
                    string h2 = nums[j].ToString() + nums[j + 1].ToString();
                    if (h1.CompareTo(h2) == 1)
                    {
                        int hold = nums[j + 1];
                        nums[j + 1] = nums[j];
                        nums[j] = hold;
                    }
                }
            }

            for(int i = 0; i < n; i ++)
            {
                Console.Write(nums[i]);
            }
        }
    }
}
