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
                if (i % 2 == 0)
                {
                    ForReading.ReadLine();
                    for (int i1 = 0; i1 < n; i1++)
                    {
                        temp = ForReading.ReadLine().Split(' ');
                        for (int g = 0; g < n; g++)
                        {
                            int t = Convert.ToInt16(temp[g]);
                            for (int g1 = 0; g1 < n; g1++)
                                Temp[g1][g] += First[g1][i1] * t;
                        }
                    }
                    for (int i1 = 0; i1 < n; i1++)
                    {
                        First[i1] = new int[n];
                        for (int g = 0; g < n; g++)
                            Temp[g][i1] %= p;
                    }
                }
                else
                {
                    ForReading.ReadLine();
                    for (int i1 = 0; i1 < n; i1++)
                    {
                        temp = ForReading.ReadLine().Split(' ');
                        for (int g = 0; g < n; g++)
                        {
                            int t = Convert.ToInt16(temp[g]);
                            for (int g1 = 0; g1 < n; g1++)
                                First[g1][g] += Temp[g1][i1] * t;
                        }
                    }
                    for (int i1 = 0; i1 < n; i1++)
                    {
                        Temp[i1] = new int[n];
                        for (int g = 0; g < n; g++)
                            First[g][i1] %= p;
                    }
                }
            }
            ForReading.Close();
            StreamWriter Writel = new StreamWriter("OUTPUT.TXT");
            if(m%2==0)
            Writel.Write(First[a][b]);
            else
                Writel.Write(Temp[a][b]);
            Writel.Close();
        }
    }
}