using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {
        public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king)
        {
            IList<IList<int>> result = new List<IList<int>>();
            int[,] array = new int[8,8];
            for (int i = 0; i < queens.Length; i++)
            {
                array[queens[i][0], queens[i][1]] = 1; //mark queue
            }
            int x = king[0], y = king[1];
            for (int i = x; i >= 0; i--)
            {
                if (array[i, y] == 1)
                {
                    result.Add(new List<int>() { i,y});
                    break;
                }
            }
            for (int i = x; i < 8; i++)
            {
                if (array[i, y] == 1)
                {
                    result.Add(new List<int>() { i, y });
                    break;
                }
            }
            for (int i = y; i >= 0; i--)
            {
                if (array[x, i] == 1)
                {
                    result.Add(new List<int>() { x, i});
                    break;
                }
            }
            for (int i = y; i < 8; i++)
            {
                if (array[x, i] == 1)
                {
                    result.Add(new List<int>() { x, i });
                    break;
                }
            }
            for (int i = x,j=y; i>=0 &&j>=0; i--,j--)
            {
                if (array[i, j] == 1)
                {
                    result.Add(new List<int>() { i, j });
                    break;
                }
            }
            for (int i = x, j = y; i >= 0 && j <8; i--, j++)
            {
                if (array[i, j] == 1)
                {
                    result.Add(new List<int>() { i, j });
                    break;
                }
            }
            for (int i = x, j = y; i <8 && j >= 0; i++, j--)
            {
                if (array[i, j] == 1)
                {
                    result.Add(new List<int>() { i, j });
                    break;
                }
            }
            for (int i = x, j = y; i <8 && j < 8; i++, j++)
            {
                if (array[i, j] == 1)
                {
                    result.Add(new List<int>(){ i, j });
                    break;
                }
            }
            return result;
        }
        public int OrangesRotting(int[][] grid)
        {
            int row = grid.Length;
            int col = grid[0].Length;
            bool needLoop = true;
            int loop = 0;
            int start = 0;
            while (needLoop)
            {
                int cnt = 0;
                List<int> x = new List<int>();
                List<int> y = new List<int>();
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (grid[i][j] == 2)
                        {
                            x.Add(i);
                            y.Add(j);
                            grid[i][j] = 0;
                        }
                    }
                }
                for (int i = 0; i < x.Count; i++)
                {
                    cnt += OrangesRotting(grid, x[i], y[i]);
                }
                needLoop = cnt > 0;
                if (needLoop)
                    ++loop;
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        return -1;
                    }
                }
            }
            return loop;
        }

        int OrangesRotting(int[][] grid, int i, int j)
        {
            int cnt = 0;
            if (i - 1 >= 0 && grid[i - 1][j] == 1)
            {
                grid[i - 1][j] = 2;
                cnt++;
            }
            if (i + 1 < grid.Length && grid[i + 1][j] == 1)
            {
                grid[i + 1][j] = 2;
                cnt++;
            }
            if (j - 1 >= 0 && grid[i][j - 1] == 1)
            {
                grid[i][j - 1] = 2;
                cnt++;
            }
            if (j + 1 < grid[0].Length && grid[i][j + 1] == 1)
            {
                grid[i][j + 1] = 2;
                cnt++;
            }
            return cnt;
        }

        public int[][] FloodFill(int[][] image, int x, int y, int newColor)
        {
            bool[][] visit = new bool[image.Length][];
            for (int i = 0; i < visit.Length; i++)
            {
                visit[i] = new bool[image[0].Length];
            }
            int originColor = image[x][y];
            Dfs(ref image, ref visit, x, y, originColor, newColor);
            return image;
        }

        public void Dfs(ref int[][] image, ref bool[][] visit, int x, int y, int originColor, int newColor)
        {
            int[][] dir = new int[4][] {new int[] {-1, 0}, new int[] {1, 0}, new int[] {0, -1}, new int[] {0, -1}};
            image[x][y] = newColor;
            int newX, newY;
            foreach (int[] d in dir)
            {
                newX = x + d[0];
                newY = y + d[1];
                if (newX >= 0 && newY >= 0 && newX < image.Length && newY < image[0].Length && originColor==image[newX][newY] && !visit[newX][newY])
                {
                    visit[newX][newY] = true;
                    Dfs(ref image, ref visit, x + d[0], y + d[1], originColor, newColor);
                }
            }
        }

        public class Cell
        {
            public int x;
            public int y;

            public Cell()
            {
                
            }

            public Cell(int xx, int yy)
            {
                x = xx;
                y = yy;
            }
        }
        public int[][] AllCellsDistOrder(int R, int C, int r0, int c0)
        {
            int[][] retsult = new int[R * C][];
            bool[][] visited = new bool[R][];
            for (int i = 0; i < R; i++)
            {
                visited[i] = new bool[C];
            }
            for (int i = 0; i < R * C; i++)
                retsult[i] = new int[2];
            int index = 0;
            Queue<Cell> queue = new Queue<Cell>();
            queue.Enqueue(new Cell(r0, c0));
            visited[r0][c0] = true;
            while (queue.Count > 0)
            {
                int n = queue.Count;
                for (int i = 0; i < n; i++)
                {
                    Cell front = queue.Dequeue();
                    retsult[index][0] = front.x;
                    retsult[index][1] = front.y;
                    index++;
                    if (front.x - 1 >= 0 && !visited[front.x - 1][front.y])
                    {
                        queue.Enqueue(new Cell(front.x - 1, front.y));
                        visited[front.x - 1][front.y] = true;
                    }
                    if (front.y - 1 >= 0 && !visited[front.x][front.y - 1])
                    {
                        queue.Enqueue(new Cell(front.x, front.y - 1));
                        visited[front.x][front.y - 1] = true;
                    }
                    if (front.x + 1 < R && !visited[front.x + 1][front.y])
                    {
                        queue.Enqueue(new Cell(front.x + 1, front.y));
                        visited[front.x + 1][front.y] = true;
                    }
                    if (front.y + 1 < C && !visited[front.x][front.y + 1])
                    {
                        queue.Enqueue(new Cell(front.x, front.y + 1));
                        visited[front.x][front.y + 1] = true;
                    }
                }
            }
            return retsult;
        }

        public HashSet<string> set = new HashSet<string>();
        public int NumTilePossibilities(string tiles)
        {
            Dictionary<char, int> alphaDic = new Dictionary<char, int>();
            for (int i = 0; i < tiles.Length; i++)
            {
                if (!alphaDic.ContainsKey(tiles[i]))
                    alphaDic[tiles[i]] = 0;
                alphaDic[tiles[i]]++;
            }
            NumTilePossibilitiesDic(alphaDic, "");
            return set.Count;
        }

        public void NumTilePossibilitiesDic(Dictionary<char, int> alphaDic, string str)
        {
            foreach (var pair in alphaDic)
            {
                if(pair.Value <= 0 )
                    continue;

                str += pair.Key;
                set.Add(str);
                Dictionary<char, int> dic = new Dictionary<char, int>(alphaDic);
                dic[pair.Key]--;
                NumTilePossibilitiesDic(dic, str);
                str = str.Substring(0, str.Length - 1);
            }
        }

        List<string> result = new List<string>();
        public string[] Permute(string S)
        {
            List<List<char>> strs = GetStrs(S);
            PermuteDfs(strs,0,"");
            return result.ToArray();
        }

        public void PermuteDfs(List<List<char>> strs,int depth, string cur)
        {
            if (depth >= strs.Count)
            {
                result.Add(cur);
                return;
            }
            foreach (char c in strs[depth])
            {
                PermuteDfs(strs, depth + 1, cur + c);
            }
        }
        public List<List<char>> GetStrs(string str)
        {
            int i = 0;
            List<List<char>> strs = new List<List<char>>();
            while (i<str.Length)
            {
                if (str[i] == '{')
                {
                    List<char> s = new List<char>();
                    int j = i + 1;
                    while ( j<str.Length && str[j] != '}')
                    {
                        if (str[j] != ',') 
                            s.Add(str[j]);
                        j++;
                    }
                    i = j + 1;
                    strs.Add(s);
                }
                else
                {
                    strs.Add(new List<char> { str[i++]});
                }
            }
            return strs;
        }
        public void DuplicateZeros(int[] arr)
        {
            List<int> lst = new List<int>(arr);
            foreach (int a in arr)
            {
                lst.Add(a);
            }
            int cnt = 0, i = 0;
            while (cnt<arr.Length)
            {
                if (lst[i] == 0)
                {
                    if(cnt<arr.Length)
                        arr[cnt++] = 0;
                    if (cnt < arr.Length)
                        arr[cnt++] = 0;
                }
                else
                {
                    arr[cnt++] = lst[i];
                }
                i++;
            }
        }

        Dictionary<TreeNode, int>  rootRobCount = new Dictionary<TreeNode, int>();
        public int Rob(TreeNode root)
        {
            return RobDfs(root);
        }

        public int RobDfs(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            if (rootRobCount.ContainsKey(root))
            {
                return rootRobCount[root];
            }
            int val1 =  root.val;
            if (root.left != null)
            {
                val1 += Rob(root.left.left) + Rob(root.left.right);
            }
            if (root.right != null)
            {
                val1 += Rob(root.right.left) + Rob(root.right.right);
            }
            int val2 = Rob(root.left) + Rob(root.right);
            rootRobCount[root] = Math.Max(val1, val2);
            return Math.Max(val1, val2);
        }

        Dictionary<TreeNode, int> nodeDeepth = new Dictionary<TreeNode, int>();
        public TreeNode SubtreeWithAllDeepest(TreeNode root)
        {
            if (root == null) return null;
            int l = GetTreeHeight(root.left);
            int r = GetTreeHeight(root.right);
            if (l == r) return root;
            if (l > r) return SubtreeWithAllDeepest(root.left);
            return SubtreeWithAllDeepest(root.right);

        }

        public int GetTreeHeight(TreeNode root)
        {
            if (nodeDeepth.ContainsKey(root))
            {
                return nodeDeepth[root];
            }
            if (root == null) return 0;
            int l = GetTreeHeight(root.left);
            int r = GetTreeHeight(root.right);
            int deep = Math.Max(l, r) + 1;
            nodeDeepth[root] = deep;
            return deep;
        }


        public class Point1
        {
            public int X;
            public int Y;

            public Point1(int x, int y)
            {
                X = x;
                Y = y;  
            }
        }

        public int MaxDistance(int[][] grid)
        {
            Queue<Point1> queue = new Queue<Point1>();
            int[,] distance = new int[grid.Length, grid[0].Length];
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        queue.Enqueue(new Point1(i, j));
                    }
                }
            }
            int dis = 0;
            while (queue.Count > 0)
            {
                int n = queue.Count;
                for (int i = 0; i < n; i++)
                {
                    Point1 front = queue.Dequeue();
                    distance[front.X, front.Y] = dis;
                    if (front.X - 1 >= 0 && grid[front.X - 1][front.Y] == 0)
                    {
                        queue.Enqueue(new Point1(front.X - 1, front.Y));
                        grid[front.X - 1][front.Y] = 2;
                    }
                    if (front.X + 1 < grid.Length && grid[front.X + 1][front.Y] == 0)
                    {
                        queue.Enqueue(new Point1(front.X + 1, front.Y));
                        grid[front.X + 1][front.Y] = 2;
                    }
                    if (front.Y - 1 >= 0 && grid[front.X][front.Y - 1] == 0)
                    {
                        queue.Enqueue(new Point1(front.X, front.Y - 1));
                        grid[front.X][front.Y - 1] = 2;
                    }
                    if (front.Y + 1 < grid[0].Length && grid[front.X][front.Y + 1] == 0)
                    {
                        queue.Enqueue(new Point1(front.X, front.Y + 1));
                        grid[front.X][front.Y + 1] = 2;
                    }
                }
                dis++;
            }
            int maxDis = -1;
            for (int i = 0; i < distance.GetLength(0); i++)
            {
                for (int j = 0; j < distance.GetLength(1); j++)
                {
                    if (distance[i, j] != 0 && distance[i, j] > maxDis)
                        maxDis = distance[i, j];
                }
            }
            return maxDis;
        }


    }
}
