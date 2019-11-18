using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {
        //[8] String to Integer (atoi)
        public int MyAtoi(string str)
        {
            long value = 0;
            bool positive = true;
            str = str.Trim();
            if (str.Length == 0)
            {
                return 0;
            }
            int i = 0;
            if (str[i] == '-' || str[i] == '+')
            {
                positive = str[i] == '+';
                ++i;
            }
            for (; i < str.Length; i++)
            {
                if (str[i] >= '0' && str[i] <= '9')
                {
                    int digit = str[i] - '0';
                    value = value * 10 + digit;
                    if (value > int.MaxValue)
                    {
                        return positive ? int.MaxValue : int.MinValue;
                    }
                }
                else
                {
                    break;
                }
            }
            if (i == 0)
                return 0;
            if (!positive) value = -value;
            return (int)value;
        }

        //[13] Roman to Integer
        public int RomanToInt(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>
            {
                ['I'] = 1,
                ['V'] = 5,
                ['X'] = 10,
                ['L'] = 50,
                ['C'] = 100,
                ['D'] = 500,
                ['M'] = 1000
            };
            int n = 0;
            for (int i = 0;i<s.Length;i++)
            {
                if (i == s.Length - 1 || dic[s[i]] >= dic[s[i + 1]])
                {
                    n += dic[s[i]];
                }
                else
                {
                    n -= dic[s[i]];
                }
            }
            return n;
        }

        //[15] 3Sum
        public IList<IList<int>> ThreeSum2(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            System.Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }
                var ret = TwoSum(nums, i + 1, nums.Length - 1, nums[i]);
                foreach (var l in ret)
                {
                    result.Add(l);
                }
            }

            return result;
        }

        public List<List<int>> TwoSum(int[] nums, int l, int r, int tar)
        {
            List<List<int>> ret = new List<List<int>>();
            while (l < r)
            {
                if (nums[l] + nums[r] + tar == 0)
                {
                    ret.Add(new List<int>{tar, nums[l], nums[r]});
                    ++l;
                    --r;
                    while (l < nums.Length  && nums[l - 1] == nums[l])
                        ++l;
                    while (r >= 0 && nums[r + 1] == nums[r])
                        --r;
                }
                else if (nums[l] + nums[r] + tar < 0)
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
            return ret;
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            ListNode head = new ListNode(0);
            ListNode cur = head;
            SortedDictionary<int, ListNode> headToIndex = new SortedDictionary<int, ListNode>();
            for (int i = 0; i < lists.Length; i++)
            {
                if(lists[i]!=null)
                headToIndex[lists[i].val] = lists[i];
            }
            while (headToIndex.Count > 0)
            {
                var pair = headToIndex.First();
                cur.next = pair.Value;
                cur = cur.next;
                headToIndex.Remove(pair.Key);
                if (pair.Value.next != null)
                {
                    headToIndex[pair.Value.next.val] = pair.Value.next;
                }
            }
            return head.next;
        }
         

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (k == 1)
            {
                return head;
            }
            ListNode nHead = new ListNode(0);
            nHead.next = head;
            ListNode pre = nHead;
            ListNode first = head;

            while (first != null)
            {
                ListNode tail = first;
                for (int i = 0; i < k-1; i++)
                {
                    tail = tail.next;
                    if (tail == null)
                    {
                        return nHead.next;
                    }
                }
                pre.next = ReverseRange(first, tail);
                pre = first;
                first = first.next;
            }
            return nHead.next;
        }
        public ListNode ReverseRange(ListNode head, ListNode tail)
        {
            ListNode pre = new ListNode(0);
            pre.next = head;
            bool last = false;
            ListNode second = head.next;
            while (true)
            {
                if (second == tail)
                {
                    last = true;
                }
                head.next = second.next;
                second.next = pre.next;
                pre.next = second;
                second = head.next;
                if (last)
                {
                    break;
                }
            }
            return pre.next;
        }
    }
}
