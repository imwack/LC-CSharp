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

        IList<IList<int>> PermuteUniqueResult = new List<IList<int>>();

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            Array.Sort(nums);
            PermuteUnique(nums, 0, nums.Length-1);
            return PermuteUniqueResult;
        }

        public void PermuteUnique(int[] nums, int l, int r)
        {
            if (l > r)
            {
                PermuteUniqueResult.Add(new List<int>(nums));
                return;
            }

            for (int i = l; i <= r; i++)
            {
                if (nums[i] == nums[l] && i!=r && i!=l) 
                    continue;
                Swap<int>(ref nums[i], ref nums[l]);
                PermuteUnique(nums, l + 1, r);
                Swap<int>(ref nums[i], ref nums[l]);
            }
        }
    }
}
