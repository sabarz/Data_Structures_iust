using System;
using System.Collections.Generic;
namespace _1_tree_traversals
{
    class Node
    {
        public int val;
        public Node right;
        public Node left;

        public Node(int val)
        {
            this.val = val;
            right = null;
            left = null;
        }
    }
    class Program
    {
        public static void InOrder(Node root)
        {
            if (root != null)
            {
                InOrder(root.left);
                Console.Write(root.val + " ");
                InOrder(root.right);
            }
        }
        public static void PreOrder(Node root)
        {
            if (root != null)
            {
                Console.Write(root.val + " ");
                PreOrder(root.left);
                PreOrder(root.right);
            }
        } 
        public static void PostOrder(Node root)
        {
            if (root != null)
            {
                PostOrder(root.left);
                PostOrder(root.right);
                Console.Write(root.val + " ");
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] key = new int[n];
            int[] lefts = new int[n];
            int[] rights = new int[n];
            List<Node> tree = new List<Node>();

            for(int i = 0; i < n; i ++)
            {
                string[] a = Console.ReadLine().Split(' ');
                key[i] = int.Parse(a[0]);
                lefts[i] = int.Parse(a[1]);
                rights[i] = int.Parse(a[2]);
                tree.Add(new Node(key[i]));
            }

            for(int i = 0; i < n; i ++)
            {
                if (lefts[i] != -1)
                {
                    tree[i].left = tree[lefts[i]];
                }
                if (rights[i] != -1)
                {
                    tree[i].right = tree[rights[i]];
                }
            }

            InOrder(tree[0]);
            Console.WriteLine();
            PreOrder(tree[0]);
            Console.WriteLine();
            PostOrder(tree[0]);
        }
    }
}
