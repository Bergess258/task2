using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            List mas = new List(10);
            Console.WriteLine(List.Contains(-1, mas));
            mas=List.Remove(5, mas);
            mas.Printlist();
        }
    }
}
