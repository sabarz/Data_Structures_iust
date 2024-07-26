using System;

namespace _3_car_fueling
{
    class Program
    {
        static void Main(string[] args)
        {
            int distance = int.Parse(Console.ReadLine());
            int maxT = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int[] stop = new int[n + 1];
            string[] a = Console.ReadLine().Split(' ');
            stop[n] = distance;

            for (int i = 0; i < n; i ++ )
            {
                stop[i] = int.Parse(a[i]);
            }

            int previous = 0;
            int ans = 0;
            for(int i = 0; i < n; i ++)
            {
                if(stop[i] <= previous + maxT && stop[i+1] > previous + maxT && previous + maxT < distance )
                {
                    previous = stop[i];
                    ans++;
                }

                if (stop[i] > previous + maxT)
                    ans = -1;
            }
            if (distance > previous + maxT)
                ans = -1;

            Console.WriteLine(ans);
        }
    }
}
