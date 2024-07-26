using System;
using System.Collections.Generic;

namespace _2_majority_element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] a = Console.ReadLine().Split(' ');
            List<int> nums = new List<int>() ;

            for(int i = 0; i < n; i ++)
            {
                nums.Add(int.Parse(a[i]));
            }

            nums.Sort();
            int ans = 0;

            if (n % 2 == 1)
            {
                for (int i = 0; i <= n / 2; i++)
                {
                    if (nums[i] == nums[i + n / 2])
                    {
                        ans = 1;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < n / 2; i++)
                {
                    if (nums[i] == nums[i + n / 2])
                    {
                        ans = 1;
                        break;
                    }
                }
            }


            Console.WriteLine(ans);
        }
    }
}
 