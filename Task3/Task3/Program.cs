﻿using System;
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
            if (Math.Abs(2*x)<=Math.Abs(y)) Console.WriteLine("Входит");
            else Console.WriteLine("Не входит");
        }
    }
}
