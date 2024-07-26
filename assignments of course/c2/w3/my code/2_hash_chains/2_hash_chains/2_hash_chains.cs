using System;
using System.Collections.Generic;

namespace _2_hash_chains
{
    class Node
    {
        public string value;
        public Node next;
        public Node previos;
        public Node(string val)
        {
            value = val;
            next = null;
            previos = null;
        }
    }
    class HashTable
    {
        Node[] bucket;
        int m;
        public HashTable(int m)
        {
            this.m = m;
            bucket = new Node[m];
        }

        int hashFunction(string s)
        {
            long ans = 0;
            int x = 263, p = (int)Math.Pow(10, 9) + 7;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                ans = ((ans * x + s[i]) % p);
            }
            return (int)ans % m;
        }
        public void add(string newstr)
        {
            int index = hashFunction(newstr);
        //    Console.WriteLine(index);
            bool repeat = false;
            Node node = bucket[index];

            if (node == null)
            {
               // Console.WriteLine("sssss");
                bucket[index] = new Node(newstr);
                return;
            }
            if(node.value == newstr)
            {
                repeat = true;
            }
            while (node.next != null)
            {
                node = node.next;
                if (newstr == node.value)
                {
                    repeat = true;
                    break;
                }
            }
            if (!repeat)
            {
                Node newnode = new Node(newstr);
                newnode.next = bucket[index];
                bucket[index].previos = newnode;
                bucket[index] = newnode;
            }
        }
        public void del(string delstr)
        {
            int index = hashFunction(delstr);
            Node node = bucket[index];
      //      Console.WriteLine(index);
            if (node != null)
            {
                //Console.WriteLine("here");
                if (node.value == delstr)
                {
                    if (node.next != null)
                    {
                        node.next.previos = null;
                        bucket[index] = node.next;
                        return;
                    }
                    else
                    {
                        bucket[index] = null;
                        return;
                    }
                }
                while (node.next != null)
                {
                    //Console.WriteLine("wtd");
                    node = node.next;
                    if (delstr == node.value)
                    {
                        if (node.next != null)
                        {
                            node.previos.next = node.next;
                            node.next.previos = node.previos;
                        }
                        else
                        {
                            node.previos.next = null;
                        }
                        return;
                    }
                }
            }
        }
        public string find(string s)
        {
            int index = hashFunction(s);
            Node node = bucket[index];
            
            if (node == null)
            { 
                return "no";
            }
            if(node.value == s)
            {
                return "yes";
            }
            while (node.next != null)
            {
                node = node.next;
                if (s == node.value)
                {
                    return "yes";                        
                }
            }
            return "no";
        }
        public string check(int index)
        {
            string ans = "";
            Node node = bucket[index];
            //Console.WriteLine(bucket[index].ToString());
            if (node == null)
            {
                return "";
            }
            
            ans += node.value.ToString() + " ";
            while(node.next != null)
            {
                node = node.next;
                ans += node.value.ToString() + " ";
            }

            return ans;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            HashTable hash = new HashTable(m);
            List<string> ans = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string[] a = Console.ReadLine().Split(' ');

                if (a[0] == "add")
                {
                    hash.add(a[1]);
                }
                else if (a[0] == "del")
                {
                    hash.del(a[1]);
                }
                else if (a[0] == "find")
                {
                    ans.Add(hash.find(a[1]));
                }
                else if (a[0] == "check")
                {
                    ans.Add(hash.check(int.Parse(a[1])));
                }
            }

            foreach (string item in ans)
            {
                Console.WriteLine(item);
            }
        }
    }
}
