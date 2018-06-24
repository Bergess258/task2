using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesuatoeARABrat
{
    class List
    {
        public class Point
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
            public Point(Point d)
            {
                data = d.data;
                next = d.next;
                pred = d.pred;
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
        public static implicit operator Point(List l)
        {
            return l.Main;
        }
        public List(Point num)
        {
            Main = num;
        }
        public bool Check()
        {
            if (Main.data == Main.next.data) return false;
            return true;
        }
        public List(int num)
        {
            Main.data = num;
            Add(num - 1);
            Point P = Main;
            while (P.next != null)
                P = P.next;
            P.next = Main;
            Main = P.next;
            Main.pred = P;
        }
        public void Add(int num)
        {
            Point p1 = new Point(num);
            p1.next = Main;
            Main.pred = p1;
            Main = p1;
            if (num - 1 > 0)
                Add(num - 1);

        }
        public void StartSchet(int m)
        {
            int c = m;
            while (Check())
            {
                if(c--==0) { c = m; Point temp = Main; Point p = new Point(); p = temp.pred; temp = temp.next; temp.pred = p; temp.pred.next = temp; Main= new List(temp); }
                Main = Main.next;
            }
        }
        public int Data()
        {
            return Main.data;
        }
    }
}
