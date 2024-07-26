using System;
using System.Collections.Generic;

namespace _3_Merging_tables
{
    class DisjoiontSets
    {
        public int parent;
        public int size;
        public int value;
        public DisjoiontSets(int value, int size)
        {
            parent = value;
            this.value = value;
            this.size = size;
        }
        
        public void ChangeParent(int nmd)
        {
            this.parent = nmd;
        }
        public void ChangeSize(int nmd)
        {
            this.size += nmd;
        }        
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');
            int n = int.Parse(a[0]);
            int m = int.Parse(a[1]);
            a = Console.ReadLine().Split(' ');
            int maxSize = -1;
            List<int> ans = new List<int>();

            List<DisjoiontSets> ds = new List<DisjoiontSets>();
            for(int i = 0; i < n; i ++)
            {
                ds.Add(new DisjoiontSets(i, int.Parse(a[i])));
                if(maxSize < int.Parse(a[i]))
                {
                    maxSize = int.Parse(a[i]);
                }
            }

            for(int i = 0; i < m; i ++)
            {
                a = Console.ReadLine().Split(' ');
                int dest = int.Parse(a[0]) - 1;
                int source = int.Parse(a[1]) - 1;

                if(dest != source && ds[dest].parent != ds[source].parent)
                {
                    int hold = dest;
                    while (true)
                    {
                        if(ds[hold].parent == hold)
                        {
                            break;
                        }
                        else
                        {
                            ds[hold].size = 0;
                            hold = ds[hold].parent;
                        }
                    }
                    
                    int nmd = source;
                    while (true)
                    {
                        if(ds[nmd].parent == nmd)
                        {
                            ds[nmd].ChangeParent(hold);
                            break;
                        }
                        else
                        {
                            ds[nmd].size = 0;
                            int tmp = nmd;
                            nmd = ds[nmd].parent;
                            ds[tmp].ChangeParent(hold);
                        }
                    }
                    if (nmd != hold)
                    {
                        ds[hold].ChangeSize(ds[nmd].size);
                        ds[nmd].size = 0;
                    }
                    //Console.WriteLine(hold +"   "+nmd + "    "+ds[hold].size);
                    maxSize = Math.Max(maxSize, ds[hold].size);
                    ans.Add(maxSize);
                }
                else
                {
                    ans.Add(maxSize);
                }
            }
            foreach(int item in ans)
            {
                Console.WriteLine(item);
            }
        }
    }
}
