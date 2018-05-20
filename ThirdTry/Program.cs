using System;
using System.IO;

namespace ThirdTry
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
                First[i1] = new int[n];
                Temp[i1] = new int[n];
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
                First = multiplyKek(First,Temp);
                for (int t = 0; t < n; t++)
                    for (int s = 0; s < n; s++)
                        First[t][s] %= p;
            }
            ForReading.Close();
            StreamWriter Writel = new StreamWriter("OUTPUT.TXT");
            Writel.Write(First[a][b]);
            Writel.Close();
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
            for (int d = 2; d * d <= n; d++)
            {
                if (n % d == 0)
                    return n/d;
            }
            return -1;
        }
    }
}