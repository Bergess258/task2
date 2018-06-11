using System;
using System.Collections.Generic;
using System.Linq;
using MainLibrary;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    class List
    {
        class Point
        {
            public int data;
            public Point next, pred;
            public Point()
            {
                data = 0;
                next = null;
                pred = null;
            }
            public Point(int d)
            {
                data = d;
                next = null;
                pred = null;
            }
            public override string ToString()
            {
                return data + " ";
            }
        }
        Point Main = new Point();
        static Point MakePoint(int d)
        {
            Point p = new Point(d);
            return p;
        }
        public List()
        {
            
        }
        public List(int num)
        {
            Main.data = num;
        }
        public void Add(int num)
        {
            Point p1 = new Point(num);
            p1.next = Main;
            Main.pred = p1;
            Main = p1;
            if (num-1 > 0)
                Add(num - 1);
        }
        static Point MakeRandomList(int size)
        {
            if (size <= 0) return null;
            int[] s = new int[size];
            int info;
            for (int i = 0; i < size; i++)
            {
                info = Library.RandIntFT(1, 60);
                s[i] = info;
            }
            Point q = MakePoint(s[s.Length - 1]);
            if (s.Length > 1)
                for (int i = 2; i <= s.Length; i++)
                {
                    Point p1 = new Point(s[s.Length - i]);
                    p1.next = q;
                    q.pred = p1;
                    q = p1;
                }
            return q;
        }
        public void Printlist()
        {
            Point beg = Main;
            if (beg == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            Point p = beg;
            while (p != null)
            {
                Console.Write(p + "\t");
                p = p.next;
            }
            Console.WriteLine();
        }
    }
}
