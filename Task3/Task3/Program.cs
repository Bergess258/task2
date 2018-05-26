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
            int x=Library.ReadInt();
            int y = Library.ReadInt();
            if (4 * x * x + y * y <= 1) Console.WriteLine("Входит");
            else Console.WriteLine("Не входит");
        }
    }
}
