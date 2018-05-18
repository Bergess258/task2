using System;
using System.IO;

namespace SecondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader ForReading = new StreamReader("INPUT.TXT");
            string s = ForReading.ReadLine();
            string[] temp = s.Split(' ');
            int m = Convert.ToInt32(temp[0]), n = Convert.ToInt32(temp[1]);
            s = ForReading.ReadLine();
            temp = s.Split(' ');
            int a= Convert.ToInt32(temp[0]), b = Convert.ToInt32(temp[1]);
            a--;
            b--;
            s = ForReading.ReadLine();
            int p = Convert.ToInt32(s);
            int[,] First = new int[n,n];
            int[,] Second = new int[n, n];
            int[,] Temp = new int[n, n];
            s = ForReading.ReadLine();
            for (int i1 = 0; i1 < n; i1++)
            {
                s = ForReading.ReadLine();
                temp = s.Split(' ');
                for (int g = 0; g < temp.Length; g++)
                {
                    First[i1, g] = Convert.ToInt32(temp[g]);
                }
            }
            for (int i = 0; i < m-1; i++)
            {
                s = ForReading.ReadLine();
                for(int i1 = 0; i1 < n; i1++)
                {
                    s = ForReading.ReadLine();
                    temp = s.Split(' ');
                    for(int g = 0; g < temp.Length; g++)
                    {
                        Second[i1, g] = Convert.ToInt32(temp[g]);
                        for (int g1 = 0; g1 < n; g1++)
                            Temp[g1, g] += First[g1, i1] * Second[i1, g];
                    }
                }
                //for(int i2=0;i2<n;i2++)
                //    for(int i3 = 0; i3 < n; i3++)
                //    {
                //        Temp[i2, i3] = 0;
                //        for (int g = 0; g < n; g++)
                //            Temp[i2, i3] += First[i2, g] * Second[g, i3];
                //        Temp[i2, i3] %=p;
                //    }
                for (int i1 = 0; i1 < n; i1++)
                {
                    for (int g = 0; g < temp.Length; g++)
                    {
                        First[i1, g] = Temp[i1, g]%p;
                        Temp[i1, g] = 0;
                    }
                }
            }
            ForReading.Close();
            StreamWriter Writel = new StreamWriter("OUTPUT.TXT");
            Writel.Write(First[a,b]);
            Writel.Close();
        }
    }
}
