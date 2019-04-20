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
    }
}
