using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {
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
