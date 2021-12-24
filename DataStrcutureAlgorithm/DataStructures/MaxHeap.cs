
namespace DataStrcutureAlgorithm.DataStructures
{
    // Priority Queue Implementation
    public class MaxHeap
    {
        int priotityQueueSize;
        int real_Size;
        int[] max_Heap;

        public MaxHeap(int size)
        {
            this.priotityQueueSize = size;
            real_Size = 0;
            max_Heap = new int[this.priotityQueueSize + 1];
        }

        public int Peek()
        {
            return max_Heap[1];
        }

        public void Add(int item)
        {
            real_Size++;

            if (real_Size > priotityQueueSize)
            {
                real_Size--;
                return;
            }

            max_Heap[real_Size] = item;

            int index = real_Size;
            int parent = index / 2;

            while (max_Heap[parent] < max_Heap[index] && index > 1)
            {
                int temp = max_Heap[parent];
                max_Heap[parent] = max_Heap[index];
                max_Heap[index] = temp;
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

            int max_val = max_Heap[1];
            max_Heap[1] = max_Heap[real_Size];
            real_Size--;
            int parent = 1;

            while (parent < real_Size && parent <= real_Size / 2)
            {
                int indexLeft = parent * 2;
                int indexRight = (parent * 2) + 1;
                if (max_Heap[parent] < max_Heap[indexLeft] || max_Heap[parent] < max_Heap[indexRight])
                {
                    if (max_Heap[indexRight] < max_Heap[indexLeft])
                    {
                        int temp = max_Heap[parent];
                        max_Heap[parent] = max_Heap[indexLeft];
                        max_Heap[indexLeft] = temp;
                        parent = indexLeft;
                    }
                    else
                    {
                        int temp = max_Heap[parent];
                        max_Heap[parent] = max_Heap[indexRight];
                        max_Heap[indexRight] = temp;
                        parent = indexRight;
                    }
                }
                else
                {
                    break;
                }
            }

            return max_val;
        }

        public int GetHeapSize()
        {
            return real_Size;
        }

    }
}
