using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {
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
}
