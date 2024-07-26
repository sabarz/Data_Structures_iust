using System;

namespace _4_number_of_inversions
{
    class Program
    {
        static int answer = 0 ;
        public static int Merge(ref int[] num , int l , int m , int r)
        {
            int rr = r;
            int ll = l;
            int mm = m;
            int n = r - l + 1;
            int[] hold = new int[n];
            int p = 0;
            int ans = 0;

            while(ll <= m - 1 && mm <= r)
            {
                if (num[ll] <= num[mm])
                {
                    hold[p++] = num[ll++];
                    /* for(int s = 0; s < p; s++)
                     {
                         Console.Write(hold[s] + " ");
                     }*/
                }
                else
                {
                    hold[p++] = num[mm++];
                    /*for (int s = 0; s < p; s++)
                    {
                        Console.Write(hold[s] + " ");
                    }*/
                    ans += (m - ll);
                }
            }
            //Console.WriteLine(ans);

            while (ll <= m - 1)
            {
                hold[p++] = num[ll++];
            }
            while (mm <= r)
            {
                hold[p++] = num[mm++]; 
            }
            /* for (int i = n - 1; i >= 0; i--)
             {
                 Console.Write(hold[i] + "  "); 
             }*/
            int j = 0;
            for(int i = l; i <= r; i++)
            {
                num[i] = hold[j++]; 
            }

            return ans;
        }
        public static int divide(ref int[] num , int l , int r)
        {
            answer = 0;
            if(l < r)
            {
                int middle = (l + r) / 2;
                answer += divide(ref num, l, middle);
                answer += divide(ref num, middle + 1, r);
                answer += Merge(ref num, l, middle + 1, r);
            }
            return answer; 
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] s = Console.ReadLine().Split(' ');
            int[] numbers = new int[n];

            for(int i = 0; i < n; i ++)
            {
                numbers[i] = int.Parse(s[i]);
            }

            /*   for(int i = 0; i < n; i ++)
               {
                   Console.WriteLine(numbers[i]);
               }*/
            
            Console.WriteLine(divide(ref numbers, 0, n - 1));
 
        }
    }
}
