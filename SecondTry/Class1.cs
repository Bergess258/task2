using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecondTry
{
    public class MatrixMultiplication
    {
        public static int[][] multiply(int[][] a, int[][] b)
        {
            int rowsA = a.Length;
            int columnsB = b[0].Length;
            int columnsA_rowsB = a[0].Length;
            int[][] c = new int[rowsA][];
            for (int i = 0; i < columnsB; i++)
            {
                c[i] = new int[columnsB];
            }
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < columnsB; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < columnsA_rowsB; k++)
                    {
                        sum += a[i][k] * b[k][j];
                    }
                    c[i][j] = sum;
                }
            }

            return c;
        }
        public static int[][] multiplyTransposed(int[][] a, int[][] b)
        {

            int rowsA = a.Length;

            int[] columnB = new int[rowsA];
            int[][] c = new int[rowsA][];
            for (int i = 0; i < rowsA; i++)
            {
                c[i] = new int[rowsA];
            }

            for (int j = 0; j < rowsA; j++)
            {
                for (int k = 0; k < rowsA; k++)
                {
                    columnB[k] = b[k][j];
                }
                for (int i = 0; i < rowsA; i++)
                {
                    int[] rowA = a[i];
                    int sum = 0;
                    for (int k = 0; k < rowsA; k++)
                    {
                        sum += rowA[k] * columnB[k];
                    }
                    c[i][j] = sum;
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
        public static int[][] multiplyKek(int[][] a, int[][] b)
        {
            int n = a.Length;
            int pr = isprime(n);
            int blockSize = 2;
            if (pr == -1)
            {
                n++;
                blockSize++;
            }
            else
            if (pr != 0)
            {
                blockSize = pr;
            }
            else
                blockSize = 1;
            int[][] c = new int[n][];
            for (int i = 0; i < n; i++)
            {
                c[i] = new int[n];
            }
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
        public static int isprime(int n)
        {
            if (n == 1)
                return 0;
            if (n == 2) return 2;
            for (int d = (int)Math.Sqrt(n); d>0; d--)
            {
                if (n % d == 0)
                    return d;
            }
            return -1;
        }
        public class myRecursiveTask
        {

            int n;
            int[][] a;
            int[][] b;
            int[][] c;

            public myRecursiveTask(int[][] a, int[][] b, int n)
            {
                this.a = a;
                this.b = b;
                this.n = n;
                c=MultiStrassenThread(a,b,n);
            }
            public static int[][] MultiStrassenThread(int[][] a, int[][] b, int n)
            {
                if (n <= 128)
                {
                    return multiplyTransposed(a, b);
                }
                n >>= 1;
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
                myRecursiveTask task_p1 = null;
                myRecursiveTask task_p2 = null;
                myRecursiveTask task_p3 = null;
                myRecursiveTask task_p4 = null;
                myRecursiveTask task_p5 = null;
                myRecursiveTask task_p6 = null;
                myRecursiveTask task_p7 = null;
                Thread pool1 = new Thread(() => task_p1 = new myRecursiveTask(summation(a11, a22), summation(b11, b22), n));
                pool1.IsBackground = false;
                pool1.Start();
                pool1.Join();
                Thread pool2 = new Thread(() => task_p2 = new myRecursiveTask(summation(a21, a22), b11, n));
                pool2.IsBackground = false;
                pool2.Start();
                pool2.Join();
                Thread pool3 = new Thread(() => task_p3 = new myRecursiveTask(a11, subtraction(b12, b22), n));
                pool3.IsBackground = false;
                pool3.Start();
                pool3.Join();
                Thread pool4 = new Thread(() => task_p4 = new myRecursiveTask(a22, subtraction(b21, b11), n));
                pool4.IsBackground = false;
                pool4.Start();
                pool4.Join();
                Thread pool5 = new Thread(() => task_p5 = new myRecursiveTask(summation(a11, a12), b22, n));
                pool5.IsBackground = false;
                pool5.Start();
                pool5.Join();
                Thread pool6 = new Thread(() => task_p6 = new myRecursiveTask(subtraction(a21, a11), summation(b11, b12), n));
                pool6.IsBackground = false;
                pool6.Start();
                pool6.Join();
                Thread pool7 = new Thread(() => task_p7 = new myRecursiveTask(subtraction(a12, a22), summation(b21, b22), n));
                pool7.IsBackground = false;
                pool7.Start();
                pool7.Join();
                while (pool2.IsAlive == true) Thread.Sleep(1000);
                int[][] p1 = task_p1.c;
                int[][] p2 = task_p2.c;
                int[][] p3 = task_p3.c;
                int[][] p4 = task_p4.c;
                int[][] p5 = task_p5.c;
                int[][] p6 = task_p6.c;
                int[][] p7 = task_p7.c;

                int[][] c11 = summation(summation(p1, p4), subtraction(p7, p5));
                int[][] c12 = summation(p3, p5);
                int[][] c21 = summation(p2, p4);
                int[][] c22 = summation(subtraction(p1, p2), summation(p3, p6));

                return collectMatrix(c11, c12, c21, c22);
            }
            public static int[][] multiStrassenForkJoin(int[][] a, int[][] b)
            {

                int nn = getNewDimension(a, b);
                int[][] a_n = addition2SquareMatrix(a, nn);
                int[][] b_n = addition2SquareMatrix(b, nn);

                myRecursiveTask task = new myRecursiveTask(a_n, b_n, nn);
                int[][] fastFJ = task.c;

                return getSubmatrix(fastFJ, a.Length);
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
            private static int log2(int x)
            {
                int result = 1;
                while ((x >>= 1) != 0)
                {
                    result++;
                }

                return result;
            }
            private static int getNewDimension(int[][] a, int[][] b)
            {

                return 1 << log2(a.Length);
            }
            public static int[][] randomMatrix(int n)
            {
                int[][] a = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    a[i] = new int[n];
                    for (int j = 0; j < n; j++)
                    {
                        a[i][j] = new Random().Next(100);
                    }
                }
                return a;
            }
            public static void printMatrix(int[][] a)
            {
                for (int i = 0; i < a[0].Length; i++)
                {
                    Console.WriteLine("-------");
                }
                Console.WriteLine();
                foreach (int[] anA in a)
                {
                    Console.WriteLine("|");
                    foreach (int anAnA in anA)
                    {
                        Console.WriteLine("%4d |", anAnA);
                    }
                    Console.WriteLine();
                    for (int i = 0; i < a[0].Length; i++)
                    {
                        Console.WriteLine("-------");
                    }
                    Console.WriteLine();
                }
            }
            private class Multipliers
            {
                private int[][] matrixA;
                private int[][] matrixB;
                public Multipliers(int[][] a, int[][] b)
                {
                    matrixA = a;
                    matrixB = b;
                }
                public int[][] getMatrixB()
                {
                    return matrixB;
                }
                public int[][] getMatrixA()
                {
                    return matrixA;
                }
            }
            public static void main(String[] args)
            {
                int n = 5000;
                int[][] First = randomMatrix(n);
                int[][] Temp = randomMatrix(n);
                Stopwatch time = new Stopwatch();
                //****************************************
                time.Start();
                int[][] matrixByStrassenFJ = multiStrassenForkJoin(First, Temp);
                time.Stop();
                Console.WriteLine("Strassen Multiply Thread" + time.Elapsed);
                time.Reset();
                //****************************************
                //	TEST 2
                time.Start();
                int nn = getNewDimension(First, Temp);
                int[][] a_n = addition2SquareMatrix(First, nn);
                int[][] b_n = addition2SquareMatrix(Temp, nn);
                int[][] temp1 = multiStrassen(a_n, b_n, nn);
                int[][] matrixByStrassen = getSubmatrix(temp1, n);
                time.Stop();
                Console.WriteLine("Strassen Multiply " + time.Elapsed);
                time.Reset();
                //****************************************
                //****************************************
                //	TEST 3
                //time.Start();
                //int[][] matrixByUsual = multiply(First, Temp);
                //time.Stop();
                //Console.WriteLine("Usual Multiply " + time.Elapsed);
                //time.Reset();
                //****************************************
                //****************************************
                //	TEST 4
                time.Start();
                int[][] matrixByUsualTransposed = multiplyTransposed(First, Temp);
                time.Stop();
                Console.WriteLine("Usual Multiply Transposed " + time.Elapsed);
                time.Reset();
                time.Start();
                int[][] matrixKek = multiplyKek(First, Temp);
                time.Stop();
                Console.WriteLine(" Multiply Kek " + time.Elapsed);
                time.Reset();
            }

        }
    }
}