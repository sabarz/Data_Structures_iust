using System;
using System.Collections;
using System.Collections.Generic; 

namespace _1_brackets_in_code
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            Stack stack = new Stack();
            int ans = -1;
            List<int> index = new List<int>();

            for(int i = 0; i < a.Length; i++)
            {
                if(a[i] == '[')
                {
                    stack.Push('[');
                    index.Add(i);
                }
                else if(a[i] == '(')
                {
                    stack.Push('(');
                    index.Add(i);
                }
                else if(a[i] == '{')
                {
                    stack.Push('{');
                    index.Add(i);
                }
                else if(a[i] == ']')
                {
                    if(stack.Count != 0 && stack.Peek().ToString() == "[")
                    {
                        stack.Pop();
                        int h = index.Count;
                        index.RemoveAt(h - 1); 
                    }
                    else
                    {
                        ans = i + 1;
                        break;
                    }
                }
                else if(a[i] == '}')
                {
                    if(stack.Count != 0 && stack.Peek().ToString() == "{")
                    {
                        stack.Pop();
                        int h = index.Count;
                        index.RemoveAt(h - 1);
                    }
                    else
                    {
                        ans = i + 1;
                        break;
                    }
                }
                else if(a[i] == ')')
                {
                    if(stack.Count != 0 && stack.Peek().ToString() == "(")
                    {
                        stack.Pop();
                        int h = index.Count;
                        index.RemoveAt(h - 1);
                    }
                    else
                    {
                        ans = i + 1;
                        break;
                    }
                }
            }
            if(stack.Count != 0 && ans == -1)
            {
                Console.WriteLine(index[0] + 1); 
            }
            else if(stack.Count == 0 && ans == -1)
            {
                Console.WriteLine("Success"); 
            }
            else
            {
                Console.WriteLine(ans); 
            }
        }
    }
}
