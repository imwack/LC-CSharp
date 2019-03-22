using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<Interval> l = new List<Interval>();
            l.Add(new Interval(2, 3));
            l.Add(new Interval(4, 5));
            l.Add(new Interval(1, 10));

            MySolution s = new MySolution();
            s.Merge(l);
        }
    }
}
