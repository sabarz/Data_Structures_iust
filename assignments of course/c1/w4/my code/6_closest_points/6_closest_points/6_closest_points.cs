using System;
using System.Collections.Generic;
using System.Linq;

namespace _6_closest_points
{
    class Program
    {
        static double middlepointsDistance(List<List<int>> points , double d)
        {
            points =  points.OrderBy(y => y[1]).ToList(); 

            double min = d;
            for(int i = 0 ; i < points.Count; i ++)
            {
                for (int j = i+1; j < points.Count && (points[j][1] - points[i][1]) < min; ++j)
                {
                    if(min > distance(points[i] , points[j]))
                    {
                        min = distance(points[i], points[j]);
                    }
                }
            }
            return min;
        }
        static double distance(List<int> point1 , List<int> point2)
        {
             return Math.Sqrt(Math.Pow((double)point2[0] - (double)point1[0], 2) +
                Math.Pow((double)point2[1] - (double)point1[1], 2));
        }
        static double Divide(List<List<int>> points , int n , int l , int r)
        {
            if(n <= 3)
            {
                double min = 10000000; 
                for(int i = l; i <= r; i ++)
                {
                    for(int j = i + 1; j <= r; j ++)
                    {
                        if(distance(points[i] , points[j]) < min)
                        {
                            min = distance(points[i], points[j]);
                        }
                    }
                }
                return min;
            }

            int mid = n / 2; 
            double d1 = Divide(points, mid , l , l + mid - 1);
            double d2 = Divide(points, n - mid , l + mid , r);

            double d = Math.Min(d1, d2); 
            List<List<int>> middlePoints = new List<List<int>>();

            for(int i = l; i <= r; i ++)
            {
                if(points[mid][0] - points[i][0] < d)
                {
                    middlePoints.Add(points[i]);
                    //Console.WriteLine(points[i][0] + "  " + points[i][1]);
                }
            }

            return Math.Min(middlepointsDistance(middlePoints , d) , d); 
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<List<int>> points = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                string[] a = Console.ReadLine().Split(' ');
                points.Add(new List<int>() { int.Parse(a[0]), int.Parse(a[1]) }); 
            }

            points = points.OrderBy(x => x[0]).ToList();
            /*for(int i = 0; i < n; i ++)
            {
                Console.WriteLine(points[i][0] + " " + points[i][1]);
            }*/
            Console.WriteLine(Math.Round(Divide(points, n , 0 , n-1) , 4)); 
        }
    }
}
