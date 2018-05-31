using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary
{
    class Comparer : IComparer
    {
        string TypeSort;
        public Comparer(string f)
        {
            TypeSort = f
;
        }
        public int Compare(object x, object y)
        {
            return 0;
        }
        public int Compare(PlacesV x, PlacesV y)
        {
            switch (TypeSort)
            {
                case "City":
                    {
                        if (x is City)
                            if (y is City)
                                return ((City)x).CompareTo(y);
                            else
                                return -1;
                        else
                            if (y is City)
                            return 1;
                        return ((PlacesV)x).CompareTo(y);
                    }
                case "Megapolis":
                    if (x is Megapolis)
                        if (y is Megapolis)
                            return ((Megapolis)x).CompareTo(y);
                        else
                            return -1;
                    else
                        if (y is Megapolis)
                        return 1;
                    return ((PlacesV)x).CompareTo(y);
                case "Base":
                    return ((PlacesV)x).CompareTo(y);
                default:
                    return ((PlacesV)x).CompareTo(y);
            }
        }
        public void Search(PlacesV[] mas, PlacesV var)
        {
            int c = mas.Length;
            int a = mas.Length / 2;
            int l = 0;
            while (c != a)
            {
                l = Compare(var, mas[a]);
                if (l == 0) { Console.WriteLine(a); break; }
                if (l == -1) { c = a; a /= 2; }
                else
                {
                    int temp = a;
                    a += Math.Abs((c - a)) / 2;
                    if (a == temp) a++;
                    c = temp;
                }
            }
            if (l != 0) Console.WriteLine("Такого нет");
        }
    }
}
