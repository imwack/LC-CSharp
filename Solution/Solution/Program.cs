using System;
using System.Collections.Generic;
using System.Linq;
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

                for (int j = 0; j < len/line; ++j)
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
                if (!lastIndex.ContainsKey(c))
                {
                    maxLen = Math.Max(i - start, maxLen);
                }
                else 
                {
                    maxLen = Math.Max(i - lastIndex[c], maxLen);
                    start = lastIndex[c];
                }
                lastIndex[c] = i;
            }

            return maxLen;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int ret = s.LongestSubStr("pwwkew");
            Console.WriteLine(ret);
        }
    }
}
