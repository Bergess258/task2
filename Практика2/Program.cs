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
            int m = Convert.ToInt32(temp[0])-1, n = Convert.ToInt32(temp[1]);
            temp = ForReading.ReadLine().Split(' ');
            int a= Convert.ToInt32(temp[0])-1, b = Convert.ToInt32(temp[1])-1;
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
                for (int g = 0; g < temp.Length; g++)
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
                    for (int g = 0; g <n;g++)
                    {
                        int t = Convert.ToInt16(temp[g]);
                        for (int g1 = 0; g1 < n; g1++)
                            Temp[g1][g] += First[g1][i1] * t;
                    }
                }
                for (int g = 0; g < n; g++)
                {
                    for (int i1 = 0; i1 < n; i1++)
                    {
                        First[g][i1] = Temp[g][i1]%p;
                    }
                }
                for (int g = 0; g < n; g++)
                {
                    Temp[g] = new int[n];
                }
            }
            ForReading.Close();
            StreamWriter Writel = new StreamWriter("OUTPUT.TXT");
            Writel.Write(First[a][b]);
            Writel.Close();
        }
    }
}