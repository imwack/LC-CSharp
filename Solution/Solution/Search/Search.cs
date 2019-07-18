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
    }
}
