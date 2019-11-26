using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {
        public int FindMin(int[] nums)
        {
            int l = 0, r = nums.Length - 1;
            while (l<=r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] > nums[l])
                {
                    if (nums[l] > nums[r])
                        l = mid + 1;
                    else
                        r = mid - 1;
                }
                else
                {
                    if (nums[mid] < nums[r])
                        r = mid - 1;
                    else
                        l = mid + 1;
                }
            }
            return nums[l]>nums[r]?nums[r]:nums[l];
        }

        public int HIndex(int[] citations)
        {
            int n = citations.Length;
            int l = 0, r = citations.Length - 1;
            while (l<=r)
            {
                int mid = (l + r) / 2;
                int count = (n - 1 - mid+1);
                if (count == citations[mid])
                    return count;
                else if (count < citations[mid])
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            return n-l;
        }
    }
}
