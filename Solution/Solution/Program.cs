using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }
    }
        
    public class Solution
    {
        //006 wrong
        public string Convert(string s, int line)
        {
            string ret = string.Empty;
            int len = s.Length;
            List<char>[] help = new List<char>[line];
            for (int i = 0; i < line; ++i)
            {
                help[i] = new List<char>();

                for (int j = 0; j <= len/line; ++j)
                {
                    int index = j*(2*line - 2) + i;
                    if(index<len)
                        help[i].Add(s[index]);
                    if (i != 0 && i != line - 1)
                    {
                        int index2 = index + (line - i - 1)*2;
                        if (index2 < len)
                            help[i].Add(s[index2]);
                    }
                }
                
            }
            foreach (var lst in help)
            {
                ret = lst.Aggregate(ret, (current, c) => current + c);
            }
            return ret;
        }
    
        //011
        public int MaxArea(int[] h)
        {
            int maxArea = 0;
            int l = 0, r = h.Length - 1;
            while (l<r)
            {
                int area = (r - l)*Math.Min(h[l], h[r]);
                maxArea = Math.Max(maxArea, area);
                if (h[l] > h[r]) --r;
                else ++l;
            }
            return maxArea;
        }

        //003 wrong
        public int LengthOfLongestSubstring(string str)
        {
            int maxLen = 0, start = -1;
            Dictionary<char, int> lastIndex = new Dictionary<char, int>();

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (lastIndex.ContainsKey(c))
                    start = lastIndex[c]+1;
                maxLen = Math.Max(i - start, maxLen);

                lastIndex[c] = i;
            }

            return maxLen;
        }

        //015 
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> ret = new List<IList<int>>();
            for (int i = 0; i < nums.Length; ++i)
            {
                if(i>0 && nums[i]==nums[i-1]) continue;

                int cur = i;
                int l = cur + 1, r = nums.Length - 1;
                while (l<r && l<nums.Length)
                {
                    if (nums[cur] + nums[l] + nums[r] == 0)
                    {
                        IList<int> tmp = new List<int>() { nums[cur] , nums[l] , nums[r] };
                        ret.Add(tmp);
                        ++l;
                        while (l<nums.Length && nums[l]==nums[l-1])
                        {
                            ++l;
                        }
                    }
                    else if (nums[cur] + nums[l] + nums[r] < 0)
                        ++l;
                    else
                        --r;
                }

            }
            return ret;
        }

        //017
        public IList<string> LetterCombinations(string number)
        {
            string[] code = {"abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};
            List<string> num = new List<string>();
            foreach (var c in number)
            {
                num.Add(code[c-'2']);
            }
            IList<string> ret = new List<string>();
            string cur = string.Empty;
            LetterCombinations(num, ret, cur, 0);
            return ret;
        }

        private void LetterCombinations(List<string> num, IList<string> ret, string cur, int id)
        {
            if (id == num.Count)
            {
                string tmp = string.Copy(cur);
                if(tmp.Length>0)
                    ret.Add(tmp);
                return;
            }
            for (int i = 0; i < num[id].Length; ++i)
            {
                cur += num[id][i];
                LetterCombinations(num,ret,cur,id+1);
                cur = cur.Substring(0, cur.Length - 1);
            }
        }
        //022
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> ret = new List<string>();
            List<char> cur = new List<char>();
            GenerateParenthesis(ret, n, n, cur, n);
            return ret;
        }

        private void GenerateParenthesis(IList<string> ret, int curL, int curR, List<char> cur, int n)
        {
            if(curL>curR) return;
            
            if (curL == 0 && curR == 0)
            {
                ret.Add(new string(cur.ToArray()));
                return;
            }
            if (curL > 0)
            {
                cur.Add('(');
                GenerateParenthesis(ret, curL - 1, curR, cur, n);
                cur.RemoveAt(cur.Count-1);
            }
            if (curR > 0 && curL<curR)
            {
                cur.Add(')');
                GenerateParenthesis(ret, curL , curR -1, cur, n);
                cur.RemoveAt(cur.Count - 1);
            }
        }

        //016
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            if (nums.Length < 3) return 0;
            int ret = nums[0] + nums[1] + nums[2];
            for (int i = 0; i < nums.Length; ++i)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int cur = i;
                int l = cur + 1, r = nums.Length - 1;
                while (l < r && l < nums.Length)
                {
                    int sum = nums[cur] + nums[l] + nums[r];
                    if (Math.Abs(sum - target) < Math.Abs(ret - target))
                        ret = sum;

                    if (sum == target)
                    {
                        return target;
                    }
                    else if (sum < target)
                        ++l;
                    else
                        --r;
                }
            }
            return ret;
        }
        //024
        public ListNode SwapPairs(ListNode head)
        {
            ListNode pre = new ListNode(0);
            pre.next = head;
            bool fistTime = true;
            while (pre.next!=null)
            {
                ListNode first = pre.next;
                ListNode second = first.next;
                if(second==null) return head;
                ListNode third = second.next;

                first.next = third;
                second.next = first;
                pre.next = second;
                pre = first;
                if (fistTime)
                {
                    fistTime = false;
                    head = second;
                }
            }
            return head;
        }
        
        //031
        public int[] NextPermutation(int[] nums)
        {
            bool orderFlag = true;
            int index=0,index2=0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    orderFlag = false;
                    index = i;
                    break;
                }
            }
            if (orderFlag)
            {
                Array.Sort(nums);
                return nums;
            }
            for (int i = index+1; i < nums.Length; ++i)
            {
                if (nums[i] >= nums[index]) continue;
                index2 = i;
                break;
            }
            
            int temp = nums[index2];
            nums[index2] = nums[index];
            nums[index] = temp;
            Array.Sort(nums,index+1, nums.Length-index-1);

            return nums;
        }

        //029
        public int DivideInteger(int a, int b)
        {
            bool sign = (a > 0 && b > 0) || (a < 0 && b < 0);
            int mul = -1;
            if (sign) mul = 1;
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a < b) return 0;
            int l = 1, r = a;
            while (l < r)
            {
                int mid = l + (r-l)/2;
                if (a == b*mid)
                    return mid;
                if (a - b*mid > 0)
                    l = mid + 1;
                else
                    r = mid - 1; 
            }
            if (a - b*l < b && a-b*l>0) return l;
            return r;
        }

        public int HasNum(int[] nums, int tar)
        {
            int l = 0, r = nums.Length - 1, mid;
            while (l<=r)
            {
                mid = l + (r - l)/2;
                if(nums[mid] == tar) return mid;
                if (nums[mid] > nums[l]) //[l,mid]升序
                {
                    if (tar > nums[l] && tar < nums[mid])
                        r = mid-1;
                    else
                        l = mid+1;
                }
                else //[mid,r]升序
                {
                    if (tar > nums[r] || tar < nums[mid])
                        r = mid-1;
                    else
                        l = mid+1;
                }
            }
            return -1;
        }
    }
    


    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Solution s = new Solution();
            int[] n = new[] {4,5,6,7,0,1,2};
            var ret = s.HasNum(n,0);

            stopwatch.Stop();
            TimeSpan timespan = stopwatch.Elapsed;
            var second = timespan.TotalSeconds;
            Console.WriteLine(second);
        }
    }
}
