using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.Concepts
{
    public class ResizeAbleArray
    {
        public int Count { get; }
        private int[] array;
        private int counter = 0;
        private int defaultSize = 10;

        public int Add(int val)
        {
            if (defaultSize < counter)
            {
                ResizeArray();
            }

            array[counter] = val;
            counter++;

            return val;
        }

        public void ResizeArray()
        {
            defaultSize = defaultSize * 2;
            int[] arrayNew = new int[defaultSize];

            for (int i = 0; i < array.Length; i++)
            {
                arrayNew[i] = array[i];
            }
            array = arrayNew;
        }
    }
}
