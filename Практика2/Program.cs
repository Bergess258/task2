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
            int m = Convert.ToInt16(temp[0])-1, n = Convert.ToInt16(temp[1]);
            temp = ForReading.ReadLine().Split(' ');
            int a= Convert.ToInt16(temp[0])-1, b = Convert.ToInt16(temp[1])-1;
            int p = Convert.ToInt16(ForReading.ReadLine());
            int[,] First = new int[n,n];
            int[,] Temp = new int[n, n];
            ForReading.ReadLine();
            for (int i1 = 0; i1 < n; i1++)
            {
                temp = ForReading.ReadLine().Split(' ');
                for (int g = 0; g < temp.Length; g++)
                {
                    First[i1, g] = Convert.ToInt16(temp[g]);
                }
            }
            for (int i = 0; i < m; i++)
            {
                ForReading.ReadLine();
                for(int i1 = 0; i1 < n; i1++)
                {
                    temp = ForReading.ReadLine().Split(' ');
                    for(int g = 0; g < temp.Length; g++)
                    {
                        int t = Convert.ToInt16(temp[g]);
                        for (int g1 = 0; g1 < n; g1++)
                            Temp[g1, g] += First[g1, i1] * t;
                    }
                }
                for (int i1 = 0; i1 < n; i1++)
                {
                    for (int g = 0; g < temp.Length; g++)
                    {
                        First[i1, g] = Temp[i1, g]%p;
                    }
                }
                Temp = new int[n, n];
            }
            StreamWriter Writel = new StreamWriter("OUTPUT.TXT");
            Writel.Write(First[a,b]);
            Writel.Close();
        }
    }
}