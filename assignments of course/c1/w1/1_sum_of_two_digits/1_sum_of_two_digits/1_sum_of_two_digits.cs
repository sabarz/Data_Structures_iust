using System;

namespace _1_sum_of_two_digits
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');
            Console.WriteLine(int.Parse(a[0] )+ int.Parse(a[1]));
        }
    }
}
