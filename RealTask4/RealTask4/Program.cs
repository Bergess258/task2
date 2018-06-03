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
            foreach (int t in mas)
                Console.Write(t);
        }
        private static void Multiply(List<int> mas, List<int> masForChanges, int i)
        {
            for (int c = 0; c < mas.Count; c++)
            {
                int temp = mas[c] * i;
                masForChanges.Add(temp);
            }
            for(int c = 0; c < masForChanges.Count; c++)
            {
                if (masForChanges[c] > 9)
                {
                    int temp = masForChanges[c];
                    masForChanges[c] = temp % 10;
                    if (masForChanges.Count == c + 1) masForChanges.Add(temp/10);
                    else
                        masForChanges[c+1] +=temp/10;
                }
            }
            for (int c = 0; c < masForChanges.Count; c++)
            {
                int temp= masForChanges[c];
                if (c < mas.Count)
                    mas[c] = temp;
                else
                    mas.Add(temp);
            }
            masForChanges.Clear();
        }
    }
}
