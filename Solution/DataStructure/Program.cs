using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class Program
    {
        public static void HeapTest()
        {
            Heap<int> hp = new Heap<int>(new int[] { 1, 23, 5, 6, 7, 3 });
            hp.MakeHeap();
            //hp.HeapSort();
            hp.Insert(5);
        }

        static void Main(string[] args)
        {
            HeapTest();
        }
    }
}
