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
            int n = 32;
            int[] mas = new int[n];
            int[] count = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                mas[i] = Library.RandIntFT(0, n);
                count[i] = 0;
            }
                
            Library.TreeNode Tree = new Library.TreeNode();
            Tree.Info = mas[0];
            int c1 = 0;
            for (int i = 1; i < n; i++)
                AddNode(ref Tree, mas[i],ref c1);
            for (int i = 0; i < n; i++)
                count[i - 1]++;
            int[] temp = new int[n];
            {
                int c = 0;
                for (int i = 0; i < n; i++)
                {
                    int k = i;
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
