using System;
using System.Collections;
using System.Collections.Generic;


namespace _2_maximum_value_of_the_loot
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');
            int n = int.Parse(a[0]);
            int W = int.Parse(a[1]);
            int[] weight = new int[n];
            int[] value = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                a = Console.ReadLine().Split(' ');
                value[i] = int.Parse(a[0]);
                weight[i] = int.Parse(a[1]);
            }

            for(int i = 0; i < n-1; i ++)
            {
                for(int j = 0; j < n-i-1; j++)
                {
                    if((double)value[j]/ (double)weight[j] < (double)value[j+1]/ (double)weight[j+1])
                    {
                        int temp = value[j+1];
                        int tempp = weight[j+1];
                        value[j+1] = value[j];
                        weight[j + 1] = weight[j];
                        value[j] = temp;
                        weight[j] = tempp;
                    }
                }
            }


            double ans = 0 ;
            int counter = 0;

            while(W > 0 && counter < n)
            {
                if(W >= weight[counter])
                {
                    ans += (double)value[counter];
                    W -= weight[counter] ;
                }
                else
                {
                    ans += (((double)value[counter] * (double)W ) / (double)weight[counter]);
                    W = 0;
                }
                counter++;
            }

            Console.WriteLine(Math.Round(ans,4));
        }
    }
}
