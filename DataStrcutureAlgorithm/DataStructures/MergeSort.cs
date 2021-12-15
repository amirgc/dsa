using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.DataStructures
{
    public class SortingAlgorithms
    {
        public int[] mergeSort(int[] array)
        {
            mergeSort(array, 0, array.Length - 1);
            return array;
        }

        public int[] quicksort(int[] arr)
        {
            quicksort(arr, 0, arr.Length - 1);

            return arr;
        }

        // Helper function to recursively perform quicksort
        // quicksort will be called recursively for the elemnts to the left of pivot
        // And the elements to the right of pivot
        private void quicksort(int[] arr, int left, int right)
        {

            // Only proceed if left is less than right
            if (left < right)
            {
                // Find the position of pivot
                int pivotFinalRestingPosition = partition(arr, left, right);

                // Recursively call left and right subarray to the pivot
                quicksort(arr, left, pivotFinalRestingPosition - 1);
                quicksort(arr, pivotFinalRestingPosition + 1, right);
            }
        }

        /*
         * The partition function that chooses a pivot, partitions the array around the
         * pivot, places the pivot value where it belongs, and then returns the index of
         * where the pivot finally lies
         */
        private int partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];

            /*
             * i will keep track of the "tail" of the section of items less than the pivot
             * so that at the end we can "sandwich" the pivot between the section less than
             * it and the section greater than it
             */
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;

                    swap(arr, i, j);
                }
            }

            swap(arr, i + 1, right);

            return i + 1; // Return the pivot's final resting position
        }

        private void swap(int[] arr, int first, int second)
        {
            int temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
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
