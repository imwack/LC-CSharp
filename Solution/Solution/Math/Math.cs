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
    }
}
