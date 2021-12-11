using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.DataStructures
{
    public class MergeSort
    {
        public int[] mergeSort(int[] array)
        {
            mergeSort(array, 0, array.Length - 1);
            return array;
        }

        private void mergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                mergeSort(array, left, mid);
                mergeSort(array, mid + 1, right);
                merge(array, left, mid, right);
            }

        }

        private void merge(int[] array, int left, int mid, int right)
        {
            int[] arrayB = new int[right - left + 1];
            int i = left, j = mid + 1, placement = 0;
            while (i <= mid && j <= right)
            {
                if (array[i] < array[j])
                    arrayB[placement++] = array[i++];
                else
                    arrayB[placement++] = array[j++];
            }
            while (i <= mid) arrayB[placement++] = array[i++];
            while (j <= right) arrayB[placement++] = array[j++];

            for (int k = left; k <= right; k++)
            {
                array[k] = arrayB[k - left];
            }
        }
    }
}
