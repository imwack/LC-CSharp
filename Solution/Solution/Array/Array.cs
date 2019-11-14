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
        public int MinIncrementForUnique(int[] A)
        {
            int sum = 0;
            Array.Sort(A);
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] <= A[i - 1])
                {
                    sum = sum+A[i-1]-A[i]+1;

                    A[i] = A[i-1]-A[i]+1;
                }
            }
            return sum;
        }

        public int NthUglyNumber(int n)
        {
            List<int> dp = new List<int>() {1};
            int p2 = 0, p3 = 0, p5 = 0;
            for (int i = 1; i < n; i++)
            {
                dp[i] = Math.Min(Math.Min(dp[p2]*2, dp[p3]*3), dp[p5]*5);
                if (dp[i] == dp[p2] * 2) p2++;
                if (dp[i] == dp[p3] * 3) p3++;
                if (dp[i] == dp[p5] * 5) p5++;
            }

            return dp[n-1];
        }

        public bool Search2(int[] nums, int target)
        {
            int l = 0, r = nums.Length - 1;
            while (l <= r)
            {
                int mid = (r + l) / 2;
                if (nums[mid] == target) return true;
                if (nums[l] == nums[r] && nums[l] == nums[mid])
                {
                    l++;
                    r--;
                    continue;
                }
                if (nums[l] <= nums[mid]) //左边有序
                {
                    if (nums[l] <= target && nums[mid] > target)
                        r = mid - 1;
                    else
                        l = mid + 1;
                }
                else //右边有序
                {
                    if (nums[r] >= target && nums[mid] < target)
                        l = mid + 1;
                    else
                        r = mid - 1;
                }
            }
            return false;
        }

        public IList<int> MajorityElement(int[] nums)
        {
            IList<int> res = new List<int>();
            if (nums.Length == 0) return res;
            int a = 0, ca = 0, b = 0, cb = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == a)
                {
                    ca++; ;
                }
                else if (nums[i] == b)
                {
                    cb++;
                }
                else if (ca == 0)
                {
                    a = nums[i];
                    ca = 1;
                }
                else if (cb == 0)
                {
                    b = nums[i];
                    cb = 1;
                }
                else
                {
                    ca--;
                    cb--;
                }
            }
            //here we got a & b we need to check the count
            ca = 0;
            cb = 0;
            foreach (var num in nums)
            {
                if (num == a) ca++;
                if (num == b) cb++;
            }
            if (ca > nums.Length / 3) res.Add(a);
            if (cb > nums.Length / 3 && a != b) res.Add(b);
            return res;
        }
        public IList<string> SummaryRanges(int[] nums)
        {
            IList<string> list = new List<string>();
            if (nums.Length == 0)
                return list;
            string str;

            int start = nums[0], end = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == end + 1)
                {
                    end = nums[i];
                }
                else
                {
                    if (start == end)
                        str = start.ToString();
                    else
                        str = start.ToString() + "->" + end.ToString();
                    list.Add(str);
                    start = nums[i];
                    end = nums[i];
                }
            }
            if (start == end)
                str = start.ToString();
            else
                str = start.ToString() + "->" + end.ToString();
            list.Add(str);
            return list;
        }

        public int MinSubArrayLen(int s, int[] nums)
        {
            int sum = 0, len = 0;
            int l = 0, r = 0;
            while (r < nums.Length)
            {
                sum += nums[r];
                if (sum >= s)
                {
                    while (sum > s)
                    {
                        sum -= nums[l++];
                    }
                    if (len == 0) { len = r - l + 1 +1; }
                    else { len = Math.Min(r - l + 1 +1 , len); }
                }
                r++;
            }
            return len;
        }
        public void NextPermutation(int[] nums)
        {
            bool find = false;
            int index = 0;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] < nums[i + 1])
                {
                    find = true;
                    index = i;
                    break;
                }
            }
            if (!find) //降序
            {
                Reverse(nums,0,nums.Length-1);
            }
            else
            {
                int j = index;
                while (j+1<nums.Length && nums[j+1]>nums[index])
                {
                    j++;
                }
                int temp = nums[index];
                nums[index] = nums[j];
                nums[j] = temp;
                Reverse(nums,index+1,nums.Length-1);
            }
        }

        public void Reverse(int[] nums, int l, int r)
        {
            while (l < r)
            {
                int temp = nums[l];
                nums[l] = nums[r];
                nums[r] = temp;
                l++;
                r--;
            }
        }

        public int MinimumTotal(IList<IList<int>> triangle)
        {

            int[] min = new int[triangle.Count];
            for (int i = 0; i < triangle.Count; i++)
            {
                min[i] = triangle[triangle.Count - 1][i];
            }
            for (int i = triangle.Count - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    min[j] = Math.Min(min[j], min[j + 1]) + triangle[i][j];
                }
            }
            return min[0];
        }

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int cur = nums[0], cnt = 1, write = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == cur)
                {
                    cnt++;
                }
                else
                {
                    cnt = 1;
                    cur = nums[i];
                }
                if (cnt <= 2)
                {
                    nums[write++] = cur;
                }
            }
            return write;
        }

        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix.Length <= 0) return false;
            int row = 0, col = matrix[0].Length-1;
            while (row<matrix.Length && col>=0)
            {
                if (matrix[row][col] == target)
                    return true;
                else if (matrix[row][col] < target)
                    row++;
                else col--;

            }
            return false;
        }


        List<int> Father = new List<int>();

        public int Find(int x)
        {
            int f = Father[x];
            if (f != x)
            {
                Father[x] = Find(f);
            }
            return Father[x];
        }

        public void Union(int x, int y)
        {
            int fx = Find(x);
            int fy = Find(y);
            if (fx != fy)
            {
                Father[fx] = fy;
            }
        }
        public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            int len = s.Length;
            for(int i = 0;i<s.Length;i++)
                Father.Add(i);//默认自己
            foreach (IList<int> pair in pairs) //已经合并完成， 接下来吧合并的集合里的元素排序
            {
                Union(pair[0], pair[1]);
            }
            Dictionary<int, List<char>> setCharset = new Dictionary<int, List<char>>();
            Dictionary<int, int> setIndex = new Dictionary<int, int>();

            for (int i = 0; i < s.Length; i++)
            {
                int f = Find(i);
                if (!setCharset.ContainsKey(f))
                {
                    setCharset[f] = new List<char>();
                    setIndex[f] = 0;
                }
                setCharset[f].Add(s[i]);
            }
            foreach (var list in setCharset.Values)
            {
                list.Sort();
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                int f = Find(i);
                sb.Append(setCharset[f][setIndex[f]++]);
            }
            return sb.ToString();
        }

        IList<IList<int>> CombinationSum2Result = new List<IList<int>>();
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            CombinationSum2(candidates, 0, target, new List<int>());
            return CombinationSum2Result;
        }

        private void CombinationSum2(int[] candidates, int start, int target, List<int> path)
        {
            if (target < 0) return;
            if (target == 0)
            {
                CombinationSum2Result.Add(new List<int>(path));
                return;
            }
            for (int i = start; i < candidates.Length; i++)
            {
                if (i > start && candidates[i] == candidates[i - 1]) continue;

                if (candidates[i] > target) return;
                path.Add(candidates[i]);
                CombinationSum2(candidates, i + 1, target - candidates[i], path);
                path.RemoveAt(path.Count - 1);
            }
        }

        IList<IList<int>> CombinationResult = new List<IList<int>>();
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            List<int> cur = new List<int>();
            CombinationSum(candidates, target, 0, cur);
            return CombinationResult;
        }

        private void CombinationSum(int[] candidates, int target, int start, List<int> cur)
        {
            if (target < 0) return;
            if (target == 0)
            {
                CombinationResult.Add(new List<int>(cur));
                return;
            }
            for (int i = start; i < candidates.Length; i++)
            {
                cur.Add(candidates[i]);
                CombinationSum(candidates, target - candidates[i], i, cur);
                cur.RemoveAt(cur.Count - 1);
            }
        }
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
