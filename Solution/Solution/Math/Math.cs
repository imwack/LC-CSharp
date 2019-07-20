﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {
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
        public int[] CorpFlightBookings(int[][] bookings, int n)
        {
            int[] cnt = new int[n];
            for (int i = 0; i < n; i++)
            {
                int index = i + 1;
                cnt[i] = 0;
                foreach (var booking in bookings)
                {
                    if (index >= booking[0] && index <= booking[1])
                        cnt[i] += booking[2];
                }
            }
            return cnt;

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
    }
}
