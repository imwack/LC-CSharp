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
        Dictionary<string,int>  waysDic = new Dictionary<string, int>();
        public int NumWays(int steps, int arrLen)
        {
            if (steps == 0) return 0;
            if (arrLen == 0 || steps == 1) return 1;
            return DFSNumWays(steps, arrLen,0);
        }

        public int DFSNumWays(int steps, int arrLen, int cur)
        {
            if (steps <= 0)
            {
                return cur == 0 ? 1 : 0;
            }
            string key = steps + "," + cur;
            if (waysDic.ContainsKey(key)) return waysDic[key];

            int ans = DFSNumWays(steps-1, arrLen, cur+0);
            ans %= 1000000007;
            if (cur + 1 < arrLen)
            {
                ans+=DFSNumWays(steps-1, arrLen, cur+1);
                ans %= 1000000007;
            }
            if (cur > 0)
            {
                ans+=DFSNumWays(steps-1, arrLen, cur-1);
                ans %= 1000000007;
            }
            waysDic[key] = ans;

            return ans;
        }

        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            IList<IList<string>> result = new List<IList<string>>();
            if (products==null||products.Length == 0) return result;
            Trie tree = new Trie();
            foreach (var product in products)
            {
                tree.Insert(product);
            }
            StringBuilder sb = new StringBuilder();
            result.Add(new List<string>(tree.SearchWithPrefix("eucgsmpsyndddijvpxfagngnjbzxuajxmrmszwtjvwswgdroj")));

            foreach (var c in searchWord)
            {
                sb.Append(c);
                Console.WriteLine(sb.ToString());
                result.Add(new List<string>( tree.SearchWithPrefix(sb.ToString())));
            }
            return result;
        }

        public int CountServers(int[][] grid)
        {
            Dictionary<int,int> x = new Dictionary<int, int>();
            Dictionary<int, int> y = new Dictionary<int, int>();

            int sum = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        if (!x.ContainsKey(i)) x[i] = 0;
                        x[i]++;
                        if (!y.ContainsKey(j)) y[j] = 0;
                        y[j]++;
                    }

                }
            }
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if ((x.ContainsKey(i)&&x[i]>1) || (y.ContainsKey(j) && y[j]>1))
                    {
                        sum++;
                    }

                }
            }
            return sum;
        }

        public int MinTimeToVisitAllPoints(int[][] points)
        {
            int sum = 0;
            if (points.Length == 0) return 0;
            int start = 0;
            int x = points[0][0], y = points[0][1];
            for (int i = 1; i < points.Length; i++)
            {
                int xx = points[i][0], yy = points[i][1];
                int a = Math.Abs(xx - x);
                int b = Math.Abs(yy - y);
                if (a > b)
                {
                    sum += b;
                    a -= b;
                    sum += a;
                }
                else
                {
                    sum += a;
                    b -= a;
                    sum += b;
                }


                x = xx;
                y = yy;
            }
            return sum;
        }

        public class FindElements
        {
            HashSet<int> valSet = new HashSet<int>();
            public FindElements(TreeNode root)
            {
                if (root == null) return;
                root.val = 0;
                valSet.Add(0);
                Construst(root);
            }

            public void Construst(TreeNode root)
            {
                if (root != null)
                {
                    if (root.left != null)
                    {
                        root.left.val = 2 * root.val + 1;
                        valSet.Add(root.left.val);
                        Construst(root.left);
                    }
                    if (root.right != null)
                    {
                        root.right.val = 2 * root.val + 2;
                        valSet.Add(root.right.val);

                        Construst(root.right);
                    }

                }
            }
            public bool Find(int target)
            {
                return valSet.Contains(target);
            }
        }


        public int MaxSumDivThree(int[] nums)
        {
            Array.Sort(nums);
            List<int> mod1 = new List<int>();
            List<int> mod2 = new List<int>();
            int sum = 0;
            foreach (var num in nums)
            {
                sum += num;
                if(num%3 == 1) mod1.Add(num);
                if(num%3 == 2) mod2.Add(num);
            }
            if (sum%3 == 0) return sum;
            if (sum%3 == 1)
            {
                int min = -1;
                if (mod1.Count > 0) min = mod1[0];
                if (mod2.Count > 1) min = Math.Min(min, mod2[0] + mod2[1]);
                if (min == -1) return 0;
                return sum - min;
            }
            else
            {
                int min = -1;
                if (mod2.Count > 0) min = mod2[0];
                if (mod1.Count > 1) min = Math.Min(min, mod1[0] + mod1[1]);
                if (min == -1) return 0;
                return sum - min;
            }
        }

        public int DfsMaxSumDivThree(int[] nums, int sum, HashSet<int> removed)
        {
            if (sum%3 == 0) return sum;

            for (int i = 0; i < nums.Length; i++) //减去一个
            {
                if(removed.Contains(i)) continue;

                removed.Add(i);
                if ((sum - nums[i])%3 == 0)
                    return sum - nums[i];
 
                removed.Remove(i);
            }

            return -1;
        }
        
        public IList<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            int row = grid.Length, col = grid[0].Length;
            IList<IList<int>> newGrid = new List<IList<int>>();
            for (int i = 0; i < grid.Length; i++)
            {
                newGrid.Add(new List<int>());
                for (int j = 0; j < grid[0].Length; j++)
                {
                    newGrid[i].Add(grid[i][j]);
                }
            }
            k = k%(row*col);
            int r = k/col;
            int c = k%col;
            for (int i = 0; i < r; i++)
            {
                List<int> last = new List<int>(newGrid[newGrid.Count-1]);
                for (int j = newGrid.Count-1;j>0; j--)
                {
                    newGrid[j] = newGrid[j - 1];
                }
                newGrid[0] = last;
            }
            for (int i = 0; i < c; i++)
            {
                int last = newGrid[row - 1][col - 1];
                for (int j = 0; j < row; j++)
                {
                    for (int l=0;l<col;l++)
                    {
                        int temp = newGrid[j][l];
                        newGrid[j][l] = last;
                        last = temp;
                    }
                }
            }
            return newGrid;
        }
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
