using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MainLibrary;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> mas = new List<double>();
            mas.Add(Library.ReadDouble());
            mas.Add(Library.ReadDouble());
            mas.Add(Library.ReadDouble());
            double M = Library.ReadDouble();
            int c = 2;
            while (mas[c] < M)
            {
                mas.Add(mas[c] * mas[c - 1] + mas[c - 2]);
                c++;
            }
            foreach (double t in mas)
                Console.Write(t + " ");
            Console.WriteLine();
            Console.Write("Равенство ");
            if (mas[mas.Count - 1] == M) Console.WriteLine("выполняется");
            Console.WriteLine("не выполняется");
        }
    }
}
