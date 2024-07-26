using System;
using System.Collections.Generic;

namespace _5_collecting_signatures
{
    struct limit
    {
        public int first;
        public int second;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            limit[] MyLimit = new limit[n];
            
            for(int i = 0; i < n; i ++)
            {
                string[] a = Console.ReadLine().Split(' ');
                MyLimit[i].first = int.Parse(a[0]);
                MyLimit[i].second = int.Parse(a[1]);
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (MyLimit[j+1].first < MyLimit[j].first )
                    {
                        int temp = MyLimit[j + 1].first;
                        int tempp = MyLimit[j + 1].second;
                        MyLimit[j + 1].first = MyLimit[j].first;
                        MyLimit[j + 1].second = MyLimit[j].second;
                        MyLimit[j].first = temp;
                        MyLimit[j].second = tempp;
                    }
                }
            }  

            int ans=0;
            List<int> segments = new List<int>(); 
            int hold = MyLimit[0].second; 

            for(int i = 1; i < n; i++)
            {
                if(MyLimit[i].first > hold)
                {
                    ans++;
                    segments.Add(hold);
                    hold = MyLimit[i].second;
                }
                else if (MyLimit[i].second <= hold)
                {
                    hold = MyLimit[i].second;
                }
            }

            ans++;
            segments.Add(hold);

            Console.WriteLine(ans);

            for (int i = 0; i < segments.Count; i++)
                Console.Write(segments[i] + " ");
        }        
    }
}
