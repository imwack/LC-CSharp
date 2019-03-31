using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Array
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
    }
}
