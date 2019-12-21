using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class NumMatrix
    {
        public int[,] dp;
        public NumMatrix(int[][] matrix)
        {
            if (matrix.Length == 0)
            {
                dp = new int[0, 0];
                return;
            }
            dp = new int[matrix.Length + 1, matrix[0].Length + 1];

            for (int i = 1; i <= matrix.Length; i++)
            {
                for (int j = 1; j <= matrix[0].Length; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1] - dp[i - 1, j - 1] + matrix[i - 1][j - 1];
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            if (dp.Length == 0)
                return 0;
            return dp[row2 + 1, col2 + 1] - dp[row2 + 1, col1] - dp[row1, col2 + 1] + dp[row1, col1];
        }
    }
}
