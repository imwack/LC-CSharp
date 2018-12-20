using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class Solution
    {
        public string ZigZag(string s, int line)
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

        //003
        public int LongestSubStr(string str)
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
        public IList<string> PhoneNum(string number)
        {
            string[] code = {"abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};
            List<string> num = new List<string>();
            foreach (var c in number)
            {
                num.Add(code[c-'2']);
            }
            IList<string> ret = new List<string>();
            string cur = string.Empty;
            PhoneNumAll(num, ret, cur, 0);
            return ret;
        }

        private void PhoneNumAll(List<string> num, IList<string> ret, string cur, int id)
        {
            if (id == num.Count)
            {
                string tmp = string.Copy(cur);
                ret.Add(tmp);
                return;
            }
            for (int i = 0; i < num[id].Length; ++i)
            {
                cur += num[id][i];
                PhoneNumAll(num,ret,cur,id+1);
                cur = cur.Substring(0, cur.Length - 1);
            }
        }
        //022
        public IList<string> GenerateParent(int n)
        {
            IList<string> ret = new List<string>();
            List<char> cur = new List<char>();
            GenerateParent(ret, n, n, cur, n);
            return ret;
        }

        private void GenerateParent(IList<string> ret, int curL, int curR, List<char> cur, int n)
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
                GenerateParent(ret, curL - 1, curR, cur, n);
                cur.RemoveAt(cur.Count-1);
            }
            if (curR > 0 && curL<curR)
            {
                cur.Add(')');
                GenerateParent(ret, curL , curR -1, cur, n);
                cur.RemoveAt(cur.Count - 1);
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Solution s = new Solution();
            int[] n = new[] {-1, -1, 0, 1, 2, 4};
            var ret = s.ZigZag("abcdefe",2);
            Console.WriteLine(ret);
            stopwatch.Stop();
            TimeSpan timespan = stopwatch.Elapsed;
            var second = timespan.TotalSeconds;
            Console.WriteLine(second);
        }
    }
}
