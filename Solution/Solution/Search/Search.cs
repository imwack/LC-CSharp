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



    }
}
