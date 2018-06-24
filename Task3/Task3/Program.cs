using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MainLibrary;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            double x=Library.ReadInt();
            double y = Library.ReadInt();
            bool Res = Math.Abs(2 * x) <= Math.Abs(y);
            if (Res) Console.WriteLine("Входит");
            else Console.WriteLine("Не входит");
        }
    }
}
