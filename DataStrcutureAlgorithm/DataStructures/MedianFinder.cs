using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.DataStructures
{
    public class MedianFinder
    {
        int arr_size = 30;
        int[] store;
        int idx = 0;
        public MedianFinder()
        {
            store = new int[arr_size];
            Array.Fill(store, int.MaxValue);
        }

        public void AddNum(int num)
        {
            if (idx > arr_size - 1)
                doubleArraySize();

            store[idx] = num;
            //sortArray();

            idx++;
        }

        public double FindMedian()
        {
            Array.Sort(store);
            if (idx == 0)
                return 0.00;

            if (idx % 2 == 0)
            {
                return (store[(idx / 2) - 1] + store[idx / 2]) / 2.00;
            }

            return store[idx / 2];
        }

        private void sortArray()
        {
            int temp_idx = idx;
            while (temp_idx > 0 && store[temp_idx - 1] > store[temp_idx])
            {
                int temp = store[temp_idx];
                store[temp_idx] = store[temp_idx - 1];
                store[temp_idx - 1] = temp;
                temp_idx--;
            }
        }

        private void doubleArraySize()
        {
            int new_size = arr_size * 2;
            int[] new_array = new int[new_size];
            Array.Fill(new_array, int.MaxValue);
            for (int i = 0; i < idx; i++)
            {
                new_array[i] = store[i];
            }

            store = new_array;
            arr_size = new_size;
        }
    }
}
