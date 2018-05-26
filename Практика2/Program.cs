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
                First[i1] = new int[n];
                Temp[i1] = new int[n];
            }
            string[] l;
            for (int i1 = 0; i1 < n; i1++)
            {
                l = ForReading.ReadLine().Split(' ');
                for (int g = 0; g < n; g++)
                {
                    First[i1][g] = Convert.ToInt32(l[g]);
                }
            }
            while(m-->1)
            {
                string[] l1;
                ForReading.ReadLine();
                for (int i1 = 0; i1 < n; i1++)
                {
                    l1 = ForReading.ReadLine().Split(' ');
                    for (int g = 0; g < n; g++)
                    {
                        Temp[i1][g] = Convert.ToInt32(l1[g]);
                    }
                }
                First = multiplyTransposed(First, Temp, p);
            }
            int c = 0;
            if (m != -1)
            {
                ForReading.ReadLine();
                for (int i1 = 0; i1 < n; i1++)
                {
                    c += First[a][i1] * Convert.ToInt32(ForReading.ReadLine().Split(' ')[b]);
                }
            }
            else
                c = First[a][b];
            ForReading.Close();
            StreamWriter Writel = new StreamWriter("OUTPUT.TXT");
            Writel.Write(c%p);
            Writel.Close();
        }
        public static int[][] multiplyTransposed(int[][] a, int[][] b, int p)
        {
            int n = b[0].Length;
            int[] columnB = new int[n];
            int[][] c = new int[n][];
            for (int i = 0; i < n; i++)
            {
                c[i] = new int[n];
            }

            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n; k++)
                {
                    columnB[k] = b[k][j];
                }
                for (int i = 0; i < n; i++)
                {
                    int[] rowA = a[i];
                    int sum = 0;
                    for (int k = 0; k < n; k++)
                    {
                        sum += a[i][k] * columnB[k];
                    }
                    c[i][j] = sum % p;
                }
            }
            return c;
        }
    }
}