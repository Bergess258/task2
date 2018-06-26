using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MainLibrary;
using System.Threading.Tasks;

namespace Tash8
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Library.RandIntFT(2,50);
            int[][] mas = new int[n][];
            for (int i = 0; i < n; i++)
                mas[i] = new int[n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    mas[i][j] = Library.RandomInt01(0,9);
            for (int i = 0; i < n; i++)
            {
                bool ok = true;
                for (int j = 0; j < n; j++)
                    if (mas[i][j] == 1) { ok = false; break; }
                if (ok == true) Console.WriteLine("Вершина под № {0} свободна",i+1);
            }
            Library.WriteMass(mas);
            Console.ReadLine();
        }
    }
}
