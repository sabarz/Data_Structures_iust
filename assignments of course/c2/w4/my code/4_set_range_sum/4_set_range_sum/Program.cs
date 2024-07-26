using System;
using System.Collections.Generic;

namespace _4_set_range_sum
{ 
    class Program
    {
        class Node
        {
            public Node right;
            public Node left;
            public Node parent;
            public long sum;
            public long value;

            public Node(long val, long s, Node l, Node r, Node p)
            {
                value = val;
                sum = s;
                right = r;
                left = l;
                parent = p;
            }
        }

        class splayTree
        {
            public Node root = null;

            public void insert(long newnode)
            {
                Node left = null;
                Node right = null;
                Node newV = null;

                Tuple<Node, Node> nmd = split(root, newnode);
                left = nmd.Item1;
                right = nmd.Item2;

                if (right == null || right.value != newnode)
                {
                    newV = new Node(newnode, newnode, null, null, null);
                }

                root = merge(merge(left, newV), right);
            }
            public Tuple<Node, Node> split(Node root, long val)
            {
                Tuple<Node, Node> nmd = find(root, val);

                Node right = nmd.Item1;
                root = nmd.Item2;
                Node left = null;

                if (right == null)
                {
                    left = root;
                    return new Tuple<Node, Node>(left, right);
                }

                right = splay(right);
                left = right.left;
                right.left = null;

                if (left != null)
                {
                    left.parent = null;
                }
                update(left);
                update(right);

                return new Tuple<Node, Node>(left, right);
            }
            public Node merge(Node left, Node right)
            {
                if (right == null)
                {
                    return left;
                }
                if (left == null)
                {
                    return right;
                }
                while (right.left != null)
                {
                    right = right.left;
                }

                right = splay(right);
                right.left = left;
                update(right);

                return right;
            }
            public Tuple<Node, Node> find(Node root, long val)
            {
                Node v = root;
                Node last = root;
                Node next = null;

                while (v != null)
                {
                    if (v.value >= val && (next == null || v.value < next.value))
                    {
                        next = v;
                    }

                    last = v;

                    if (v.value == val)
                    {
                        break;
                    }
                    if (v.value < val)
                    {
                        v = v.right;
                    }
                    else
                    {
                        v = v.left;
                    }
                }

                root = splay(last);
                return new Tuple<Node, Node>(next, root);
            }
            public Node splay(Node v)
            {
                if (v == null)
                {
                    return null;
                }
                while (v.parent != null)
                {
                    if (v.parent.parent == null)
                    {
                        smallRotate(v);
                        break;
                    }
                    bigRotate(v);
                }
                return v;
            }
            public void update(Node v)
            {
                if (v == null)
                {
                    return;
                }
                v.sum = v.value + (v.left != null ? v.left.sum : 0) + (v.right != null ? v.right.sum : 0);

                if (v.left != null)
                {
                    v.left.parent = v;
                }
                if (v.right != null)
                {
                    v.right.parent = v;
                }
            }
            public void smallRotate(Node v)
            {
                Node parent = v.parent;
                if (parent == null)
                {
                    return;
                }

                Node grandparent = v.parent.parent;

                if (parent.left == v)
                {
                    Node m = v.right;
                    v.right = parent;
                    parent.left = m;
                }
                else
                {
                    Node m = v.left;
                    v.left = parent;
                    parent.right = m;
                }

                update(parent);
                update(v);

                v.parent = grandparent;

                if (grandparent != null)
                {
                    if (grandparent.left == parent)
                    {
                        grandparent.left = v;
                    }
                    else
                    {
                        grandparent.right = v;
                    }
                }
            }
            public void bigRotate(Node v)
            {
                if (v.parent.left == v && v.parent.parent.left == v.parent || v.parent.right == v && v.parent.parent.right == v.parent)
                {
                    smallRotate(v.parent);
                    smallRotate(v);
                }
                else
                {
                    smallRotate(v);
                    smallRotate(v);
                }
            }
            public long Sum(long from, long to)
            {
                Tuple<Node, Node> nmd = split(root, from);
                Node left = nmd.Item1;
                Node middle = nmd.Item2;

                nmd = split(middle, to + 1);
                middle = nmd.Item1;
                Node right = nmd.Item2;

                long ans = 0;

                if (middle != null)
                {
                    ans = middle.sum;
                }

                middle = merge(middle, right);
                root = merge(left, middle);

                return ans;
            }
            public bool FindtheNode(long val)
            {
                Tuple<Node, Node> nmd = split(root, val);
                Node left = nmd.Item1;
                Node right = nmd.Item2;

                if (right == null || right.value != val)
                {
                    root = merge(left, right);
                    return false;
                }
                else
                {
                    root = merge(left, right);
                    return true;
                }
            }
            public void earase(long val)
            {
                Tuple<Node, Node> nmd = split(root, val);
                Node left = nmd.Item1;
                Node middle = nmd.Item2;

                nmd = split(middle, val + 1);
                middle = nmd.Item1;
                Node right = nmd.Item2;

                if (middle == null || middle.value != val)
                {
                    root = merge(merge(left, middle), right);
                }
                else
                {
                    middle = null;
                    root = merge(left, right);
                }
            }
        }


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            splayTree splayTree = new splayTree();
            List<string> ans = new List<string>();
            long nmd = 0;
            long mode = (long)Math.Pow(10, 9) + 1;

            for (int i = 0; i < n; i ++)
            {
                string[] a = Console.ReadLine().Split(' ');

                if(a[0] == "?")
                {
                    //Console.WriteLine(long.Parse(a[1]) + nmd % mode);
                    if(splayTree.FindtheNode((long.Parse(a[1]) + nmd) % mode))
                    {
                        ans.Add("Found");
                    }
                    else
                    {
                        ans.Add("Not found");
                    }
                }
                else if(a[0] == "+")
                {
                    //Console.WriteLine(long.Parse(a[1]) + nmd % mode);
                    splayTree.insert((long.Parse(a[1]) + nmd) % mode);
                }
                else if(a[0] == "-")
                {
                   // Console.WriteLine(long.Parse(a[1]) + nmd % mode);
                    splayTree.earase((long.Parse(a[1]) + nmd) % mode);
                }
                else if(a[0] == "s")
                {
                  // Console.WriteLine((long.Parse(a[1]) + nmd) % mode + "     " + (long.Parse(a[2]) + nmd) % mode);
                    long hold = splayTree.Sum((long.Parse(a[1]) + nmd) % mode, (long.Parse(a[2]) + nmd) % mode);
                    ans.Add(hold.ToString());
                    nmd = hold % mode;
                }
            }

            foreach(var item in ans)
            {
                Console.WriteLine(item);
            }
        }
    }
}
