using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList < IList < int >> result = new List<IList<int>>();
            Array.Sort(nums);

            for (int i = 0; i < nums.Length-3; i++)
            {
                if(i>0 && nums[i]==nums[i-1]) //去重
                    continue;
                int tar = target - nums[i];
                var xx = ThreeSum(nums, i + 1, nums.Length - 1, tar);
                foreach (IList<int> x in xx)
                {
                    result.Add(x);
                }
            }
            return result;
        }
        public IList<IList<int>> ThreeSum(int[] nums, int l, int r, int tar)
        {
            int last = nums[l - 1];
            IList<IList<int>> result = new List<IList<int>>();
            for (int i = l; i <= r-2; i++)
            {
                if (i > l && nums[i] == nums[i - 1])
                    continue; //去重
                int target = tar - nums[i];
                var two = TwoSum1(nums, i + 1, r, target);
                if (two.Count != 0)
                {
                    foreach (List<int> list in two)
                    {
                        list.Add(last);
                        result.Add(list);
                    }
                }
            }
            return result;
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue; //去重
                int target = nums[i];
                var two = TwoSum1(nums, i + 1, nums.Length - 1, -target);
                if (two.Count != 0)
                {
                    foreach (List<int> list in two)
                    {
                        result.Add(list);
                    }
                }
            }
            return result;
        }

        public List<List<int>> TwoSum1(int[] nums, int l, int r, int tar)
        {
            int cur = nums[l - 1];
            List<List<int>> result = new List<List<int>>();


            while (l<r)
            {

                if (nums[l] + nums[r] == tar)
                {
                    result.Add(new List<int>() { cur, nums[l],nums[r]});
                    l++;
                    while (l<r && nums[l]==nums[l-1])
                    {
                        l++;
                    }
                    r--;
                    while (r>l && nums[r]==nums[r+1])
                    {
                        r--;
                    }
                }
                else if (nums[l] + nums[r] < tar)
                    l++;
                else
                    r--;
            }
            return result;
        }

        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> pos = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                pos[nums[i]] = i;
            }
            Array.Sort(nums);
            int l = 0, r = nums.Length - 1;
            while (l < r)
            {
                if (nums[l] + nums[r] == target)
                {
                    return new int[] { pos[nums[l]], pos[nums[r]] };
                }
                if (nums[l] + nums[r] < target)
                {
                    l++;
                }
                else
                {
                    r--;
                }

            }
            return null;
        }


        #region array
        public int EqualSubstring(string s, string t, int maxCost)
        {
            int maxLen = 0, currentCost = 0;
            List<int> cost = new List<int>(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                cost.Add(Math.Abs(s[i] - t[i]));
            }
            int start = 0, end = 0;
            while (end < s.Length)
            {
                if (currentCost > maxCost)
                {
                    currentCost -= cost[start];
                    start++;
                }
                else
                {
                    currentCost += cost[end];
                    end++;
                }
                if (currentCost <= maxCost)
                {
                    maxLen = Math.Max(maxLen, end - start);
                }
            }
            return maxLen;
        }

        IList<IList<int>> path = new List<IList<int>>();

        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            IList<int> currentPath = new List<int>() {0};
            path.Add(currentPath);
            DfsAllPathsSourceTarget(graph, 0);
            return path;
        }

        public void DfsAllPathsSourceTarget(int[][] graph, int i)
        {
            if (i == graph.Length)
            {
                return;
            }
            int[] g = graph[i];
            IList<IList<int>> currentPath = new List<IList<int>>();
            foreach(var p in path)
                currentPath.Add(new List<int>(p));
            path.Clear();
            foreach (var p in currentPath)
            {
                foreach (var point in g)
                {
                    if (p.Last() != point)
                    {
                        IList<int> cur = new List<int>(p);
                        cur.Add(point);
                        path.Add(cur);
                    }
                }
            }
            DfsAllPathsSourceTarget(graph, i + 1);
        }

        public int MinAddToMakeValid(string S)
        {
            int left = 0, cnt = 0;
            foreach (char c in S)
            {
                if (c == '(')
                {
                    left++;
                }
                else
                {
                    if (left > 0)
                    {
                        left--;
                    }
                    else
                    {
                        cnt++;
                    }
                }
            }
            return cnt;
        }

        //015 
 

        public int RepeatedNTimes(int[] A)
        {
            for (int i = 2; i < A.Length; i++)
            {
                if (A[i] == A[i - 1] || A[i] == A[i - 2])
                {
                    return A[i];
                }
            }
            return A[0];
        }

        public int[] SortedSquares(int[] A)
        {
            int[] ret = new int[A.Length];
            int mid = 0, cur = 0;
            while (mid < A.Length && A[mid] < 0)
            {
                ++mid;
            }
            int l = mid - 1, r = mid;
            while (l >= 0 && r < A.Length)
            {
                if (Math.Abs(A[l]) < Math.Abs(A[r]))
                {
                    ret[cur++] = A[l] * A[l];
                    --l;
                }
                else
                {
                    ret[cur++] = A[r] * A[r];
                    ++r;
                }
            }
            while (l >= 0)
            {
                ret[cur++] = A[l] * A[l];
                --l;
            }
            while (r < A.Length)
            {
                ret[cur++] = A[r] * A[r];
                ++r;
            }

            return ret;
        }

        public int[] DiStringMatch(string S)
        {
            int[] ret = new int[S.Length + 1];
            int l = 0, r = S.Length, cur = 0;
            foreach (char c in S)
            {
                if (c == 'I')
                {
                    ret[cur++] = l++;
                }
                else
                {
                    ret[cur++] = r--;
                }
            }
            ret[cur] = l;
            return ret;
        }

        //852. Peak Index in a Mountain Array
        public int PeakIndexInMountainArray(int[] A)
        {
            int index = 1;
            while (A[index - 1] < A[index])
            {
                index++;
            }
            return index - 1;
        }
        #endregion
    }
    public partial class MySolution
    {
        public int Search(int[] nums, int target)
        {
            int l = 0, r = nums.Length - 1;
            while (l <= r)
            {
                int mid = (l + r) >> 1;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            return -1;
        }

        public IList<bool> PrefixesDivBy5(int[] A)
        {
            IList<bool> ret = new List<bool>(A.Length);
            int num = 0;
            foreach (int i in A)
            {
                num = num*2 + i;
                if(num%5==0)
                    ret.Add(true);
                else
                    ret.Add(false);
            }
            return ret;
        }
        public int NumPairsDivisibleBy60(int[] time)
        {
            int total = 0;
            int[] cnt = new int[60];
            for (int i = 0; i < time.Length; i++)
            {
                int remain = time[i] % 60;
                if (remain == 0)
                    total += cnt[0];
                else
                    total += cnt[60 - remain];
                ++cnt[remain];
            }
            return total;
        }

        public IList<int> AddToArrayForm(int[] A, int K)
        {
            LinkedList<int> l = new LinkedList<int>();
            int pre = 0;
            int lastId = A.Length - 1;
            while (K > 0 || lastId >= 0)
            {
                int n = pre;
                if (K > 0)
                {
                    n += K % 10;
                    K /= 10;
                }
                if (lastId >= 0)
                {
                    n += A[lastId--];
                }
                int last = n % 10;
                pre = n / 10;
                l.AddFirst(last);
            }
            if (pre > 0)
            {
                l.AddFirst(pre);
            }
            return l.ToList();
        }

        //874. Walking Robot Simulation
        public int RobotSim(int[] commands, int[][] obstacles)
        {
            int max = 0, d = 0, x = 0, y = 0;
            HashSet<string> s = new HashSet<string>();
            int[][] dir = new int[4][];
            dir[0] = new[] {0, 1};
            dir[1] = new[] {1, 0};
            dir[2] = new[] { 0, -1 };
            dir[3] = new[] { -1, 0 };
            foreach (var obstacle in obstacles)
            {
                s.Add(obstacle[0] + " " + obstacle[1]);
            }
            foreach (var command in commands)
            {
                if (command == -1)
                {
                    d = (d + 1)%4;
                }else if (command == -2)
                {
                    d = (d - 1)%4; --d;
                    if (d == -1)
                        d = 3;
                }
                else
                {
                    for (int i = 0; i < command; i++)
                    {
                        int a = x + dir[d][0];
                        int b = y + dir[d][1];
                        if (s.Contains(a +" " + b))
                        {
                            break;
                        }
                        x += dir[d][0];
                        y += dir[d][1];
                    }
                    max = Math.Max(max, x*x + y*y);
                }
            }
            return max;
        }

        public int LargestSumAfterKNegations(int[] A, int K)
        {
            Array.Sort(A);
            int negativeCount = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < 0)
                {
                    ++negativeCount;
                }
                else
                {
                    break;
                }
            }
            int cur = 0;
            while (K > 0 && cur< negativeCount)
            {
                A[cur] = -A[cur];
                cur++;
                K--;
            }
            Array.Sort(A);
            if (K > 0 && K % 2 == 1)
            {
                A[0] = -A[0];
            }
            return A.Sum();
        }

        public int HeightChecker(int[] heights)
        {
            int[] sHeight = new int[heights.Length];
            for (int i = 0; i < heights.Length; i++)
            {
                sHeight[i] = heights[i];
            }
            Array.Sort(sHeight);
            return heights.Where((t, i) => t != sHeight[i]).Count();
        }

        public int[] NumMovesStones(int a, int b, int c)
        {
            List<int> list = new List<int>() {a, b, c};
            list.Sort();
            if (list[2] - list[0] == 2) return new[] {0, 0};
            int min = Math.Min(list[1] - list[0], list[2] - list[1]) <= 2 ? 1 : 2;
            return new[] {min, list[2] - list[0] - 2};
        }

        private int GetMinMove(int a, int b, int c)
        {
            int minMove = 2;
            if (a - b == 1 || a - b == -1)
            {
                if (a - c == 1 || a - c == -1 || b - c == 1 || b - c == -1)
                    return 0;
                return 1;
            }
            if (a - c == 1 || a - c == -1)
            {
                if (a - b == 1 || a - b == -1 || b - c == 1 || b - c == -1)
                    return 0;
                return 1;
            }
            if (b - c == 1 || b - c == -1)
            {
                if (a - c == 1 || a - c == -1 || a - b == 1 || a - b == -1)
                    return 0;
                return 1;
            }
            if (Math.Abs(a - b) == 2 || Math.Abs(a - c) == 2 || Math.Abs(b - c) == 2)
                return 1;
            return minMove;
        }

        private int GetMaxMove(int a, int b, int c)
        {
            if((a > b && b>c) || (c>b && b>a))
            {
                return Math.Abs(a - b ) + Math.Abs(c - b ) - 2;
            }
            if( (a > c && c > b)||(b>c && c>a))
            {
                return Math.Abs(a - c) + Math.Abs(c - b) - 2;
            }

            return Math.Abs(a - c) + Math.Abs(a - b) - 2;
        }
        IList<IList<int>> candidate = new List<IList<int>>();
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            CombinationSum(0, candidates, target, new List<int>());
            return candidate;
        }

        public void CombinationSum(int index, int[] candidates, int target, List<int> cand)
        {
            if (target < 0)
            {
                return;
            }
            if (target == 0)
            {
                if (cand.Count > 0)
                {
                    candidate.Add(new List<int>(cand)); //cand is reference!!!
                }
                return;
            }
            for (int i = index; i < candidates.Length; i++)
            {
                cand.Add(candidates[i]);
                CombinationSum(i, candidates, target-candidates[i], cand);
                cand.RemoveAt(cand.Count-1);
            }
        }
        public int MovesToMakeZigzag(int[] nums)
        {
            int odd = 0, even = 0;
            for (int i = 0; i < nums.Length; i += 2)
            {
                if (i == 0)
                {
                    if (nums[i] >= nums[i + 1])
                    {
                        odd += nums[i] - nums[i + 1] + 1;
                    }
                }
                else
                {
                    int minor;
                    if (i + 1 < nums.Length)
                        minor = Math.Min(nums[i - 1], nums[i + 1]);
                    else
                        minor = nums[i - 1];
                    if (nums[i] >= minor)
                    {
                        odd += nums[i] - minor + 1;
                    }
                }
            }
            for (int i = 1; i < nums.Length; i += 2)
            {

                int minor;
                if (i + 1 < nums.Length)
                    minor = Math.Min(nums[i - 1], nums[i + 1]);
                else
                    minor = nums[i - 1];
                if (nums[i] >= minor)
                {
                    even += nums[i]-minor + 1;
                }
            }
            return Math.Min(odd, even);
        }
        public class SnapshotArray
        {
            Dictionary<int, List<int>> ops = new Dictionary<int, List<int>>();
            int[] arr;
            int cur = 0;
            public SnapshotArray(int length)
            {
                arr = new int[length];
            }

            public void Set(int index, int val)
            {
                if (!ops.ContainsKey(cur))
                    ops[cur] = new List<int>();
                ops[cur].Add(index);
                ops[cur].Add(val);
            }

            public int Snap()
            {
                cur++;
                return cur - 1;
            }

            public int Get(int index, int snap_id)
            {
                int cur = -1;
                for (int i = snap_id; i >= 0; i--)
                {
                    if (!ops.ContainsKey(i))
                        continue;
                    List<int> op = ops[i];
                    for (int j = op.Count - 2; j >= 0; j -= 2)
                    {
                        if (op[j] == index)
                        {
                            cur = op[j + 1];
                            break;
                        }
                    }
                    if (cur != -1)
                    {
                        break;
                    }
                }
                if (cur == -1) return 0;
                return cur;
            }
        }
        public int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            List<int> row = new List<int>();
            List<int> col = new List<int>();
            int sum = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                row.Add(grid[i][0]);
            }
            for (int i = 0; i < grid[0].Length; i++)
            {
                col.Add(grid[0][i]);
            }
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    row[i] = Math.Max(row[i], grid[i][j]);
                    col[j] = Math.Max(col[j], grid[i][j]);
                }
            }


            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    sum += Math.Min(row[i], col[j]) - grid[i][j];
                }
            }
            return sum;
        }
    }
}
