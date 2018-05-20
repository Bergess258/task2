using System;
using System.IO;

namespace SecondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader ForReading = new StreamReader("INPUT.TXT");
            string[] temp = ForReading.ReadLine().Split(' ');
            int m = Convert.ToInt32(temp[0]) - 1, n = Convert.ToInt32(temp[1]);
            temp = ForReading.ReadLine().Split(' ');
            int a = Convert.ToInt32(temp[0]) - 1, b = Convert.ToInt32(temp[1]) - 1;
            int p = Convert.ToInt32(ForReading.ReadLine());
            int[][] First = new int[n][];
            int[][] Temp = new int[n][];
            ForReading.ReadLine();
            for (int i1 = 0; i1 < n; i1++)
            {
                Temp[i1] = new int[n];
                First[i1] = new int[n];
            }
            for (int i1 = 0; i1 < n; i1++)
            {
                temp = ForReading.ReadLine().Split(' ');
                for (int g = 0; g < n; g++)
                {
                    First[i1][g] = Convert.ToInt32(temp[g]);
                }
            }
            for (int i = 0; i < m; i++)
            {
                ForReading.ReadLine();
                for (int i1 = 0; i1 < n; i1++)
                {
                    temp = ForReading.ReadLine().Split(' ');
                    for (int g = 0; g < n; g++)
                    {
                        Temp[i1][g] = Convert.ToInt32(temp[g]);
                    }
                }
                int nn = 1 << log2(n);
                int[][] a_n = addition2SquareMatrix(First, nn);
                int[][] b_n = addition2SquareMatrix(Temp, nn);
                int[][] temp1 = multiStrassen(a_n, b_n, nn);
                First = getSubmatrix(temp1, n);
                for (int t = 0; t < n; t++)
                    for (int s = 0; s < n; s++)
                        First[t][s] %= p;
            }
            ForReading.Close();
            StreamWriter Writel = new StreamWriter("OUTPUT.TXT");
            Writel.Write(First[a][b]);
            Writel.Close();
        }
        public static int[][] multiplyTransposed(int[][] a, int[][] b)
        {

            int n = a.Length;
            int columnsB = b[0].Length;
            int columnsA_rowsB = a[0].Length;
            int[][] c = new int[n][];
            for (int i = 0; i < columnsB; i++)
            {
                c[i] = new int[columnsB];
            }
            int blockSize = 2;
            for (int i = 0; i < n; i += blockSize)
                for (int k = 0; k < n; k += blockSize)
                    for (int j = 0; j < n; j += blockSize)
                        for (int iInner = i; iInner < i + blockSize; iInner++)
                            for (int kInner = k; kInner < k + blockSize; kInner++)
                                for (int jInner = j; jInner < j + blockSize; jInner++)
                                    c[iInner][jInner] += a[iInner][kInner] *
                                       b[kInner][jInner];
            return c;
        }
        private static int log2(int x)
        {
            int result = 1;
            while ((x >>= 1) != 0)
            {
                result++;
            }
            return result-1;
        }
        private static int[][] multiStrassen(int[][] a, int[][] b, int n)
        {
            if (n <= 128)
            {
                return multiplyTransposed(a, b);
            }
            n = n >> 1;
            int[][] a11 = new int[n][];
            int[][] a12 = new int[n][];
            int[][] a21 = new int[n][];
            int[][] a22 = new int[n][];
            int[][] b11 = new int[n][];
            int[][] b12 = new int[n][];
            int[][] b21 = new int[n][];
            int[][] b22 = new int[n][];
            for (int i = 0; i < n; i++)
            {
                a11[i] = new int[n];
                a12[i] = new int[n];
                a21[i] = new int[n];
                a22[i] = new int[n];
                b11[i] = new int[n];
                b12[i] = new int[n];
                b21[i] = new int[n];
                b22[i] = new int[n];
            }
            splitMatrix(a, a11, a12, a21, a22);
            splitMatrix(b, b11, b12, b21, b22);
            int[][] p1 = multiStrassen(summation(a11, a22), summation(b11, b22), n);
            int[][] p2 = multiStrassen(summation(a21, a22), b11, n);
            int[][] p3 = multiStrassen(a11, subtraction(b12, b22), n);
            int[][] p4 = multiStrassen(a22, subtraction(b21, b11), n);
            int[][] p5 = multiStrassen(summation(a11, a12), b22, n);
            int[][] p6 = multiStrassen(subtraction(a21, a11), summation(b11, b12), n);
            int[][] p7 = multiStrassen(subtraction(a12, a22), summation(b21, b22), n);
            int[][] c11 = summation(summation(p1, p4), subtraction(p7, p5));
            int[][] c12 = summation(p3, p5);
            int[][] c21 = summation(p2, p4);
            int[][] c22 = summation(subtraction(p1, p2), summation(p3, p6));
            return collectMatrix(c11, c12, c21, c22);
        }
        private static int[][] getSubmatrix(int[][] a, int n)
        {
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];
            }
            for (int i = 0; i < n; i++)
            {
                Array.Copy(a[i], 0, result[i], 0, n);
            }
            return result;
        }
        private static int[][] collectMatrix(int[][] a11, int[][] a12, int[][] a21, int[][] a22)
        {
            int n = a11.Length;
            int k = n << 1;
            int[][] a = new int[k][];
            for (int i = 0; i < k; i++)
            {
                a[i] = new int[k];
            }
            for (int i = 0; i < n; i++)
            {
                Array.Copy(a11[i], 0, a[i], 0, n);
                Array.Copy(a12[i], 0, a[i], n, n);
                Array.Copy(a21[i], 0, a[i + n], 0, n);
                Array.Copy(a22[i], 0, a[i + n], n, n);
            }
            return a;
        }
        private static void splitMatrix(int[][] a, int[][] a11, int[][] a12, int[][] a21, int[][] a22)
        {
            int n = a.Length >> 1;
            for (int i = 0; i < n; i++)
            {
                Array.Copy(a[i], 0, a11[i], 0, n);
                Array.Copy(a[i], n, a12[i], 0, n);
                Array.Copy(a[i + n], 0, a21[i], 0, n);
                Array.Copy(a[i + n], n, a22[i], 0, n);
            }
        }
        private static int[][] addition2SquareMatrix(int[][] a, int n)
        {
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];
            }
            for (int i = 0; i < a.Length; i++)
            {
                Array.Copy(a[i], 0, result[i], 0, a[i].Length);
            }
            return result;
        }
        private static int[][] subtraction(int[][] a, int[][] b)
        {

            int n = a.Length;
            int[][] c = new int[n][];
            for (int i = 0; i < n; i++)
            {
                c[i] = new int[n];
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c[i][j] = a[i][j] - b[i][j];
                }
            }
            return c;
        }
        private static int[][] summation(int[][] a, int[][] b)
        {
            int n = a.Length;
            int[][] c = new int[n][];
            for (int i = 0; i < n; i++)
            {
                c[i] = new int[n];
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c[i][j] = a[i][j] + b[i][j];
                }
            }
            return c;
        }
    }
}