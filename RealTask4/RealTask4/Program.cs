using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTask4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> mas = new List<int>();
            List<int> masForChanges = new List<int>();
            mas.Add(1);
            for(int i = 2; i < 101; i++)
            {
                Multiply(mas, masForChanges, i);
            }
        }
        private static void Multiply(List<int> mas, List<int> masForChanges, int i)
        {
            for (int c = mas.Count; c > 0; --c)
            {
                int temp = mas[c] * i;
                string tempS = temp.ToString();
                mas[c] = tempS[tempS.Length - 1];
                for (int i1 = tempS.Length - 1; i1 > 0; --i1)
                    masForChanges.Add(tempS[i1]);
            }
        }
    }
}
