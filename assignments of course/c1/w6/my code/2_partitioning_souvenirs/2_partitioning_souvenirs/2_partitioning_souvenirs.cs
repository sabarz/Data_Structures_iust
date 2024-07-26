using System;

namespace _2_partitioning_souvenirs
{
    class Program
    {
        public static bool IsPossiblePartition(int[] v , int n , int sum)
        {
            if(sum == 0)
            {
                return true; 
            }
            else if(n == 0)
            {
                return false;
            }
            else if(v[n - 1] > sum)
            {
                return IsPossiblePartition(v, n - 1, sum);
            }

            return IsPossiblePartition(v, n - 1, sum) || IsPossiblePartition(v, n - 1, sum - v[n - 1]); 

        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] s = Console.ReadLine().Split(' ');
            int[] v = new int[n];
            int sum = 0;

            for(int i = 0; i < n; i ++)
            {
                v[i] = int.Parse(s[i]);
                sum += v[i]; 
            }
            if(sum % 3 != 0)
            {
                Console.WriteLine(0); 
            }
            else
            {
                Array.Sort(v);
                sum /= 3;

                if (IsPossiblePartition(v, n, sum))
                    Console.WriteLine(1);

                else
                    Console.WriteLine(0); 
            }
        }
    }
}
