using System;
using System.Collections.Generic;

namespace _3_improving_quicksort
{
    class Program
    {
        public static List<long> answer = new List<long>();
        public static void QuickSort(long[] array , long pivot, long n)
        {
            long[] bigger = new long[n];
            long[] smaller = new long[n];
            long[] equal = new long[n];

            if (n == 1)
            {
                answer.Add(array[0]);
                return;
            }

            long s = 0, e = 0, b = 0;

            for (long i = 0; i < n; i++)
            {
                if (pivot < array[i])
                {
                    bigger[b] = array[i];
                    b++;
                }
                else if (pivot > array[i])
                {
                    smaller[s] = array[i];
                    s++;
                }
                else
                {
                    equal[e] = array[i];
                    e++;
                }
            }
            if (s != 0)
            {
                QuickSort(smaller, smaller[s - 1], s);
            }
            if (e != 0)
            {
                for (long i = 0; i < e; i++)
                {
                    answer.Add(equal[i]);
                }
            }
            if (b != 0)
            {
                QuickSort(bigger, bigger[b - 1], b);
            }
        }
        static void Main(string[] args)
        {
            long n = int.Parse(Console.ReadLine());
            long[] arr = new long[n];

            for(int i = 0; i < n; i ++)
            {
                arr[i] = long.Parse(Console.ReadLine());
            }
            long p = arr[n - 1];
            for (int i = 0; i < n; i++)
            {
                Console.Write("*****");
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(answer[i]);
            }
            QuickSort(arr,p,n);
        }
    }
}
