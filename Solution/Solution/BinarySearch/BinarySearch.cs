using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {
        public char NextGreatestLetter(char[] letters, char target)
        {
            int l = 0, r = letters.Length-1;
            while (l<=r)
            {
                int mid = (l + r)/2;
                if (letters[mid] <= target)
                {
                    l = mid + 1;
                }
                else
                {
                    if (mid - 1 >= 0 && letters[mid - 1] > target)
                        r = mid - 1;
                    else
                        return letters[mid];
                }
            }
            return letters[0];
        }

        public int CountNodes(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int l = 0,r=0;
            TreeNode temp = root;
            while (temp != null)
            {
                temp = temp.left;
                l++;
            }
            temp = root;
            while (temp !=null)
            {
                temp = temp.right;
                r++;
            }
            if (l == r)
            {
                return (2 >> l) - 1;
            }
            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }
        public int FindMin(int[] nums)
        {
            int l = 0, r = nums.Length - 1;
            while (l <= r)
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
            return nums[l] > nums[r] ? nums[r] : nums[l];
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
