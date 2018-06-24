using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MainLibrary;
using System.Threading.Tasks;

namespace Zadanie7
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ok;
            string first;
            List<byte> list = new List<byte>();
            do
            {
                ok = true;
                first = Console.ReadLine();
                foreach(char y in first)
                {
                    string y1 = Convert.ToString(y);
                    byte t = Convert.ToByte(y1);
                    if (t != 0 || t != 1) { Console.WriteLine("Неверный формат кода"); ok = false; break; }
                    list.Add(t);
                }
            } while (ok == false);
            int Step = 2;
            List<byte> End = new List<byte>();
            End.Add(0);
            int c = 2;
            for(int i = 0; i < list.Count; i++)
            {
                if (c++ == Step) { End.Add(0);Step *= 2;c++; }
                End.Add(list[i]);
            }
            for (int i = 1; i < Step; i*=2)
            {
                int temp = 0;
                int g = i-1;
                while (g < End.Count)
                {
                    for (int t = 0; t < i&& g + t < End.Count; t++)
                            temp += End[g + t];
                    g += i * 2;
                }
                if (temp % 2 == 1) End[i-1] = 1;
            }
            foreach (byte s in End)
                Console.Write(s);
            Console.WriteLine();
        }
    }
}
