using System;
using System.Collections.Generic;

namespace _1_Convert_array_into_heap
{
    class Program
    {
        static public List<string> ans;
        static public void BuildHeap(int n , ref int[] nums)
        {
            for(int i = n / 2 - 1; i >= 0; i --)
            {
                siftDown(i ,n ,ref nums);
            }
        }
        static public void siftDown(int i, int n, ref int[] nums)
        {
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            int minIndex = i;

            if (l <= n - 1 && nums[l] < nums[minIndex])
                minIndex = l;
            if (r <= n - 1 && nums[r] < nums[minIndex])
                minIndex = r;

            if(i != minIndex)
            {
                ans.Add(minIndex + " " + i);
                int tmp = nums[i];
                nums[i] = nums[minIndex];
                nums[minIndex] = tmp;
                siftDown(minIndex , n , ref nums); 
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] a = Console.ReadLine().Split(' ');
            int[] nums = new int[n];
            ans = new List<string>();
            for(int i = 0; i < n; i ++)
            {
                nums[i] = int.Parse(a[i]);
            }

            BuildHeap(n, ref nums);
            Console.WriteLine(ans.Count);
            for(int i = 0; i < ans.Count; i ++)
            {
                Console.WriteLine(ans[i]);
            }
           /* int hold = n - 1;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(nums[i]);
            }*/
            /*for (int i = 1; i < n; i ++)
            {
                int tmp = nums[0];
                nums[0] = nums[hold];
                nums[hold] = tmp;
                siftDown(0, hold, ref nums);
                hold--;
            }*/
            /*for (int i = 0;i  < n; i ++)
            {
                Console.WriteLine(nums[i]);
            }*/
        }
    }
}
