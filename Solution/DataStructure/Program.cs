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
            hp.HeapSort();
            for (int i= 0;i<3;i++)
            {
                Console.WriteLine(hp.Pop());
            }
        }

        static void Main(string[] args)
        {
            HeapTest();
        }
    }
}
