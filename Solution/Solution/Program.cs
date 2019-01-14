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
            int[] n = new[] { 3, 30, 34, 5, 9 };
            string[] strs = new[] { "abcabc", "abcabc", "abcabc", "abc", "abc", "cca"};
            int[,] arr = new int[3, 2]
            {
                {1, 0}, {1, 2}, {0, 1}
            };
            var ret = s.LargestNumber(n);
            Console.WriteLine(ret);
            stopwatch.Stop();
            TimeSpan timespan = stopwatch.Elapsed;
            var second = timespan.TotalSeconds;
            //Console.WriteLine(second);
        }
    }
}
