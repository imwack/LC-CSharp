using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {
        IList<IList<int>> PermuteResult = new List<IList<int>>();

        public IList<IList<int>> Permute(int[] nums)
        {
            Permute(nums, 0, nums.Length-1);
            return PermuteResult;

        }

        private void Permute(int[] nums,int l, int r)
        {
            if (l > r)
            {
                PermuteResult.Add(new List<int>(nums));
                return;
            }

            for (int i = l; i <= r; i++)
            {
                Swap<int>(ref nums[i], ref nums[l]);
                Permute(nums, l + 1, r);
                Swap<int>(ref nums[i], ref nums[l]);
            }
        }
    }
}
