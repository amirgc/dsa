using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.Algorithms
{
    public class AlgorithmReviewPartOne
    {
        public int[] SortedSquares(int[] nums)
        {
            int counter = nums.Length;
            var res = new int[counter];
            int leftPointer = 0;
            int rightPointer = counter - 1;

            while (leftPointer <= rightPointer)
            {
                if (Math.Abs(nums[leftPointer]) > Math.Abs(nums[rightPointer]))
                {
                    res[counter - 1] = (int)Math.Pow(Math.Abs(nums[leftPointer]), 2);
                    leftPointer++;
                }
                else
                {
                    res[counter - 1] = (int)Math.Pow(Math.Abs(nums[rightPointer]), 2);
                    rightPointer--;
                }
                counter--;

            }
            return res;
        }
    }
}
