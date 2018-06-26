using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MainLibrary;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 8;
            int[] Numbers = new int[n * n];
            int[][] Matr = new int[n][];
            for (int i1 = 0; i1 < n; i1++)
                Matr[i1] = new int[n];
            for (int i1 = 0; i1 < Numbers.Length; i1++)
                Numbers[i1] = Library.RandIntFT(0, 100);
            int i = 0, j = 0, c = 1;
            Matr[0][0] = Numbers[0];
            while (true)
            {
                Matr[i][++j] = Numbers[c++];
                LeftDown(n, Numbers, Matr, ref i, ref j, ref c);
                if (i == n-1 && j == 0) break;
                Matr[++i][j] = Numbers[c++];
                RightUp(n, Numbers, Matr, ref i, ref j, ref c);
                
            }
            while (true)
            {
                Matr[i][++j] = Numbers[c++];
                RightUp(n, Numbers, Matr, ref i, ref j, ref c);
                if (i == n - 1 && j == i) break;
                Matr[++i][j] = Numbers[c++];
                LeftDown(n, Numbers, Matr, ref i, ref j, ref c);
            }
            Library.WriteMass(Numbers);
            Library.WriteMass(Matr);
        }
        private static void LeftDown(int n, int[] Numbers, int[][] Matr, ref int i, ref int j, ref int c)
        {
            while (i < n - 1 && j > 0)
            {
                Matr[++i][--j] = Numbers[c++];
            }
        }
        private static void RightUp(int n, int[] Numbers, int[][] Matr, ref int i, ref int j, ref int c)
        {
            while (i >0 && j < n-1)
            {
                Matr[--i][++j] = Numbers[c++];
            }
        }
    }
}
