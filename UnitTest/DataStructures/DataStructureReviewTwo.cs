using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.DataStructures
{
    public class DataStructureReviewTwo
    {
        bool IsBadVersion(int version)
        {
            //  2126753390
            //  1702766719
            if (version < 1702766719 + 1)
                return false;

            return true;
        }
        public int FirstBadVersion(int n)
        {
            int left = 1;
            int right = n;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (IsBadVersion(mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        public int SearchInsert(int[] nums, int target)
        {
            int pivot, left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                pivot = left + (right - left) / 2;
                if (nums[pivot] == target) return pivot;
                if (target < nums[pivot]) right = pivot - 1;
                else left = pivot + 1;
            }
            return left;
        }
    }
}
