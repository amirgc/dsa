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

        public void Rotate(int[] nums, int k)
        {
            var res = new int[nums.Length];

            if (k >= nums.Length)
            {
                k = k % nums.Length;
            }

            if (k == 0)
                return;

            for (int i = 0; i < nums.Length; i++)
            {
                int index;
                if (i + k >= nums.Length)
                    index = k + i - nums.Length;
                else
                    index = i + k;

                res[index] = nums[i];
            }

            nums = res;
        }
        public void MoveZeroes(int[] nums)
        {
            int index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[index] = nums[i];
                    index++;
                }
            }

            for (int j = index; j < nums.Length; j++)
            {
                nums[j] = 0;
            }
        }
        public int[] TwoSum(int[] numbers, int target)
        {
            var res = new int[2];
            int counter = numbers.Length;
            int leftPointer = 0;
            int rightPointer = counter - 1;

            while (leftPointer < rightPointer)
            {
                if (numbers[leftPointer] + numbers[rightPointer] == target)
                    return new[] { leftPointer + 1, rightPointer + 1 };

                if (numbers[leftPointer] + numbers[rightPointer] > target)
                {
                    rightPointer--;
                }
                else
                {
                    leftPointer++;
                }
            }


            return res;
        }
    }
}
