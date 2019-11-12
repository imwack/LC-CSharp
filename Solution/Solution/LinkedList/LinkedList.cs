using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {
        public ListNode Partition(ListNode head, int x)
        {
            ListNode less = new ListNode(0);
            ListNode great = new ListNode(0);
            ListNode h = head, l = less, g=great;
            while (h != null)
            {
                if (h.val < x)
                {
                    l.next = h;
                    l = l.next;
                }
                else
                {
                    g.next = h;
                    g = g.next;
                }
                h = h.next;
            }
            l.next = great.next;
            g.next = null;
            return less.next;
        }

        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode p = new ListNode(0);
            p.next = head;
            ListNode h = head, pre = p;
            while (h!=null)
            {
                bool dup = false;
                while (h.next != null && h.val ==h.next.val)
                {
                    h.next = h.next.next;
                    dup = true;
                }
                if (dup)
                {
                    pre.next = h.next;
                }
                else
                {
                    pre = pre.next;
                }
                h = h.next;
            }
            return p.next;
        }
        public ListNode RotateRight(ListNode head, int k)
        {
            int cnt = 0;
            ListNode temp = head;
            ListNode tail = temp;
            while (temp != null)
            {
                cnt++;
                if (temp.next == null)
                    tail = temp;
                temp = temp.next;
            }
            if (cnt == 0 || k == 0)
                return head;
            k = k % cnt;
            k = cnt - k;
            temp = head;
            for (int i = 0; i < k - 1; i++)
                temp = temp.next;
            tail.next = head;
            ListNode newHead = temp.next;
            temp.next = null;
            return newHead;
        }
        public void ReorderList(ListNode head)
        {
            if(head == null) return;
            ListNode slow = head, fast = head.next;
            while (fast != null)
            {
                fast = fast.next;
                if (fast != null) fast = fast.next;
                else break;
                slow = slow.next;
            }
            ListNode mid = slow.next;
            slow.next = null;

            //Reverse last part
            ListNode h = new ListNode(0);
            h.next = mid;
            ListNode pre = h;
            ListNode tail = pre.next;
            while (tail!=null && tail.next!=null)
            {
                ListNode nn = tail.next;
                tail.next = nn.next;
                nn.next = pre.next;
                pre.next = nn;
            }

            //Link
            ListNode temp = head;
            mid = h.next;
            while (temp!=null && mid!=null)
            {
                ListNode tnext = temp.next;
                ListNode mnext = mid.next;
                temp.next = mid;
                mid.next = tnext;
                temp = tnext;
                mid = mnext;
            }
 
        }
        public int[] NextLargerNodes(ListNode head)
        {
            Stack<Pair<int, int>> stack = new Stack<Pair<int, int>>();

            ListNode h = head;
            int cnt = 0;
            while (h!=null)
            {
                cnt++;
                h = h.next;
            }
            int[] result = new int[cnt];
            cnt = 0;
            h = head;
            while (h!=null)
            {
                if (stack.Count == 0)
                {
                    stack.Push(new Pair<int, int>(h.val, cnt));
                }
                else
                {
                    if (stack.Peek().First < h.val)
                    {
                        while (stack.Count>0 && stack.Peek().First<h.val)
                        {
                            result[stack.Peek().Second] = h.val;
                            stack.Pop();
                        }

                    }
                    stack.Push(new Pair<int, int>(h.val, cnt));
                }
                cnt++;
                h = h.next;
            }
            while (stack.Count>0)
            {
                result[stack.Peek().Second] = 0;
                stack.Pop();
            }
            return result;
        }
        // 876. Middle of the Linked List
        public ListNode MiddleNode(ListNode head)
        {
            ListNode slow = head, fast = head;
            while (fast != null)
            {
                fast = fast.next;
                if (fast == null)
                    return slow;
                fast = fast.next;
                slow = slow.next;
            }
            return slow;
        }
        public int[] DeckRevealedIncreasing(int[] deck)
        {
            Array.Sort(deck);
            int[] result = new int[deck.Length];
            LinkedList<int> list = new LinkedList<int>();
            for (int i = deck.Length - 1; i >= 0; i--)
            {
                if (list.Count > 0)
                {
                    int last = list.Last();
                    list.RemoveLast();
                    list.AddFirst(last);
                }
                list.AddFirst(deck[i]);
            }
            int index = 0;
            foreach (var i in list)
            {
                result[index++] = i;
            }
            return result;
        }
        public ListNode RemoveZeroSumSublists(List<int> values )
        {
            //List<int> values = new List<int>();
            //ListNode h = head;
            //while (h!=null)
            //{
            //    if(h.val != 0)
            //        values.Add(h.val);
            //    h = h.next;
            //}

            for (int start = 0; start < values.Count; start++)
            {
                int sum = 0, i=start;
                for (; i < values.Count; i++)
                {
                    sum += values[i];
                    if (sum == 0)
                    {
                        List<int> newValue = new List<int>();
                        for(int j=0;j<start;j++)
                            newValue.Add(values[j]);
                        for(int j = i+1;j<values.Count;j++)
                            newValue.Add(values[j]);
                        values = newValue;
                        start = -1;
                        break;
                    }
                }
            }
            ListNode newListNode = new ListNode(0);
            ListNode newHead = newListNode;
            foreach (var i in values)
            {
                newHead.next = new ListNode(i);
                newHead = newHead.next;
            }
            return newListNode.next;
        }
    }
}
