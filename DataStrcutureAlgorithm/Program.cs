using DataStrcutureAlgorithm.Concepts;
using System;

namespace DataStrcutureAlgorithm
{
    class Program
    {
        public static void Main(string[] args)
        {
            BitManipulation.BitWiseOperatorTest();
            Console.Read();
        }
        public static void print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + ",");
        }
    }
}
