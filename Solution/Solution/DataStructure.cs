using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class Pair<T1, T2>
    {
        public T1 Key;
        public T2 Value;

        public Pair(T1 key, T2 value)
        {
            this.Key = key;
            this.Value = value;
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

    public class DataStructure
    {
    }
}
