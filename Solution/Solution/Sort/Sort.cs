using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class Interval
    {
      public int start;
      public int end;
      public Interval() { start = 0; end = 0; }
      public Interval(int s, int e) { start = s; end = e; }
    }

    public partial class MySolution
    {
        //56. Merge Intervals 
        //First sort array : 1.start increase 2.end increase
        //Second Merge two interval and get new range[start,end]
        public IList<Interval> Merge(IList<Interval> intervals)
        {

            IList<Interval> ret = new List<Interval>();
            var arr = intervals.ToArray();
            
            Array.Sort(arr, (a, b) =>
            {
                if (a.start == b.start)
                {
                    return a.end >= b.end ? 1 : -1;
                }
                return a.start >= b.start ? 1 : -1;
            });
            int i = 0;
            while (i < arr.Length)
            {
                int start = arr[i].start;
                int end = arr[i].end;
                while (i + 1 < arr.Length && end >= arr[i + 1].start)
                {
                    if (arr[i + 1].end > end)
                        end = arr[i + 1].end;
                    ++i;
                }

                ret.Add(new Interval(start, end));
                i++;
            }
            return ret;
        }
    }
}
