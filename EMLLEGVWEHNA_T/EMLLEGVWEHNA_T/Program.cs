using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLibrary;

namespace EMLLEGVWEHNA_T
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ok;
            string first;
            List<int> list = new List<int>();
            do
            {
                ok = true;
                first = Console.ReadLine();
                foreach (char y in first)
                {
                    string y1 = Convert.ToString(y);
                    int t = Convert.ToInt32(y1);
                    if (t != 0 && t != 1) { Console.WriteLine("Неверный формат кода"); ok = false; break; }
                    list.Add(t);
                }
            } while (ok == false);
            List<int> list1 = new List<int>();
            for (int i = 0; i < list.Count; i += 3)
                if (list[i] + list[i + 1] + list[i + 2] > 1) list1.Add(1);
                else list1.Add(0);
            foreach (int s in list1)
                Console.Write(s);
            Console.WriteLine();
        }
    }
}
