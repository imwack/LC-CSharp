using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {
        public int Divide(int dividend, int divisor)
        {

            bool sign = false;
            if (dividend < 0 && divisor > 0) sign = true;
            if (dividend > 0 && divisor < 0) sign = true;
            if (dividend < 0) dividend = -dividend;
            if (divisor < 0) divisor = -divisor;

            int result = BinarySearchDivide(dividend, divisor);
            if (sign)
            {
                result = -result;
            }
            if (result <= int.MinValue) return int.MaxValue;

            return result;
        }

        public int BinarySearchDivide(int divident, int divisor)
        {
            if (divisor == 1) return divident;

            int temp = divisor;
            if (divident < divisor) return 0;
            int i = 1;
            for (; i < divident; i++)
            {
                if (divident < (divisor << 1)) break;
                if (divisor <= int.MinValue >> 1) break;
                divisor = divisor << 1;
            }
            int result = i;
            return result + BinarySearchDivide(divident - divisor, temp);
        }



        public int[] CorpFlightBookings(int[][] bookings, int n)
        {
            Dictionary<int, int> from = new Dictionary<int, int>();
            Dictionary<int, int> to = new Dictionary<int, int>();
            int[] result = new int[n];
            foreach (var booking in bookings)
            {
                int f = booking[0];
                int t = booking[1];
                if (!from.ContainsKey(f)) from[f] = 0;
                from[f] += booking[2];
                if (!to.ContainsKey(t)) from[t] = 0;
                to[t] += booking[2];
            }
            for (int i = 0; i < n; i++)
            {
                if (i != 0)
                {
                    result[i] += result[i - 1];
                    if (to.ContainsKey(i-1)) result[i] -= to[i-1];
                }
                if (from.ContainsKey(i)) result[i] += from[i];
            }

            return result;
        }

        // 908. Smallest Range I
        // just need to find the range of min and max
        // eg. [min-k, min+k] [max-k, max+k]
        // if the two Section intersect then each num can change to the intersection, or just the max gap
        public int SmallestRangeI(int[] A, int K)
        {
            int total = 0;
            int l = 0, r = A.Length - 1;
            Array.Sort(A); // only need the max and min can be O(n)

            if (A[l] + K >= A[r] - K)
            {
                return total;
            }
            else
            {
                return A[r] - K - A[l] - K;
            }
        }
        // 970. Powerful Integers
        public IList<int> PowerfulIntegers(int x, int y, int bound)
        {
            HashSet<int> s = new HashSet<int>();
            int a = 1, b = 1;
            for (int i = 0; a <= bound; i++)
            {
                if(i!=0)
                    a *= x;
                b = 1;
                for (int j = 0; a+b<=bound; j++)
                {
                    if(!s.Contains(a+b))
                        s.Add(a + b);
                    b *= y;
                    if(b == 1)
                        break;
                }
                if( a == 1)
                    break;
                
            }
            return s.ToList();
        }

        public int CountPrimeSetBits2(int L, int R)
        {
            HashSet<int> prime = new HashSet<int> {2,3,5,7,11,13,17,19,23};
            int count = 0;
            for (int i = L; i <= R; i++)
            {
                int n = i;
                int cnt = 0;
                while (n > 0)
                {
                    cnt++;
                    n &= (n - 1);
                }
                if (prime.Contains(cnt))
                    count++;
            }
            return count;
        }

        public int ProjectionArea(int[][] grid)
        {
            int total = 0;
            foreach (var g in grid)
            {
                int curMax = 0;
                foreach (var h in g)
                {
                    if (h > 0) total++;
                    if (h > curMax) curMax = h;
                }
                total += curMax;
            }
            int n = grid[0].Length;
            for(int i = 0;i<n;i++)
            {
                int curMax = 0;
                foreach (var g in grid)
                {
                    if (g[i] > curMax)
                    {
                        curMax = g[i];
                    }
                }
                total += curMax;
            }
            return total;
        }

        public int LargestPerimeter(int[] A)
        {
            Array.Sort(A);
            for (int i = A.Length - 1; i >= 2; i--)
            {
                if (A[i - 1] + A[i - 2] <= A[i])
                    continue;
                for (int j = i - 1; j >= 1; j--)
                {
                    if (A[j - 1] + A[j] <= A[i])
                        break;
                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (A[k] + A[j] <= A[i])
                        {
                            break;
                        }
                        return A[k] + A[j] + A[i];
                    }
                }
            }
            return 0;
        }

        public bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            int x1 = rec1[0], y1 = rec1[1], x2 = rec1[2], y2 = rec1[3];
            int xx1 = rec2[0], yy1 = rec2[1], xx2 = rec2[2], yy2 = rec2[3];
            if (xx1 > x2 || xx2<x1)
            {
                return false;
            }
            if (yy1 > y2  || yy2<y1)
            {
                return false;
            }
 
            return true;
        }

        public int RotatedDigits(int N)
        {
            int cnt = 0;
            for (int i = 1; i <= N; i++)
            {
                int k = i;
                bool valid = false;
                while (k > 0)
                {
                    int remain = k % 10;
                    if (remain == 4 || remain == 3 || remain == 7)
                    {
                        valid = false;
                        break;
                    }
                    if (remain == 2 || remain == 5 || remain == 6 || remain == 9)
                    {
                        valid = true;
                    }
                    k /= 10;
                }
                if (valid)
                {
                    //Console.WriteLine(i);
                    cnt++;
                }
            }
            return cnt;
        }

        public int ReachNumber(int target)
        {
            double t = Math.Abs(target);
            long n = (long)Math.Ceiling((-1 + Math.Sqrt(1 + 8 * t)) / 2);
            long sum = n * (n + 1) / 2;
            if  (sum < target)
            {
                ++n;
                sum = n * (n + 1) / 2;
            }
            //Console.WriteLine(n);
            long diff = sum - target;
            if (diff % 2 == 0) return (int)n;
            return (int)((n % 2 == 0) ? n + 1 : n + 2);
        }

        public int SurfaceArea(int[][] grid)
        {
            int sum = 0;
            foreach (int[] line in grid)
            {
                foreach (int l in line)
                {
                    if (l != 0)
                        sum += l * 4 + 2;
                }
            }
            foreach (int[] line in grid)
            {
                for (int i = 1; i < line.Length; i++)
                {
                    sum -= 2 * Math.Min(line[i], line[i - 1]);
                }
            }
            for (int i = 1; i < grid.Length; i++)
            {
                int[] row = grid[i];
                for (int j = 0; j < grid[i].Length; j++)
                {
                    sum -= 2 * Math.Min(grid[i][j], grid[i - 1][j]);
                }
            }
            return sum;
        }
 
        public bool IsRobotBounded(string instructions)
        {
            int[][] direction = new[] { new int[2] { 0, 1 }, new int[2] { -1, 0 }, new int[2] { 0, -1 }, new int[2] { 1, 0 } };
            int dir = 0, x = 0, y = 0;
            foreach (char instruction in instructions)
            {
                if (instruction == 'G')
                {
                    x += direction[dir][0];
                    y += direction[dir][1];
                }
                if (instruction == 'L')
                {
                    dir = (dir + 1) % 4;
                }
                if (instruction == 'R')
                {
                    dir = (dir - 1 + 4) % 4;
                }
            }
            return (x == 0 && y == 0) || (dir != 0); //方向不是向北则能回到原点
        }
        public int[] GardenNoAdj(int N, int[][] paths)
        {
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            int[] result = new int[N];
            for (int i = 0; i < N; i++)
            {
                dic[i + 1] = new List<int>();
            }
            foreach (int[] path in paths)
            {
                dic[path[0]].Add(path[1]);
                dic[path[1]].Add(path[0]);
            }
            foreach (var pair in dic)
            {
                int node = pair.Key;
                if (result[node - 1] != 0)
                {
                    continue;
                }
                for (int color = 1; color < 5; color++)
                {
                    bool ok = true;
                    foreach (var neighbour in pair.Value)
                    {
                        if (result[neighbour - 1] == color)
                        {
                            ok = false;
                            break;
                        }
                    }
                    if (ok)
                    {
                        result[node - 1] = color;
                        break;
                    }
                }
            }
            return result;
        }

        public int NumEquivDominoPairs(int[][] dominoes)
        {
            int cnt = 0, i=0;
            Array.Sort(dominoes, (a, b) =>
            {
                if (Math.Min(a[0], a[1]) < Math.Min(b[0], b[1]))
                    return -1;
                if (Math.Min(a[0], a[1]) > Math.Min(b[0], b[1]))
                    return 1;
                return (Math.Max(a[0], a[1]) < Math.Max(b[0], b[1])) ? -1 : 1;
            });
            while (i < dominoes.Length-1)
            {
                int count = 0,j;
                for (j = i; j < dominoes.Length - 1;j++)
                {
                    if (dominoes[j][0] == dominoes[j + 1][0] && dominoes[j][1] == dominoes[j + 1][1])
                    {
                        count++;
                    }
                    else if (dominoes[j][1] == dominoes[j + 1][0] && dominoes[j][0] == dominoes[j + 1][1])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (count > 0)
                {
                    cnt += count * (count + 1)/ 2;
                }

                i = j + 1;
            }
            return cnt;
        }

        public int NumPrimeArrangements(int n)
        {
            int cnt = 0;
            for (int i = 1; i <= n; i++)
            {
                if (IsPrime(i)) cnt++;
            }
            int notPirme = n - cnt;
            Console.WriteLine(cnt);
            long result = 1;
            for (int i = 1; i < cnt; i++)
            {
                result = (result*i)%100000007;
            }
            for (int i = 1; i < notPirme; i++)
            {
                result = (result * i) % 100000007;
            }
            return (int)result;
        }
        public bool IsPrime(int n)
        {
            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
    }
}
