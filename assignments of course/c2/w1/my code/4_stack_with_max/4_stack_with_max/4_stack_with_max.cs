using System;

namespace _4_stack_with_max
{
    class stack
    {
        int[] values;
        int i;
        int[] maxxx;
        int cnt = 0;
        int p = 0;
        public stack()
        {
            this.i = 0;
            values = new int[400000];
            maxxx = new int[400000];
            maxxx[0] = -1;
        }
        public void push(int num)
        {
            values[i] = num;
            i++;
            if (num > maxxx[cnt])
            {
                maxxx[cnt + 1] = num;
                cnt++;
            }
            else
            {
                maxxx[cnt + 1] = maxxx[cnt];
                cnt++; 
            }
        }

        public void pop()
        {
            if (values[i - 1] == maxxx[cnt])
            {
                maxxx[cnt] = 0;
            }

            values[i - 1] = 0;
            i--;
            cnt--;
        }
        public int max()
        {
            return maxxx[cnt];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            stack s = new stack();
            int[] ans = new int[400000];
            int cnt = 0;

            for(int i = 0; i < n; i ++)
            {
                string[] a = Console.ReadLine().Split(' ');
                if(a[0] == "push")
                {
                    s.push(int.Parse(a[1])); 
                }
                else if(a[0] == "pop")
                {
                    s.pop();
                }
                else if(a[0] == "max")
                {
                    ans[cnt] = s.max();
                    cnt++;
                }
            }

            for(int i = 0; i < cnt; i ++)
            {
                Console.WriteLine(ans[i]);
            }
        }
    }
}
