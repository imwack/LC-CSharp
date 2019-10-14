﻿using System;
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

        public int BitwiseComplement(int N)
        {
            if (N == 0) return 1;
            int cur = 0;
            int index = 1;
            while (N > 0)
            {
                int tail = (N % 2 == 0) ? 1 : 0;
                cur += tail * index;
                index *= 2;
                N /= 2;
            }
            return cur;
        }
        public int SingleNumber(int[] nums)
        {
            int[] bits = new int[32];
            foreach (int n in nums)
            {
                int c = n;
                for (int i = 0; i < 32; i++)
                {
                    int bit = c & 1;
                    bits[i] += bit;
                    c = c >> 1;
                }
            }
            int result = 0;
            for (int i = 31; i >= 0; i--)
            {
                result = result << 1 + (bits[i] % 3);
            }
            return result;
        }
    }
}
