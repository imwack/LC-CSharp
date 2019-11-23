using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Heap<T> where T:IComparable<T> //最小堆
    {
        public T[] Array;
        public int Count;

        public Heap()
        {
            
        }

        public Heap(int n)
        {
            Array = new T[n];
            Count = n;
        }

        public Heap(T[] arr)
        {
            int n = arr.Length;
            Array = new T[n];
            Count = n;
            for (int i = 0; i < n; i++)
            {
                Array[i] = arr[i];
            }
        }

        public void MakeHeap()
        {
            if (Array == null || Count == 0)
                return;
            for(int i = Count/2; i>=0;--i)
                AdjustDown(i,Count);
        }

        public void HeapSort()
        {
            MakeHeap();
            for (int i = Count - 1; i >= 0; i--)
            {
                T temp = Array[0];
                Array[0] = Array[i];
                Array[i] = temp;
                AdjustDown(0,i);
            }
        }

        private void AdjustDown(int index, int count)
        {
            T temp = Array[index];
            int i = 2*index + 1;
            while (i< count)
            {
                if (i + 1 < count && Array[i + 1].CompareTo(Array[i])<0) //取大的
                    ++i;
                if(temp.CompareTo(Array[i])<0)
                    break;
                Array[index] = Array[i];
                index = i;
                i = 2*index + 1;
            }
            Array[index] = temp;
        }

        public void Insert(T num)
        {
            if (Array.Length <= Count)
            {
                var array = new T[Count*2];
                for (int i = 0; i < Count; i++)
                {
                    array[i] = Array[i];
                }
                Array = array;
            }
            Array[Count] = num;
            Count++;
            MakeHeap();
        }

        public T Pop()
        {
            T temp = Array[0];
            Array[0] = Array[Count-1];
            Array[Count-1] = temp;
            Count--;
            int cur = 0;
            while (cur<Count)
            {
                int l = cur*2 + 1;
                if(l>=Count) break;
                if (l + 1 < Count && Array[l].CompareTo(Array[l + 1]) < 0)
                    l++;
                if (Array[cur].CompareTo(Array[l]) < 0)
                {
                    T t = Array[cur];
                    Array[cur] = Array[l];
                    Array[l] = t;
                    cur = l;
                }
                else
                {
                    break;
                }
            }
            return temp;
        }

    }
}
