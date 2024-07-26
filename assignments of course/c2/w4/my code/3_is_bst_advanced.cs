using System;
using System.Collections.Generic;

namespace _3_is_bst_advanced
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
        public static bool search(Node root, int min, int max)
        {
            if (root == null)
            {
                return true;
            }
            else if (root.val < min || root.val >= max)
            {
                return false;
            }
            else
            {
                return search(root.left, min, root.val) && search(root.right, root.val, max);
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] key = new int[n];
            int[] lefts = new int[n];
            int[] rights = new int[n];
            List<Node> tree = new List<Node>();

            for (int i = 0; i < n; i++)
            {
                string[] a = Console.ReadLine().Split(' ');
                key[i] = int.Parse(a[0]);
                lefts[i] = int.Parse(a[1]);
                rights[i] = int.Parse(a[2]);
                tree.Add(new Node(key[i]));
            }

            for (int i = 0; i < n; i++)
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
            if (n == 0 || n == 1)
            {
                Console.WriteLine("CORRECT");
            }
            else if (search(tree[0], int.MinValue, int.MaxValue))
            {
                Console.WriteLine("CORRECT");
            }
            else
            {
                Console.WriteLine("INCORRECT");
            }
        }
    }
}
