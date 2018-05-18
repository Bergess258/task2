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
            int[][] Second = new int[n][];
            int[][] Temp = new int[n][];
            ForReading.ReadLine();
            for (int i = 0; i < n; i++)
            {
                First[i] = new int[n];
                Second[i] = new int[n];
                Temp[i] = new int[n];
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
                    for(int g = 0; g < temp.Length; g++)
                    {
                        Second[g][i1] = Convert.ToInt32(temp[g]);
                    }
                }
                for(int i2=0;i2<n;i2++)
                    for(int i3 = 0; i3 < n; i3++)
                    {
                        Temp[i2][i3] = 0;
                        for (int g = 0; g < n; g++)
                            Temp[i2][i3] += First[i2][g] * Second[i3][g];
                        Temp[i2][i3] %=p;
                    }
                for (int i1 = 0; i1 < n; i1++)
                {
                    for (int g = 0; g < temp.Length; g++)
                    {
                        First[i1][g] = Temp[i1][g];
                    }
                }
            }
            ForReading.Close();
            StreamWriter Writel = new StreamWriter("OUTPUT.TXT");
            Writel.Write(First[a][b]);
            Writel.Close();
        }
    }
}