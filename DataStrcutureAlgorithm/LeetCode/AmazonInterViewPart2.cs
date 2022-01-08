using DataStrcutureAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.LeetCode
{
    public class AmazonInterViewPart2
    {
        private List<int> allSums = new List<int>();

        public int maxProduct(TreeNode root)
        {
            // long is a 64-bit integer.
            long totalSum = treeSum(root);
            long best = 0;
            foreach (long sum in allSums)
            {
                best = Math.Max(best, sum * (totalSum - sum));
            }
            // We have to cast back to an int to match return value.
            return (int)(best % 1000000007);

        }

        private int treeSum(TreeNode subroot)
        {
            if (subroot == null) return 0;
            int leftSum = treeSum(subroot.left);
            int rightSum = treeSum(subroot.right);
            int totalSum = leftSum + rightSum + subroot.val;
            allSums.Add(totalSum);
            return totalSum;
        }

        public int LengthOfLongestSubstring(string s)
        {
            var dict = new HashSet<char>();
            int res = 0;
            int tempHigh = 0;

            foreach (char ch in s)
            {
                if (!dict.Contains(ch))
                {
                    dict.Add(ch);
                    tempHigh++;
                }
                else
                {
                    res = Math.Max(res, tempHigh);
                    tempHigh = 0;
                }
            }

            return res;
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var res = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length && nums[i] <= 0; i++)
            {
                if (i == 0 || nums[i - 1] != nums[i])
                {
                    twoSumII(nums, i, res);
                }
            }

            return res;
        }

        private void twoSumII(int[] nums, int i, List<IList<int>> res)
        {
            int lo = i + 1, hi = nums.Length - 1;
            while (lo < hi)
            {
                int sum = nums[i] + nums[lo] + nums[hi];
                if (sum < 0) lo++;
                else if (sum > 0) hi--;
                else
                {
                    res.Add(new List<int>() { nums[i], nums[lo++], nums[hi--] });
                    while (lo < hi && nums[lo] == nums[lo - 1])
                        lo++;
                }
            }
        }
    }
}
