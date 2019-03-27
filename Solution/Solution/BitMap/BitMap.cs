using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BitMap
{
    public partial class MySolution
    {
        public bool HasAlternatingBits(int n)
        {
            if (n == 0) return true;
            int last = (n&1);
            n >>= 1;
            while (n>0)
            {
                int cur = n & 1;
                if (cur == last)
                {
                    return false;
                }
                last = cur;
                n >>= 1;
            }
            return true;
        }
    }
}
