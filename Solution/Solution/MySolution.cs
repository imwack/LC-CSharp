using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class MySolution
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

                for (int j = 0; j <= len / line; ++j)
                {
                    int index = j * (2 * line - 2) + i;
                    if (index < len)
                        help[i].Add(s[index]);
                    if (i != 0 && i != line - 1)
                    {
                        int index2 = index + (line - i - 1) * 2;
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
            while (l < r)
            {
                int area = (r - l) * Math.Min(h[l], h[r]);
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
                    start = lastIndex[c] + 1;
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
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                int cur = i;
                int l = cur + 1, r = nums.Length - 1;
                while (l < r && l < nums.Length)
                {
                    if (nums[cur] + nums[l] + nums[r] == 0)
                    {
                        IList<int> tmp = new List<int>() { nums[cur], nums[l], nums[r] };
                        ret.Add(tmp);
                        ++l;
                        while (l < nums.Length && nums[l] == nums[l - 1])
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
            string[] code = { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            List<string> num = new List<string>();
            foreach (var c in number)
            {
                num.Add(code[c - '2']);
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
                if (tmp.Length > 0)
                    ret.Add(tmp);
                return;
            }
            for (int i = 0; i < num[id].Length; ++i)
            {
                cur += num[id][i];
                LetterCombinations(num, ret, cur, id + 1);
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
            if (curL > curR) return;

            if (curL == 0 && curR == 0)
            {
                ret.Add(new string(cur.ToArray()));
                return;
            }
            if (curL > 0)
            {
                cur.Add('(');
                GenerateParenthesis(ret, curL - 1, curR, cur, n);
                cur.RemoveAt(cur.Count - 1);
            }
            if (curR > 0 && curL < curR)
            {
                cur.Add(')');
                GenerateParenthesis(ret, curL, curR - 1, cur, n);
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
            while (pre.next != null)
            {
                ListNode first = pre.next;
                ListNode second = first.next;
                if (second == null) return head;
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
            int index = 0, index2 = 0;
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
            for (int i = index + 1; i < nums.Length; ++i)
            {
                if (nums[i] >= nums[index]) continue;
                index2 = i;
                break;
            }

            int temp = nums[index2];
            nums[index2] = nums[index];
            nums[index] = temp;
            Array.Sort(nums, index + 1, nums.Length - index - 1);

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
                int mid = l + (r - l) / 2;
                if (a == b * mid)
                    return mid;
                if (a - b * mid > 0)
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            if (a - b * l < b && a - b * l > 0) return l;
            return r;
        }

        public int HasNum(int[] nums, int tar)
        {
            int l = 0, r = nums.Length - 1, mid;
            while (l <= r)
            {
                mid = l + (r - l) / 2;
                if (nums[mid] == tar) return mid;
                if (nums[mid] > nums[l]) //[l,mid]升序
                {
                    if (tar > nums[l] && tar < nums[mid])
                        r = mid - 1;
                    else
                        l = mid + 1;
                }
                else //[mid,r]升序
                {
                    if (tar > nums[r] || tar < nums[mid])
                        r = mid - 1;
                    else
                        l = mid + 1;
                }
            }
            return -1;
        }

        public int CountPrimeSetBits(int L, int R)
        {
            int cnt = 0;
            HashSet<int> prime = new HashSet<int>(new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19 });
            for (int i = L; i <= R; i++)
            {
                int bit = 0;
                int n = i;
                while (n > 0)
                {
                    bit += n % 2;
                    n /= 2;
                }
                if (prime.Contains(bit)) cnt++;
            }

            return cnt;
        }
        double[,] dp = new double[500, 500];
        public double SoupServings(int N)
        {
            if (N > 5000) return 1;  //limit -> 1

            return SoupServings((N + 24) / 25, (N + 24) / 25);
        }
        public double SoupServings(int a, int b)
        {
            if (a <= 0 && b <= 0) return 0.5;
            if (a <= 0) return 1;
            if (b <= 0) return 0;
            if (dp[a, b] > 0) return dp[a, b];
            dp[a, b] = 0.25 * (SoupServings(a - 4, b) + SoupServings(a - 3, b - 1) + SoupServings(a - 2, b - 2) + SoupServings(a - 1, b - 3));
            return dp[a, b];
        }

        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            bool[] hasVisit = new bool[rooms.Count];
            HashSet<int> keys = new HashSet<int>();
            if (rooms.Count < 1) return true;
            dfsVisitAllRooms(hasVisit, rooms, keys, 0);
            return hasVisit.All(b => b);
        }

        private void dfsVisitAllRooms(bool[] hasVisit, IList<IList<int>> rooms, HashSet<int> keys, int curRoom)
        {
            hasVisit[curRoom] = true;
            foreach (var i in rooms[curRoom])
            {
                if (!keys.Contains(i) && i < rooms.Count)
                    keys.Add(i);
            }

            foreach (var room in keys)
            {
                if (!hasVisit[room])
                {
                    hasVisit[room] = true;
                    dfsVisitAllRooms(hasVisit, rooms, keys, room);
                    break;
                }
            }
        }
        public string ShiftingLetters(string S, int[] shifts)
        {
            List<char> dic = new List<char>();
            for (int i = shifts.Length - 2; i >= 0; --i)
            {
                shifts[i] += shifts[i + 1] % 26;
            }
            for (int i = 0; i < S.Length; ++i)
            {
                char c = (char)('a' + (S[i] - 'a' + shifts[i] % 26) % 26);
                dic.Add(c);
            }
            string ret = new string(dic.ToArray());
            return ret;
        }


        public string Tree2str(TreeNode t)
        {
            string str = string.Empty;
            Tree2str(t, str);
            return str;
        }
        private void Tree2str(TreeNode t, string str)
        {
            if (t == null) return;
        }
        public int FindLUSlength(string[] strs)
        {
            Array.Sort(strs, (a, b) => b.Length - a.Length); //降序
            HashSet<string> dup = new HashSet<string>(); //重复的string
            HashSet<string> tmp = new HashSet<string>();
            foreach (var str in strs)
            {
                if (!tmp.Contains(str))
                    tmp.Add(str);
                else if (!dup.Contains(str))
                    dup.Add(str);
            }
            for (int i = 0; i < strs.Length; ++i)
            {
                if (dup.Contains(strs[i])) //有重复的 不可能能为最长
                {
                    continue;
                }
                for (int j = 0; j < i; j++)
                {
                    if (IsSubSequence(strs[j], strs[i]))
                    {
                        break;
                    }
                    if (j == i - 1) return strs[i].Length;
                }

            }
            return -1;
        }

        public bool IsSubSequence(string a, string b)
        {
            //这里B的长度小于等于A 
            int i = 0, j = 0;
            foreach (char c in b)
            {
                bool find = false;
                for (int index = i; index < a.Length; index++)
                {
                    if (a[index] == c)
                    {
                        i = index + 1;
                        find = true;
                        break;
                    }
                }
                if (!find)
                    return false;
            }
            return true;
        }
        public string PredictPartyVictory(string senate)
        {
            Queue<int> R = new Queue<int>();
            Queue<int> D = new Queue<int>();
            for (int i = 0; i < senate.Length; i++)
            {
                if (senate[i] == 'R')
                    R.Enqueue(i);
                else
                    D.Enqueue(i);
            }
            while (R.Count > 0 && D.Count > 0)
            {
                int r = R.Dequeue(), d = D.Dequeue();
                if (r > d) D.Enqueue(d + senate.Length);
                else R.Enqueue(r + senate.Length);
            }
            return R.Count > D.Count ? "Radiant" : "Dire";
        }

        public IList<IList<string>> Partition(string s)
        {
            IList<IList<string>> ret = new List<IList<string>>();
            IList<string> cur = new List<string>();
            Partition(s, ret, cur);
            return ret;
        }

        private void Partition(string s, IList<IList<string>> ret, IList<string> cur)
        {
            if (s.Length == 0)
            {
                IList<string> temp = new List<string>(cur);
                ret.Add(temp);
                return;
            }
            for (int i = 1; i <= s.Length; i++)
            {
                string pre = s.Substring(0, i);
                if (isPalindrome(pre))
                {
                    cur.Add(pre);
                    Partition(s.Substring(i), ret, cur);
                    cur.RemoveAt(cur.Count - 1);
                }
            }
        }

        public bool isPalindrome(string s)
        {
            int l = 0, r = s.Length - 1;
            while (l < r)
            {
                if (s[l] != s[r]) return false;
                l++;
                r--;
            }
            return true;
        }

        //207. Course Schedule
        public bool CanFinish(int numCourses, int[,] prerequisites)
        {
            List<HashSet<int>> graph = new List<HashSet<int>>(numCourses);
            List<int> degree = new List<int>();
            for (int i = 0; i < numCourses; i++)
            {
                graph.Add(new HashSet<int>());
                degree.Add(0);
            }
            int cnt = prerequisites.GetLength(0);
            for (int i = 0; i < cnt; ++i)
            {
                int next = prerequisites[i, 1];
                int pre = prerequisites[i, 0];
                graph[pre].Add(next);
            }

            for (int i = 0; i < numCourses; i++)
            {
                degree[i] = graph[i].Count;
            }
            for (int i = 0; i < numCourses; i++)
            {
                int id;
                for (id = 0; id < numCourses; id++)
                    if (degree[id] == 0)
                        break;
                if (id == numCourses) return false; //没找到度为0
                degree[id] = -1;
                for (int j = 0; j < numCourses; j++)
                {
                    if (graph[j].Contains(id))
                        --degree[j];
                }
            }
            return true;
        }
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == q || root == p) return root;

            TreeNode l = LowestCommonAncestor(root.left, p, q);
            TreeNode r = LowestCommonAncestor(root.right, p, q);
            if (l != null && r != null) return root;
            return l ?? r;
        }
        public int[] FindOrder(int numCourses, int[,] prerequisites)
        {
            List<int> ret = new List<int>();
            List<HashSet<int>> graph = new List<HashSet<int>>(numCourses);
            List<int> degree = new List<int>();
            for (int i = 0; i < numCourses; i++)
            {
                graph.Add(new HashSet<int>());
                degree.Add(0);
            }
            int cnt = prerequisites.GetLength(0);
            for (int i = 0; i < cnt; ++i)
            {
                int next = prerequisites[i, 1];
                int pre = prerequisites[i, 0];
                graph[pre].Add(next);
            }
            Queue<int> zero = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if(degree[i] == 0)
                    zero.Enqueue(i);
            }
            while (zero.Count>0)
            {
                int front = zero.Dequeue();
                ret.Add(front);
                for (int i = 0; i < numCourses; i++)
                {
                    if (graph[i].Contains(front))
                    {
                        graph[i].Remove(front);
                        --degree[i];
                        if(degree[i] == 0)
                            zero.Enqueue(i);
                    }
                }
            }
            if (ret.Count == numCourses)
                return ret.ToArray();
            return new int[0];
        }
        public int Calculate(string s)
        {
            StringBuilder sb = new StringBuilder();
            Stack<int> st = new Stack<int>();
            char preSign = '+';
            sb.Clear();
            foreach (char c in s)
            {

                if (!IsSign(c))
                {
                    sb.Append(c);
                    continue;
                }
                int cur = int.Parse(sb.ToString());
                if (preSign == '+')
                {
                    st.Push(cur);
                }
                else if (preSign == '-')
                {
                    st.Push(-cur);
                }
                else if (preSign == '*')
                {
                    st.Push(st.Pop() * cur);
                }
                else if (preSign == '/')
                {
                    st.Push(st.Pop() / cur);
                }
                sb.Clear();
                preSign = c;
            }
            int ret = int.Parse(sb.ToString());
            while (st.Count > 0)
            {
                ret += st.Pop();
            }
            return ret;
        }

        public bool IsSign(char c)
        {
            return c == '+' || c == '-' || c == '/' || c == '*';
        }

        public string LargestNumber(int[] nums)
        {
            string[] strs = nums.Select(num => num.ToString()).ToArray();
            Array.Sort(strs, (a, b) =>
            {
                long ab = long.Parse(a + b);
                long ba = long.Parse(b + a);
                if(ab>ba)
                    return -1;
                else
                    return  1;
            });
            if (strs[0].StartsWith("0"))
                return "0";
            StringBuilder sb = new StringBuilder();
            foreach (var str in strs)
            {
                sb.Append(str);
            }
            return sb.ToString();
        }
        public double MyPow(double x, int n)
        {
            if (n == 0) return 1;
            double xx = 1.0;
            for (int i = 0; i < n; i++)
                xx *= x;
            if (n > 0)
            {
                return xx;
            }
            return 1.0/xx;

        }
        public int EvalRPN(string[] tokens)
        {
            Stack<int> stack = new Stack<int>();
            foreach (var str in tokens)
            {
                if (str == "+" || str == "-" || str == "*" || str == "/")
                {
                    int a = stack.Pop();
                    int b = stack.Pop();
                    int ret;
                    switch (str)
                    {
                        case "+":
                            stack.Push(a+b);
                            break;
                        case "-":
                            stack.Push(a-b);
                            break;
                        case "*":
                            stack.Push(a*b);
                            break;
                        case "/":
                            stack.Push(a/b);
                            break;
                    }
                }
                else
                {
                    stack.Push(int.Parse(str));
                }
            }
            return stack.Pop();
        }
    }
}
