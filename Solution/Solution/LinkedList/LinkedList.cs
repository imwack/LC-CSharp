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
    }
}
