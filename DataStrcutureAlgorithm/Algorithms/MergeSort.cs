namespace DataStrcutureAlgorithm.Algorithms
{
    public class MergeSortClass
    {
        public static int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
                return arr;

            int mid = arr.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[arr.Length - mid];

            for (int i = 0; i < mid; i++)
                left[i] = arr[i];
            for (int i = 0; i < right.Length; i++)
                right[i] = arr[mid + i];

            left = MergeSort(left);
            right = MergeSort(right);
            int[] result = Merge(left, right);

            return result;

        }
        private static int[] Merge(int[] left, int[] right)
        {
            int[] res = new int[left.Length + right.Length];
            int leftPointer = 0, resPointer = 0, rightPointer = 0;


            while (leftPointer < left.Length || rightPointer < right.Length)
            {
                if (leftPointer < left.Length && rightPointer < right.Length)
                {
                    if (left[leftPointer] < right[rightPointer])
                    {
                        res[resPointer++] = left[leftPointer++];
                    }
                    else
                    {
                        res[resPointer++] = right[rightPointer++];
                    }
                }
                else if (leftPointer < left.Length)
                {
                    res[resPointer++] = left[leftPointer++];
                }
                else if (rightPointer < right.Length)
                {
                    res[resPointer++] = right[rightPointer++];
                }

            }

            return res;
        }
    }
}
