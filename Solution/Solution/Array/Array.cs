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

    }
}
