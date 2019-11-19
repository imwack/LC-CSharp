using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {
        public int MinEditDistance(string word1, string word2)
        {
            int[,] dp = new int[word1.Length+1,word2.Length+1];
            for (int i = 1; i <= word2.Length; i++)
            {
                dp[0, i] = i;
            }
            for (int i = 1; i <= word1.Length; i++)
            {
                dp[i, 0] = i;
            }
            for (int i = 1; i <= word1.Length; i++)
            {
                for (int j = 1; j <= word2.Length; j++)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + 1;

                    if (word1[i - 1] == word2[j - 1])
                        dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j - 1] );
                    else
                        dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j - 1] + 1);
                }
            }

            return dp[word1.Length, word2.Length];
        }

        public int MaxSumAfterPartitioning(int[] A, int K)
        {
            int[] dp = new int[A.Length+1];
            dp[0] = 0;
            for (int i = 0; i < A.Length; i++)
            {
                dp[i+1] = A[i]+dp[i];
                int m = A[i];
                for (int j = 1; j <= K ; j++)
                {
                    if (i - j + 1 >= 0)
                    {
                        m = Math.Max(m, A[i - j+1]);
                        dp[i + 1] = Math.Max(dp[i - j + 1] + m * j, dp[i + 1]);
                    }
                }
            }
            return dp[A.Length];
        }
        public bool CheckSubarraySum(int[] nums, int k)
        {
            int sum = 0;
            Dictionary<int, int> remainDic = new Dictionary<int, int>();
            remainDic[0] = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (k != 0)
                    sum = sum % k;
                if (remainDic.ContainsKey(sum))
                {
                    if (i - remainDic[sum] > 1)
                        return true;
                }
                else
                {
                    remainDic[sum] = i;
                }
            }
            return false;
        }

        public int NumTrees(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    dp[i] += dp[j - 1] * dp[i - j];
                }
            }
            return dp[n];
        }
        public int MaximalSquare(char[][] matrix)
        {
            if (matrix.Length == 0) return 0;
            int maxSquare = 0;
            int row = matrix.Length, col = matrix[0].Length;
            int[,] dp = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                if (matrix[i][0] == '1')
                {
                    dp[i, 0] = 1;
                    maxSquare = 1;
                }
            }
            for (int i = 0; i < col; i++)
            {
                if (matrix[0][i] == '1')
                {
                    dp[0, i] = 1;
                    maxSquare = 1;
                }
            }
            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < col; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                        if (dp[i, j] > maxSquare)
                            maxSquare = dp[i, j];
                    }
                }
            }
            return maxSquare * maxSquare;
        }

        public int LongestCommonSubsequence(string text1, string text2)
        {
            if (text1.Length == 0 || text2.Length == 0) return 0;
            int[,] dp = new int[text1.Length, text2.Length];
            bool find = false;
            for (int i = 0; i < text1.Length; i++)
            {
                if (find || text2[0] == text1[i])
                {
                    find = true;
                    dp[i, 0] = 1;
                }
            }
            find = false;
            for (int i = 1; i < text2.Length; i++)
            {
                if (find || text1[0] == text2[i])
                {
                    find = true;
                    dp[0, i] = 1;
                }
            }

            for (int i = 1; i < text1.Length; i++)
            {
                for (int j = 0; j < text2.Length; j++)
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    if (text1[i] == text2[j])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                }
            }
            return dp[text1.Length - 1, text2.Length - 1];
        }
        public int[] RollMax;
        public int CNT = 0;
        public int DieSimulator(int n, int[] rollMax)
        {
            RollMax = rollMax;
            for (int i = 1; i <= 6; i++)
                DfsDieSimulator(n-1, i, 1);
            return CNT;
        }
        public void DfsDieSimulator(int n, int last, int countinue)
        {
            if (last != -1 && countinue > RollMax[last-1]) return;

            if (n == 0)
            {
                CNT++;
                CNT %= 1000000007;
                return;
            }
            for (int i = 1; i <= 6; i++)
            {
                if (last == i)
                    DfsDieSimulator(n - 1, i, countinue + 1);
                else
                    DfsDieSimulator(n - 1, i, 0);
            }
        }
        public int MinDistance(string word1, string word2)
        {
            int[,] dp = new int[word1.Length, word2.Length];
            for (int i = 0; i < word2.Length; i++)
            {
                if (word1[0] == word2[i])
                {
                    dp[0, i] = 1;
                    for (int j = i + 1; j < word2.Length; j++)
                        dp[0, j] = 1;
                    break;
                }
            }
            for (int i = 0; i < word1.Length; i++)
            {
                if (word2[0] == word1[i])
                {
                    dp[i, 0] = 1;
                    for (int j = i + 1; j < word1.Length; j++)
                        dp[j,0] = 1;
                    break;
                }
            }
            for (int row = 1; row < word1.Length; row++)
            {
                for (int col = 1; col < word2.Length; col++)
                {
                    dp[row, col] = Math.Max(dp[row - 1, col], dp[row, col - 1]);
                    if (word1[row] == word2[col])
                        dp[row, col] = Math.Max(dp[row - 1, col - 1] + 1, dp[row, col]);
                }
            }
            int lcs = dp[word1.Length - 1, word2.Length - 1];
            return Math.Max(word1.Length, word2.Length) - lcs;
        }

        public bool DivisorGame(int N)
        {
            if (N == 1) return false;
            bool[] dp = new bool[N + 1];
            dp[0] = false;
            dp[1] = false;
            dp[2] = true;
            for (int i = 3; i <= N; i++)
            {
                for (int j = i / 2; j >= 1; --j)
                {
                    if (i % j == 0 && dp[i - j] == false)
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[N];
        }
        public int Tribonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 1;
            int a = 0, b = 1, c = 1, d=0;
            for (int i = 3; i <= n; i++)
            {
                d = a + b + c;
                a = b;
                b = c;
                c = d;
            }
            return d;
        }

        public int NumRollsToTarget(int d, int f, int target)
        {
            int mod = 1000000007;
            int[,] dp = new int[1001, 31];
            for (int i = 1; i <= f; i++)
            {
                dp[i, 1] = 1;
            }
            for (int tar = 2; tar <= target; tar++)
            {
                for (int time = 2; time <= d; time++)
                {
                    for (int i = 1; i <= f; i++)
                    {
                        if (tar - i >= 1)
                        {
                            dp[tar, time] += dp[tar - i, time - 1];
                            dp[tar, time] %= mod;
                        }
                    }
                }
            }

            return dp[target, d];
        }


    }
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
