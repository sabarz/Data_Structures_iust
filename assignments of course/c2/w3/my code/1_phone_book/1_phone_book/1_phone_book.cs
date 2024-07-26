using System;
using System.Collections.Generic;
using System.Collections;

namespace _1_phone_book
{
   /* class HashTable
    {
        public List<Node> all;
        public HashTable()
        {
            all = new List<Node>();
        }
    }
    class Node
    {
        public Node next;
        public Node previos;
        public int value;
        public int key;

    }*/
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Hashtable hashtable = new Hashtable();
            List<string> ans = new List<string>();

            for(int i = 0; i < n; i ++)
            {
                string[] a = Console.ReadLine().Split(' ');
                if(a[0] == "add")
                {
                    if (!hashtable.ContainsKey(int.Parse(a[1])))
                    {
                        hashtable.Add(int.Parse(a[1]), a[2]);
                    }
                    else
                    {
                        hashtable[int.Parse(a[1])] = a[2];
                    }
                }
                else if(a[0] == "del")
                {
                    if(hashtable.ContainsKey(int.Parse(a[1])))
                    {
                        hashtable.Remove(int.Parse(a[1]));
                    }
                }
                else if(a[0] == "find")
                {
                    if (hashtable.ContainsKey(int.Parse(a[1])))
                    {
                        ans.Add(hashtable[int.Parse(a[1])].ToString());
                    }
                    else
                    {
                        ans.Add("not found");
                    }    
                }
            }

            foreach(string item in ans)
            {
                Console.WriteLine(item);
            }
        }
    }
}
