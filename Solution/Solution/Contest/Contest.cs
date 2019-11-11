using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Contest
{
    public class Contest
    {
        public int ClosedIslandCnt = 0;
        public int ClosedIsland(int[][] grid)
        {
            if (grid.Length == 0 || grid[0].Length == 0)
                return 0;
            int[,] visit = new int[grid.Length,grid[0].Length];
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    ClosedIsland(grid, visit, i, j, i, j);
                }
            }
            return ClosedIslandCnt;
        }

        public bool ClosedIsland(int[][] grid, int[,] visit, int i, int j, int si, int sj)
        {
            if (visit[i, j] == 1) return true;
            if (visit[i, j] == 2) return false;

            if (grid[i][j] == 1) return true;
            visit[i, j] = 1;
            if (i - 1 == -1)
            {
                visit[i, j] = 2;
                return false;
            }
            bool left = ClosedIsland(grid, visit, i - 1, j,si,sj);

            if (j - 1 == -1)
            {
                visit[i, j] = 2;
                return false;
            }
            bool up = ClosedIsland(grid, visit, i, j-1, si, sj);

            if (i + 1 == grid.Length)
            {
                visit[i, j] = 2;
                return false;
            }
            bool down = ClosedIsland(grid, visit, i+1, j, si, sj);

            if (j + 1 == grid[0].Length)
            {
                visit[i, j] = 2;
                return false;
            }
            bool right = ClosedIsland(grid, visit, i, j + 1, si, sj);
            if (left && right && up && down)
            {
                if (i == si && j == sj)
                {
                    Console.WriteLine(si + "  " + sj);
                    ClosedIslandCnt++;
                }
                visit[i, j] = 1;
                return true;
            }
            else
            {
                visit[i, j] = 2;
            }
            return false;
        }

        public IList<IList<int>> ReconstructMatrix(int upper, int lower, int[] colsum)
        {
            IList<IList<int>> resultM = new List<IList<int>>();
            IList < int > up = new List<int>();
            IList < int > lo = new List<int>();
            int sum = 0;
            foreach (var i in colsum)
            {
                sum += i;
            }
            if (upper + lower != sum) return resultM;

            for (int i = 0; i < colsum.Length; i++)
            {
                if (colsum[i] == 2)
                {
                    colsum[i] = 0;
                    up.Add(1);
                    upper--;
                    lo.Add(1);
                    lower--;
                    if (upper < 0 || lower < 0)
                        return resultM;
                }
                else
                {
                    up.Add(0);
                    lo.Add(0);
                }
            }

            for (int i = 0; i < colsum.Length; i++)
            {
                if (colsum[i] > 0)
                {
                    if (upper > 0)
                    {
                        upper--;
                        up[i] =1;
                    }
                    else if (lower > 0)
                    {

                        lower--;
                        lo[i] = 1;
                    }
                    else
                    {
                        return resultM;
                    }
                }

            }
            resultM.Add(up);
            resultM.Add(lo);
            return resultM;
        }

        public int OddCells(int n, int m, int[][] indices)
        {
            int cnt = 0;
            int[,] cells = new int[n,m];
            foreach (var indice in indices)
            {
                int row = indice[0];
                int col = indice[1];
                for (int i = 0; i < m; i++)
                {
                    cells[row, i]++;
                }
                for (int j = 0; j < n; j++)
                {
                    cells[j, col]++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (cells[i, j]%2 == 1)
                        cnt++;
                }
            }
            return cnt;
        }
        public string MinRemoveToMakeValid(string s)
        {
            int left = 0, right=0;
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if (c == '(')
                {
                    left++;
                    sb.Append(c);
                }
                else if (c == ')')
                {
                    if (left > 0)
                    {
                        left--;
                        sb.Append(c);
                        right++;
                    }
                }
                else
                {
                    sb.Append(c);
                }
            }
            if (left > 0)
            {
                StringBuilder sb2 = new StringBuilder();
                foreach (var c in sb.ToString())
                {
                    if (c == '(' && left > 0)
                    {
                        if (right > 0)
                        {
                            right--;
                            sb2.Append(c);
                        }
                        else
                        {
                            left--;
                        }
                    }
                    else
                    {
                        sb2.Append(c);
                    }
                }
                return sb2.ToString();
            }
            else
            {
                return sb.ToString();
            }
        }

        public int MinimumSwap(string s1, string s2)
        {
            StringBuilder ss1= new StringBuilder();
            StringBuilder ss2 = new StringBuilder();
            int s1x = 0, s1y = 0, s2x = 0, s2y = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] == s2[i])
                {
                    continue;
                }
                else
                {
                    ss1.Append(s1[i]);
                    ss2.Append(s2[i]);
                    if (s1[i] == 'x')
                    {
                        s1x++;
                        s2y++;
                    }
                    else
                    {
                        s1y++;
                        s2x++;
                    }
                }
            }
            if ((s2x + s1x) %2 != 0) return -1;
            if (s1x == s2x && s1y == s2y)
            {
                
            }
            return -1;
        }

        public int NumberOfSubarrays(int[] nums, int k)
        {
            int cnt = 0;
            List<int> odd = new List<int>(nums.Length);
            int pre = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i]%2 == 1)
                {
                    pre += 1;
                    odd.Add(pre);
                }
                else
                {
                    odd.Add(pre);
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j < nums.Length; j++)
                {
                    if (i>0 && odd[j] - odd[i-1] == k)
                        cnt++;
                    if (i == 0 && odd[j] == k)
                        cnt++;
                }
            }
            return cnt;
        }
        public IList<int> TransformArray(int[] arr)
        {
            List<int> last = new List<int>(arr);
            List<int> now = new List<int>(arr);

            int i = 0;
            bool change = true;
            while (change)
            {
                change = false;
                for (int j = 1; j < last.Count - 1; j++)
                {
                    if (last[j] > last[j - 1] && last[j] > last[j + 1])
                    {
                        now[j]--;
                        change = true;
                    }
                    else if (last[j] < last[j - 1] && last[j] < last[j + 1])
                    {
                        now[j]++;
                        change = true;
                    }
                }
                last = new List<int>(now);
            }
            return last;
        }

        int maxLen = 0;
        public int MaxLength(IList<string> arr)
        {
            int[] cnt = new int[26];
            GetMaxLength(0,0, arr, cnt);
            return maxLen;
        }

        public void GetMaxLength(int index , int cur, IList<string> arr, int[] cnt)
        {
            if (IsValid(cnt))
            {
                maxLen = Math.Max(cur, maxLen);
            }
            if (index == arr.Count)
            {
                return;
            }
            GetMaxLength(index + 1,cur, arr, cnt); //算a[i]
            foreach (char c in arr[index])
            {
                cnt[c - 'a']++;
            }
            GetMaxLength(index + 1,cur+arr[index].Length, arr, cnt); //算a[i]
            foreach (char c in arr[index])
            {
                cnt[c - 'a']--;
            }
        }

        public bool IsValid(int[] cnt)
        {
            foreach (var c in cnt)
            {
                if (c > 1) return false;
            }
            return true;
        }

        public IList<string> CircularPermutationList = new List<string>();


        public IList<int> CircularPermutation(int n, int start)
        {
            IList<int> result = new List<int>();
            HashSet<string> set = new HashSet<string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                if (start%2 == 0) sb.Insert(0,"0");
                else sb.Insert(0, "1");
                start = start/2;
            }
            string s = sb.ToString();
            CircularPermutationList.Add(s);
            set.Add(s);
            CircularPermutation(set);
            foreach (string s1 in CircularPermutationList)
            {
                int nn = 0;
                foreach (var c in s1)
                {
                    nn = nn << 1;
                    if (c == '1') nn += 1;
                }
                result.Add(nn);
            }
            return result;
        }

        public void CircularPermutation(HashSet<string> set)
        {
            string last = CircularPermutationList.Last();
            for (int i = 0; i < last.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < last.Length; j++)
                {
                    if (i == j)
                    {
                        if (last[i] == '0')
                            sb.Append("1");
                        else
                            sb.Append("0");
                    }
                    else
                    {
                        sb.Append(last[j]);
                    }
                }
                if (set.Contains(sb.ToString()))
                {
                    continue;
                }
                else
                {
                    set.Add(sb.ToString());
                    CircularPermutationList.Add(sb.ToString());
                    CircularPermutation(set);
                    break;
                }
            }
        }

        public class CustomFunction
        {
        // Returns f(x, y) for any given positive integers x and y.
        // Note that f(x, y) is increasing with respect to both x and y.
        // i.e. f(x, y) < f(x + 1, y), f(x, y) < f(x, y + 1)
            public int f(int x, int y)
            {
                return 0;
            }
        };
        public IList<IList<int>> FindSolution(CustomFunction customfunction, int z)
        {
            IList < IList < int >> ret = new List<IList<int>>();
            for (int x = 0; x <= 1000; x++)
            {
                for (int y = 0; y <= 1000; y++)
                {
                    if(customfunction.f(x,y) == z)
                        ret.Add(new List<int>() {x,y});
                }
            }
            return ret;
        }

        public bool CheckStraightLine(int[][] coordinates)
        {
            int x1 = coordinates[0][0], y1 = coordinates[0][1];
            int x2 = coordinates[1][0], y2 = coordinates[1][1];

            for (int i = 3; i < coordinates.Length; i++)
            {
                int x3 = coordinates[i][0], y3 = coordinates[i][1];
                if ((y3 - y2)*(x2 - x1) != (y2 - y1)*(x3 - x2))
                    return false;
            }
            return true;
        }

        public class TrieT
        {
            public Dictionary<string,TrieT> Child = new Dictionary<string, TrieT>();
            public bool IsRoot;
        }

        public IList<string> RemoveSubfolders(string[] folder)
        {
            IList<string> result = new List<string>();
            TrieT root = new TrieT();
            foreach (var fo in folder)
            {
                string[] path = fo.Split('/');
                TrieT cur = root;
                foreach (var p in path)
                {
                    if(p=="") continue;
                    if (!cur.Child.ContainsKey(p))
                    {
                        cur.Child.Add(p, new TrieT());
                    }
                    cur = cur.Child[p];
                }
                cur.IsRoot = true;
            }
            GetFolder(root, result, "");
            return result;
        }

        public void GetFolder(TrieT root, IList<string> result, string cur)
        {
            if (root.IsRoot)
            {
                result.Add(cur);
                return;
            }
            foreach (var pair in root.Child)
            {
                GetFolder(pair.Value, result, cur + "/" + pair.Key);
            }
        }

        public int BalancedString(string s)
        {
            int n = 0;
            int q=0, w=0, e=0, r=0;
            foreach (char c in s)
            {
                if (c == 'Q') q++;
                if (c == 'W') w++;
                if (c == 'E') e++;
                if (c == 'R') r++;
            }
            int average = s.Length/4;
            Dictionary<char ,int> dic = new Dictionary<char, int>();
            if (q > average)
            {
                dic['Q'] = q - average;
                n += q - average;
            }
            if (w > average)
            {
                dic['W'] = (w - average);
                n += w - average;
            }
            if (e > average)
            {
                dic['E'] = (e - average);
                n += e - average;
            }
            if (r > average)
            {
                dic['R'] = (r - average);
                n += r - average;
            }
            for (int len = n; len < s.Length; len++)
            {
                //滑动窗口
                for (int j = 0; j < s.Length; j++)
                {
                    Dictionary<char ,int> cur = new Dictionary<char, int>();
                    for (int k = j; k < len + j; k++)
                    {
                        if (!cur.ContainsKey(s[k])) cur[s[k]] = 0;
                        cur[s[k]]++;
                    }
                    bool success = true;
                    foreach (var pair in dic)
                    {
                        if (!cur.ContainsKey(pair.Key) || cur[pair.Key] < pair.Value)
                        {
                            success = false;
                            break;
                        }
                    }
                    if (success) return len;
                }
            }
            return s.Length;
        }

    }
}
