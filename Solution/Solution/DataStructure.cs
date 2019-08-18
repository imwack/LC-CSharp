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

    public class LinkedListNode
    {
        public int val;
        public LinkedListNode pre;
        public LinkedListNode next;

        public LinkedListNode(int v)
        {
            this.val = v;
            pre = null;
            next = null;
        }
    }
    public class MyLinkedList
    {
        private LinkedListNode head;
        private LinkedListNode tail;

        public int Count = 0;
        /** Initialize your data structure here. */
        public MyLinkedList()
        {
            head = new LinkedListNode(-1);
            tail = new LinkedListNode(-1);
            head.next = tail;
            tail.pre = head;
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            if (index >= Count || index <0)
            {
                return -1;
            }
            LinkedListNode tmp = head.next;
            for (int i = 0; i < index; i++)
            {
                tmp = tmp.next;
            }
            return tmp.val;
        }

        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(int val)
        {
            LinkedListNode headNext = head.next;
            LinkedListNode newNode = new LinkedListNode(val);
            head.next = newNode;
            newNode.pre = head;
            newNode.next = headNext;
            headNext.pre = newNode;
            Count++;
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            LinkedListNode newNode = new LinkedListNode(val);
            LinkedListNode tailPre = tail.pre;
            newNode.pre = tailPre;
            tailPre.next = newNode;
            newNode.next = tail;
            tail.pre = newNode;
            Count++;
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            if (index == -1 && Count == 0)
            {
                AddAtTail(val);
                return;
            }
            if (index <= Count && index >= 0)
            {
                LinkedListNode tmp = head;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.next;
                }
                if (tmp == tail)
                {
                    AddAtTail(val);
                }
                else
                {
                    LinkedListNode tmpNext = tmp.next;
                    LinkedListNode newNode = new LinkedListNode(val);
                    tmp.next = newNode;
                    newNode.pre = tmp;
                    newNode.next = tmpNext;
                    tmpNext.pre = newNode;
                    Count++;
                }
            }
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            if (index < Count && index >= 0)
            {
                LinkedListNode tmp = head.next;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.next;
                }
                LinkedListNode tmpPre = tmp.pre;
                LinkedListNode tmpNext = tmp.next;

                tmpPre.next = tmpNext;
                tmpNext.pre = tmpPre;
                Count--;
            }
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
