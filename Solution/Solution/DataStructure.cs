using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
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
