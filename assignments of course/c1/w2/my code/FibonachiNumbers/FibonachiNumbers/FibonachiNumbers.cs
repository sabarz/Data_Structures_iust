using System;

namespace FibonachiNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            int b = int.Parse(a);

            int[] ans = new int[50];

            ans[0] = 0;
            ans[1] = 1;

            for (int i = 2; i <= b; i++)
                ans[i] = ans[i - 1] + ans[i - 2];

            Console.WriteLine(ans[b]);
        }
    }
}
