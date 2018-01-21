/*
 * C# Program to Convert Infix to Postfix
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace convert_infix_to_postfix
{
    class Program
    {

        static bool Convert(ref string infix, out string postfix)
        {

            int prio = 0;
            postfix = "";
            Stack<Char> s1 = new Stack<char>();
            for (int i = 0; i < infix.Length; i++)
            {
                char ch = infix[i];
                if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
                {
                    if (s1.Count <= 0)
                        s1.Push(ch);
                    else
                    {
                        if (s1.Peek() == '*' || s1.Peek() == '/')
                            prio = 1;
                        else
                            prio = 0;
                        if (prio == 1)
                        {
                            if (ch == '+' || ch == '-')
                            {
                                postfix += s1.Pop();
                                i--;
                            }
                            else
                            {
                                postfix += s1.Pop();
                                i--;
                            }
                        }
                        else
                        {
                            if (ch == '+' || ch == '-')
                            {
                                postfix += s1.Pop();
                                s1.Push(ch);

                            }
                            else
                                s1.Push(ch);
                        }
                    }
                }
                else
                {
                    postfix += ch;
                }
            }
            int len = s1.Count;
            for (int j = 0; j < len; j++)
                postfix += s1.Pop();
            return true;
        }

        static void Main(string[] args)
        {
            
        }
    }
}
