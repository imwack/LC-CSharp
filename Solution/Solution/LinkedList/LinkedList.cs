using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {
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
    }
}
