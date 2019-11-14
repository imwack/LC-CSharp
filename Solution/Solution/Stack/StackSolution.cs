using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {
        #region stack
        public bool Find132pattern(int[] nums)
        {
            int curMax = Int32.MinValue;
            Stack<int> stack = new Stack<int>();
            for (int i = nums.Length-1;i>=0; i--)
            {
 
                if (nums[i] < curMax)
                    return true;

                if (stack.Peek() < nums[i])
                {
                    while (stack.Count>0 && stack.Peek() < nums[i])
                    {
                        curMax = stack.Peek();
                        stack.Pop();
                    }
                }
                stack.Push(nums[i]);

            }
            return false;
        }

        public string RemoveOuterParentheses(string S)
        {
            int l = 0, r = 0;
            StringBuilder ret = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach(char c in S)
            {
                if (c == '(')
                {
                    l++;
                    if (!first)
                    {
                        sb.Append(c);
                    }
                    else
                    {
                        first = false;
                    }
                }
                else
                {
                    r++;
                    if (l == r)
                    {
                        ret.Append(sb);
                        sb.Clear();
                        first = true;
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
            }
            return ret.ToString();
        }



        public string RemoveDuplicates(string S)
        {
            Stack<char> queue = new Stack<char>();
            foreach (char c in S)
            {
                bool find = false;
                while (queue.Count > 0 && queue.Peek() == c)
                {
                    queue.Pop();
                    find = true;
                }
                if (!find)
                {
                    queue.Push(c);
                }
            }
            StringBuilder sb = new StringBuilder();
            while (queue.Count > 0)
                sb.Insert(0, queue.Pop());
            return sb.ToString();
        }

        public int CalPoints(string[] ops)
        {
            Stack<int> point = new Stack<int>();
            int sum = 0;
            foreach (var op in ops)
            {
                if (op == "C")
                {
                    sum -= point.Pop();
                }
                else if (op == "D")
                {
                    sum += 2 * point.Peek();
                    point.Push(point.Peek() * 2);
                }
                else if (op == "+")
                {
                    int a = point.Pop();
                    int b = point.Pop();
                    sum += a + b;
                    point.Push(b);
                    point.Push(a);
                    point.Push(a + b);
                }
                else
                {
                    //分数
                    int p = int.Parse(op);
                    point.Push(p);
                    sum += p;
                }
            }
            return sum;
        }

        public int[] NextGreaterElement(int[] findNums, int[] nums)
        {
            Stack<int> stack = new Stack<int>();
            Dictionary<int, int> nextGreat = new Dictionary<int, int>();
            int i = 0;
            while (i < nums.Length)
            {
                while (stack.Count == 0 || stack.Peek() > nums[i])
                {
                    stack.Push(nums[i++]);
                    if (i == nums.Length)
                        break;
                }
                if (i < nums.Length)
                {
                    while (stack.Count > 0 && nums[i] > stack.Peek())
                    {
                        nextGreat[stack.Pop()] = nums[i];
                    }
                }
            }
            for (i = 0; i < findNums.Length; i++)
            {
                if (nextGreat.ContainsKey(findNums[i]))
                {
                    findNums[i] = nextGreat[findNums[i]];
                }
                else
                {
                    findNums[i] = -1;
                }
            }
            return findNums;
        }

        public bool BackspaceCompare(string S, string T)
        {
            Stack<char> s = new Stack<char>();
            Stack<char> t = new Stack<char>();
            foreach (char ss in S)
            {
                if (ss == '#')
                {
                    if (s.Count > 0)
                        s.Pop();
                }
                else
                {
                    s.Push(ss);
                }
            }
            foreach (var tt in T)
            {
                if (tt == '#')
                {
                    if (t.Count > 0)
                        t.Pop();
                }
                else
                {
                    t.Push(tt);
                }
            }
            while (s.Count > 0)
            {
                if (t.Count <= 0) return false;
                if (s.Pop() != t.Pop())
                    return false;
            }

            return t.Count == 0;
        }



        public int[] DailyTemperatures(int[] T)
        {
            Stack<Pair<int, int>> stack = new Stack<Pair<int, int>>();
            List<int> ret = new List<int>();
            for (int i = 0; i < T.Length; i++)
                ret.Add(0);

            for (int i = 0; i < T.Length; i++)
            {
                int cur = T[i];
                while (stack.Count > 0)
                {
                    if (stack.Peek().First < cur)
                    {
                        var top = stack.Pop();
                        ret[top.Second] = i - top.Second;
                    }
                    else
                    {
                        break;
                    }
                }
                stack.Push(new Pair<int, int>(cur, i));
            }
            return ret.ToArray();
        }

        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            int cur = 0;
            Stack<int> stack = new Stack<int>();
            foreach (var pp in popped)
            {
                while (stack.Count == 0 || stack.Peek() != pp)
                {
                    if (cur >= pushed.Length) //push完了
                        return false;
                    stack.Push(pushed[cur++]);
                }
                stack.Pop();
            }
            return true;
        }

        public int ScoreOfParentheses(string S)
        {
            int sum = 0;
            Stack<int> stack = new Stack<int>();
            foreach (char c in S)
            {
                if (c == '(')
                    stack.Push(-1);
                else
                {
                    int cnt = 0;
                    while (stack.Peek() != -1)
                    {
                        cnt += stack.Pop();
                    }
                    stack.Pop();
                    stack.Push(cnt == 0 ? 1 : cnt * 2);
                }
            }
            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }
            return sum;
        }


        public IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> ret = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var top = stack.Pop();
                if (top != null)
                {
                    if (top.left == null)
                        ret.Add(top.val);
                    if (top.right != null)
                        stack.Push(top.right);
                    if (top.left != null)
                    {
                        stack.Push(new TreeNode(top.val));
                        stack.Push(top.left);
                    }
                }
            }
            return ret;
        }

        public IList<int> PreorderTraversal(TreeNode root)
        {
            IList<int> pre = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            if (root != null)
                stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode front = stack.Pop();
                if (front != null)
                {
                    pre.Add(front.val);
                    if (front.right != null)
                        stack.Push(front.right);
                    if (front.left != null)
                        stack.Push(front.left);
                }
            }

            return pre;
        }

        public int[] NextGreaterElements(int[] nums)
        {
            int[] ret = new int[nums.Length];
            Stack<Pair<int, int>> stack = new Stack<Pair<int, int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                ret[i] = -1;
                if (stack.Count == 0)
                {
                    stack.Push(new Pair<int, int>(nums[i], i));
                }
                else
                {
                    while (stack.Count > 0 && nums[i] > stack.Peek().First)
                    {
                        ret[stack.Pop().Second] = nums[i];
                    }
                    stack.Push(new Pair<int, int>(nums[i], i));
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                while (stack.Count > 0 && nums[i] > stack.Peek().First)
                {
                    ret[stack.Pop().Second] = nums[i];
                }
            }


            return ret;
        }


        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            int[] times = new int[n];
            Stack<Pair<int, int>> stack = new Stack<Pair<int, int>>();
            int preTime = 0;
            foreach (var log in logs)
            {
                string[] s = log.Split(':');
                int id = int.Parse(s[0]);
                string type = s[1];
                int time = int.Parse(s[2]);

                if (stack.Count > 0)
                {
                    if (stack.Peek().First == id)
                    {
                        //id相同 
                        if (type == "end")
                        {
                            times[id] += time - preTime + 1;
                            stack.Pop();
                        }
                        else
                        {
                            times[id] += time - preTime;
                            stack.Push(new Pair<int, int>(id, time));
                        }
                    }
                    else
                    {
                        //id不同
                        times[stack.Peek().First] += time - preTime + 1;
                        stack.Push(new Pair<int, int>(id, time));
                    }
                }
                else
                    stack.Push(new Pair<int, int>(id, time));
                preTime = time;
            }
            return times;

        }

        public string DecodeString(string s)
        {
            StringBuilder sb = new StringBuilder();
            Stack<char> stack = new Stack<char>();
            Stack<string> strStack = new Stack<string>();
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] != ']')
                {
                    stack.Push(s[i]);
                }
                else
                {
                    string str = string.Empty, ss = string.Empty;
                    while (stack.Peek() != '[')
                    {
                        str += stack.Pop();
                    }
                    stack.Pop(); //移除[
                    int num = 0, e = 1;
                    while (stack.Count > 0 && stack.Peek() >= '0' && stack.Peek() <= '9')
                    {
                        num += (stack.Pop() - '0') * e;
                        e *= 10;
                    }
                    foreach (var c in str.Reverse())
                    {
                        ss += c;
                    }
                    if (strStack.Count > 0)
                        ss += strStack.Pop();
                    for (int j = 0; j < num; ++j)
                        sb.Append(ss);
                    strStack.Push(sb.ToString());
                }
            }
            return sb.ToString();
        }


        #endregion
    }

}
