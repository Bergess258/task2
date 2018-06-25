using System;
using System.Collections.Generic;
using System.IO;

namespace FirstTask
{
    class Program
    {
        static List<List<int>> Temp = new List<List<int>>();
        static void Main(string[] args)
        {
            StreamReader ForReading = new StreamReader("INPUT.TXT");
            string s = "";
            string[] line = new string[3];
            int Count = 0, roots = 1;
            int Cur = 1;
            byte c = 0;
            Temp.Add(new List<int>());
            s = ForReading.ReadLine();
            Count = Convert.ToInt16(s);
            if (Count != 1)
            {
                for (int i = 0; i < Count - 1; i++)
                {
                    s = ForReading.ReadLine();
                    line = s.Split(' ');
                    Cur = Convert.ToInt16(line[1]);
                    roots++;
                    if (line[0] == "N")
                    {
                        Temp[Cur - 1].Add(roots);
                        Temp.Add(new List<int>());
                    }
                    else
                    {
                        Temp.Add(new List<int>());
                        Temp[Cur - 1].Add(Convert.ToInt16(line[2]));
                    }
                }
                ForReading.Close();
                StreamWriter Write = new StreamWriter("OUTPUT.TXT");
                c = DoMove(true, 0);
                if (c == 2) Write.Write(-1);
                else if (c == 0) Write.Write(0);
                else Write.Write("+1");
                Write.Close();
            }
            else
            {
                s = ForReading.ReadLine();
                ForReading.Close();
                line = s.Split(' ');
                StreamWriter Write = new StreamWriter("OUTPUT.TXT");
                Write.Write(line[2]);
                Write.Close();
            }
        }

        private static byte DoMove(bool FP, int No)
        {
            byte c = 3;
            if (FP == true)
            {
                foreach (int i in Temp[No])
                {
                    if (i == 1)
                    {
                        return 1;
                    }
                    else if (i != -1 && i != 0)
                    {
                        byte temp = 0;
                        temp = DoMove(false, i - 1);
                        if (temp == 1) return 1;
                        if (temp == 0) c = 0;
                    }
                    else if (i == 0) c = 0;
                }
                if (c == 3) return 2;
            }
            else
            {
                foreach (int i in Temp[No])
                {
                    if (i == -1)
                    {
                        return 2;
                    }
                    else if (i != 1 && i != 0)
                    {
                        byte temp = 0;
                        temp = DoMove(true, i - 1);
                        if (temp == 2) return 2;
                        if (temp == 0) c = 0;
                    }
                    else if (i == 0) c = 0;
                }
                if (c == 3) return 1;
            }
            return c;
        }
    }
}