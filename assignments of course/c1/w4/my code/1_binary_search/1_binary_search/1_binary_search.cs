using System;

namespace _1_binary_search
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] a = Console.ReadLine().Split(' ');
            int[] b1 = new int[n + 1];
            int m = int.Parse(Console.ReadLine());
            string[] c = Console.ReadLine().Split(' ');

            for (int i = 0; i < n; i++)
            {
                b1[i] = int.Parse(a[i]);
            }

            
            for (int i = 0; i < m; i ++)
            {
                int start = 0;
                int end = n;
                int ans = n / 2;

                while (true)
                {
                    int number = int.Parse(c[i]);
                    
                    if (b1[(start + end) / 2] > number)
                    {
                        end = (start + end) / 2;
                    }
                    else if (b1[(start + end) / 2] < number)
                    {
                        start = (start + end) / 2;
                    }
                    else if (b1[(start + end) / 2] == number)
                    {
                        ans = (start + end) / 2;
                        for(int j = start; j < (start + end) / 2; j++)
                        {
                            if(number == b1[j])
                            {
                                ans = j;
                                break;
                            }
                        }
                        break;
                    }
                    if (start + 1 == end && b1[(start + end) / 2] != number)
                    {
                        ans = -1;
                        break;
                    }
                }
                Console.Write(ans + " ");
            }


        }
    }
}
