using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class MaxHeap<T> where T : IComparable
    {
        public int Count;
        private T[] Element;
        public T Peek => Element[0];

        public MaxHeap(T[] n)
        {
            Count = n.Length;
            Element = new T[Count];
            for (int i = 0; i < n.Length; i++)
            {
                Element[i] = n[i];
            }
            for (int i = Count/2 - 1; i >= 0; --i)
            {
                AdjustDown(i);
            }
        }

        public void AdjustDown(int index)
        {
            int l = 2*index + 1;
            while (l < Count)
            {
                if (l+1 < Count && Element[l].CompareTo(Element[l+1]) < 0) //取l和r中大的
                {
                    l++;
                }
                if (Element[index].CompareTo(Element[l]) < 0)
                {
                    T temp = Element[l];
                    Element[l] = Element[index];
                    Element[index] = temp;
                    index = l;
                    l = 2*l + 1;
                }
                else
                {
                    break;
                }
            }
        }

        //把头部元素扔到最后
        public T Pop()
        {
            T front = Element[0];
            T last = Element[Count-1];
            Element[Count - 1] = front;
            Element[0] = last;
            Count--;

            AdjustDown(0);
            return front;
        }

        public void Push(T n)
        {
            if (Count >= Element.Length)
            {
                return; //先不考虑扩容
            }
            Element[Count] = n;
            Count++;
            AdjustDown(0);
        }
    }
    public class Heap<T> where T : IComparable<T> //最大堆
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
            for (int i = Count / 2; i >= 0; --i)
                AdjustDown(i, Count);
        }

        public void HeapSort()
        {
            MakeHeap();
            for (int i = Count - 1; i >= 0; i--)
            {
                T temp = Array[0];
                Array[0] = Array[i];
                Array[i] = temp;
                AdjustDown(0, i);
            }
        }

        private void AdjustDown(int index, int count)
        {
            T temp = Array[index];
            int i = 2 * index + 1;
            while (i < count)
            {
                if (i + 1 < count && Array[i + 1].CompareTo(Array[i]) < 0) //取大的
                    ++i;
                if (temp.CompareTo(Array[i]) < 0)
                    break;
                Array[index] = Array[i];
                index = i;
                i = 2 * index + 1;
            }
            Array[index] = temp;
        }

        public void Insert(T num)
        {
            if (Array.Length <= Count)
            {
                var array = new T[Count * 2];
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
            Array[0] = Array[Count - 1];
            Array[Count - 1] = temp;
            Count--;
            int cur = 0;
            while (cur < Count)
            {
                int l = cur * 2 + 1;
                if (l >= Count) break;
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

    public class Point: IComparable
    {
        public int x;
        public int y;
        public int len => x*x + y*y;

        public Point(int xx, int yy)
        {
            x = xx;
            y = yy;
        }
        public int CompareTo(object a)
        {
            Point aa = (Point) a;

            if (len > aa.len)
                return 1;
            if (len == aa.len)
                return 0;
            return -1;
        }
    }
    public class Pair<T1, T2>
    {
        public T1 First;
        public T2 Second;

        public Pair(T1 first, T2 second)
        {
            this.First = first;
            this.Second = second;
        }

        public override bool Equals(object obj)
        {
            var o = (Pair<T1, T2>) obj;
            return (o.First.Equals(First) && o.Second.Equals(Second));
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }
    }

    public class DoubleListNode
    {
        public int val;
        public DoubleListNode next;
        public DoubleListNode prev;

        public DoubleListNode(int x)
        {
            val = x;
        }
    }
    public class GraphNode
    {
        public int id;
        public List<GraphNode> Next;
    }
    public class Graph
    {
        public int Count; //节点数量
        public Dictionary<int,GraphNode> Nodes;

        public Graph(int c)
        {
            Count = c;
            Nodes = new Dictionary<int, GraphNode>();
        }
    }

    public class QuadNode
    {
        public bool val;
        public bool isLeaf;
        public QuadNode topLeft;
        public QuadNode topRight;
        public QuadNode bottomLeft;
        public QuadNode bottomRight;

        public QuadNode()
        {
        }

        public QuadNode(bool _val, bool _isLeaf, QuadNode _topLeft, QuadNode _topRight, QuadNode _bottomLeft,
            QuadNode _bottomRight)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = _topLeft;
            topRight = _topRight;
            bottomLeft = _bottomLeft;
            bottomRight = _bottomRight;
        }
    }

 
    public class TopVotedCandidate
    {
        public int[] persons;
        public int[] times;
        public TopVotedCandidate(int[] persons, int[] times)
        {
            this.persons = persons;
            this.times = times;
        }


    }
}
