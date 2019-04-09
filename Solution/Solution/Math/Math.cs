using System;
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
    }
}
