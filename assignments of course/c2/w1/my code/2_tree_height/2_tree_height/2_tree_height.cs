using System;
using System.Collections.Generic;
namespace _2_tree_height
{
    class Node
    {
        public int value;
        public List<Node> children;
        public bool seen;
        public Node(int value)
        {
            children = new List<Node>();
            this.value = value;
            seen = false;
        }
    }
    class Program
    {
        public static int hold = 1;
        public static int ans = 0;
        public static void DFS(List<Node> nodes , int start)
        {
            if (nodes[start].children.Count == 0)
            {
                if (ans < hold)
                    ans = hold;
                
                return;
            }
            hold++;
            for(int i = 0; i < nodes[start].children.Count; i ++)
            {
                int j = nodes[start].children[i].value;
                DFS(nodes, j);
            }
            hold--;
        }

        static void Main(string[] args)
        {
            List<Node> tree = new List<Node>();
            int n = int.Parse(Console.ReadLine());
            string[] a = Console.ReadLine().Split(' ');
            int hold = 0;

            for(int i = 0; i < n; i ++)
            {
                tree.Add(new Node(i));
            }
            for(int i = 0; i < n; i ++)
            {
                if (int.Parse(a[i]) == -1)
                {
                    hold = i;
                }
                else
                {
                    tree[int.Parse(a[i])].children.Add(tree[i]);
                }
            }
            DFS(tree, hold);
            Console.WriteLine(ans);
        }
    }
}
