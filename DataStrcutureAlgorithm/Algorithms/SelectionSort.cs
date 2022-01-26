using System;
namespace DataStrcutureAlgorithm.Algorithms
{
    public class SelectionSort
    {
        int[] nums;
        public void swap(int a, int b)
        {
            int tmp = this.nums[a];
            this.nums[a] = this.nums[b];
            this.nums[b] = tmp;
        }

        public int FindKthLargest(int[] nums, int k)
        {
            this.nums = nums;
            int size = nums.Length;
            // kth largest is (N - k)th smallest
            return quickselect(0, size - 1, size - k);
        }

        public int quickselect(int left, int right, int k_smallest)
        {
            if (left == right) // If the list contains only one element,
                return this.nums[left];  // return that element

            // select a random pivot_index
            Random random_num = new Random();
            int pivot_index = left + random_num.Next(right - left);

            pivot_index = partition(left, right, pivot_index);

            // the pivot is on (N - k)th smallest position
            if (k_smallest == pivot_index)
                return this.nums[k_smallest];

            else if (k_smallest < pivot_index)
                return quickselect(left, pivot_index - 1, k_smallest);

            return quickselect(pivot_index + 1, right, k_smallest);
        }

        public int partition(int left, int right, int pivot_index)
        {
            int pivot = this.nums[pivot_index];
           
            // 1. move pivot to end
            swap(pivot_index, right);
            int store_index = left;

            // 2. move all smaller elements to the left
            for (int i = left; i <= right; i++)
            {
                 if (this.nums[i] < pivot)
                {
                    swap(store_index, i);
                    store_index++;
                }
            }
            // 3. move pivot to its final place
            swap(store_index, right);

            return store_index;
        }
    }
}
