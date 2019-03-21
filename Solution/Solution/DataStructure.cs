using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class Heap<T> where T : IComparable
    {
        public int Count;
        public T[] Nums;
        public T Peek => Nums[0];

        public void MakeHeap(T[] n)
        {
            Count = n.Length;
            Nums = new T[Count];
            for (int i =Count/2-1;i>=0;--i)
                AdjustDown(i);
        }

        public void Add(T n)
        {
            Nums[0] = n;
            AdjustDown(0);
        }
        //最大堆
        public void AdjustDown(int index)
        {
            int l = index*2 + 1;
            T cur = Nums[index];
            while (l<Count)
            {
                if (l + 1 < Count && Nums[l].CompareTo(Nums[l + 1])!=1) //取左右大的那个
                {
                    l++;
                }
                if(cur.CompareTo(Nums[l])==1)
                    break;
                T temp = Nums[index];
                Nums[index] = Nums[l];
                Nums[l] = temp;
                index = l;
                l = index*2 + 1;
            }
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

    public class Node
    {
        public int id;
        public List<Node> Next;
    }
    public class Graph
    {
        public int Count; //节点数量
        public Dictionary<int,Node> Nodes;

        public Graph(int c)
        {
            Count = c;
            Nodes = new Dictionary<int, Node>();
        }
    }

    public class DataStructure
    {
    }
}
