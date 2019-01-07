using System;
using System.Collections.Generic;
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

            MySolution s = new MySolution();
            int[] n = new[] {3,5,9};
            string[] strs = new[] { "abcabc", "abcabc", "abcabc", "abc", "abc", "cca"};
            var ret = s.Partition("");
            Console.WriteLine(ret);
            stopwatch.Stop();
            TimeSpan timespan = stopwatch.Elapsed;
            var second = timespan.TotalSeconds;
            //Console.WriteLine(second);
        }
    }
}
