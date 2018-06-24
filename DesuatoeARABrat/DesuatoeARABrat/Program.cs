using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLibrary;

namespace DesuatoeARABrat
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Library.ReadIntMoreThan(0);
            int m = Library.ReadIntMoreThan(0);
            List list = new List(n);
            list.StartSchet(m);
            Console.WriteLine(list.Data());
        }
    }
}
