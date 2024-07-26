using System;
using System.Collections; 
using System.Collections.Generic; 

namespace _4_maximum_advertisement_revenue
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] a = Console.ReadLine().Split(' ');
            string[] b = Console.ReadLine().Split(' ');
            List<long> array1 = new List<long>();
            List<long> array2 = new List<long>(); 

            for(int i = 0; i < n; i ++)
            {
                array1.Add(long.Parse(a[i]));
                array2.Add(long.Parse(b[i]));
            }

            array1.Sort();
            array2.Sort();

            long ans = 0;

            for(int i = 0; i < n; i ++)
            {
                ans += array1[i] * array2[i];
            }
           
            Console.WriteLine(ans);
        }
    }
}

