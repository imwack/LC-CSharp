using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {
        public int LastStoneWeight2(int[] stones)
        {
            Heap<int> heap = new Heap<int>(stones);
            heap.MakeHeap();
            while (heap.Count > 1)
            {
                int a = heap.Pop();
                int b = heap.Pop();
                if (a != b)
                {
                    heap.Insert(a-b);
                }
            }
            if (heap.Count == 0) return 0;
            return heap.Pop();
        }
    }
}
