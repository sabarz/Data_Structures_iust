using System;
using System.Collections.Generic;
using System.Linq;
namespace _5_max_sliding_window
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] a = Console.ReadLine().Split(' ');
            int m = int.Parse(Console.ReadLine());
            int[] nums = new int[n];

            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(a[i]);
            }

            List<int> queue = new List<int>();

            for (int i = 0; i < m; i++)
            {
                while (queue.Count != 0 && nums[i] >= nums[queue.Last()] )
                {
                    queue.RemoveAt(queue.Count - 1);
                }
                queue.Insert(queue.Count, i);
            }
            Console.WriteLine(nums[queue.First()]);

            for(int i = m; i < n; i ++)
            {
                while (queue.Count != 0  && i - queue[0] >= m)
                {
                    queue.RemoveAt(0);
                }

                while (queue.Count != 0  && nums[i] >= nums[queue.Last()] )
                {
                    queue.RemoveAt(queue.Count - 1);
                }
                queue.Insert(queue.Count, i);
               
                Console.WriteLine(nums[queue.First()]);
            }
        }
    }
}
