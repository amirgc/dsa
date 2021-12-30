using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.DataStructures
{
    // Priority Queue Implementation
    public class PriorityQueueC
    {
        int priotityQueueSize;
        int real_Size;
        int[] min_Heap;

        public PriorityQueueC(int size)
        {
            this.priotityQueueSize = size;
            real_Size = 0;
            min_Heap = new int[this.priotityQueueSize + 1];
        }

        public int Peek()
        {
            return min_Heap[1];
        }

        public void Add(int item)
        {
            real_Size++;

            if (real_Size > priotityQueueSize)
            {
                real_Size--;
                return;
            }

            min_Heap[real_Size] = item;

            int index = real_Size;
            int parent = index / 2;

            while (min_Heap[parent] > min_Heap[index] && index > 1)
            {
                int temp = min_Heap[parent];
                min_Heap[parent] = min_Heap[index];
                min_Heap[index] = temp;
                index = parent;
                parent = index / 2;
            }
        }

        public int Poll()
        {
            if (real_Size < 1)
            {
                return int.MinValue;
            }
            int min_val = min_Heap[1];
            min_Heap[1] = min_Heap[real_Size];
            real_Size--;
            int parent = 1;

            while (parent < real_Size && parent <= real_Size / 2)
            {
                int indexLeft = parent * 2;
                int indexRight = (parent * 2) + 1;
                if (min_Heap[parent] > min_Heap[indexLeft] || min_Heap[parent] > min_Heap[indexRight])
                {
                    if (min_Heap[indexRight] > min_Heap[indexLeft])
                    {
                        int temp = min_Heap[parent];
                        min_Heap[parent] = min_Heap[indexLeft];
                        min_Heap[indexLeft] = temp;
                        parent = indexLeft;
                    }
                    else 
                    {
                        int temp = min_Heap[parent];
                        min_Heap[parent] = min_Heap[indexRight];
                        min_Heap[indexRight] = temp;
                        parent = indexRight;
                    }
                }
                else
                {
                    break;
                }
            }

            return min_val;
        }

        public int GetHeapSize()
        {
            return real_Size;
        }

    }

}
