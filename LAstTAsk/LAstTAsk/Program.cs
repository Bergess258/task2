using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLibrary;

namespace LAstTAsk
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int[] mas = new int[n];
            int[] count = new int[n];

            for (int i = 0; i < n; i++)
            {
                mas[i] = Library.RandIntFT(1, n);
                count[i] = 0;
            }
            int c1 = SortTree(n, mas);
            Console.WriteLine(c1);
            c1 = SortTree(n, count);
            Console.WriteLine(c1);
            SortBack(n, mas, ref count);
            c1 = SortTree(n, count);
            Console.WriteLine(c1);
        }

        private static int SortTree(int n, int[] mas)
        {
            Library.TreeNode Tree = new Library.TreeNode();
            Tree.Info = mas[0];
            int c1 = 0;
            for (int i = 1; i < n; i++)
                AddNode(ref Tree, mas[i], ref c1);
            return c1;
        }

        private static void Sort(int n, int[] mas, ref int[] count)
        {
            for (int i = 0; i < n; i++)
            {
                count[i] = 0;
            }
            for (int i = 0; i < n; i++)
                count[mas[i] - 1]++;
            int[] temp = new int[n];
            {
                int c = 0;
                for (int i = 0; i < n; i++)
                {
                    int k = count[i];
                    while (k-- > 0)
                        temp[c++] = i;
                }
            }
        }
        private static void SortBack(int n, int[] mas, ref int[] count)
        {
            for (int i = 0; i < n; i++)
            {
                count[i] = 0;
            }
            for (int i = 0; i < n; i++)
                count[mas[i] - 1]++;
            int[] temp = new int[n];
            {
                int c = 0;
                for (int i = n-1; i >0; i--)
                {
                    int k = count[i];
                    while (k-- > 0)
                        temp[c++] = i;
                }
            }
        }

        static void AddNode(ref Library.TreeNode root, int info,ref int c)
        {
            var newNode = new Library.TreeNode { Info = info };
            c++;
            if (root == null)
            {
                root = newNode;
                return;
            }
            var node = root;
            while (true)
            {
                if (node.Info > info)
                {
                    c += 2;
                    if (node.Left == null)
                    {
                        node.Left = newNode;
                        return;
                    }
                    else
                        node = node.Left;
                }
                else
                if (node.Info < info)
                {
                    c += 3;
                    if (node.Right == null)
                    {
                        node.Right = newNode;
                        return;
                    }
                    else
                        node = node.Right;
                }
                else { c += 2; return; }
            }
        }
    }
}
