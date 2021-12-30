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

    }
}
