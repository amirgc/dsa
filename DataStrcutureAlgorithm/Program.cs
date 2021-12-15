using DataStrcutureAlgorithm.Algorithms;
using DataStrcutureAlgorithm.BTBSWE;
using DataStrcutureAlgorithm.CrackingCodingInterview;
using DataStrcutureAlgorithm.DataStructures;
using System;

namespace DataStrcutureAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //    Console.WriteLine("Hello World!");
            //    Chapter1.isUniqueChars("whatspups");
            //var test= Chapter1_Palindrome.IsPermutationOfPalindrome("MISSMISS");

            //single linked list
            //var singleLinkedList = new SingleLinkedList("1");
            //singleLinkedList.AddNodeToTail("2").AddNodeToTail("3").AddNodeToTail("4").AddNodeToTail("5").Print();

            //LeetCode.StringToInteger.MaxProfit(new int[] { 3, 2, 6, 5, 0, 3 });
            //LeetCode.StringToInteger.MaxProfit(new int[] { 6, 1, 3, 2, 4, 7 });
            //LeetCode.StringToInteger.MaxProfit(new int[] { 2, 1, 2, 1, 0, 1, 2 });

            //      var charTy = new char[][]
            //{
            //         new char[]{'.', '.', '.', '.', '.', '.', '5', '.', '.'},
            //         new char[]{'.', '.', '.', '.', '.', '.', '.', '.', '.'},
            //         new char[]{'.', '.', '.', '.', '.', '.', '.', '.', '.'},
            //         new char[]{'9', '3', '.', '.', '2', '.', '4', '.', '.'},
            //         new char[]{'.', '.', '7', '.', '.', '.', '3', '.', '.'},
            //         new char[]{'.', '.', '.', '.', '.', '.', '.', '.', '.'},
            //         new char[]{'.', '.', '.', '3', '4', '.', '.', '.', '.'},
            //         new char[]{'.', '.', '.', '.', '.', '3', '.', '.', '.'},
            //         new char[]{'.', '.', '.', '.', '.', '5', '2', '.', '.' }
            //};

            //      var res = LeetCode.StringToInteger.IsValidSudoku(charTy);
            //var _primitives = new Primitives();
            //var res = _primitives.restoreIpAddresses("125523213");
            //res.ForEach(x => Console.WriteLine(x));



            UnDirectedWeightedGraph g = new UnDirectedWeightedGraph();
            g.InsertVertex("A");
            g.InsertVertex("B");
            g.InsertVertex("C");
            g.InsertVertex("D");
            g.InsertVertex("E");

            g.InsertEdge("A", "C", 3);
            g.InsertEdge("B", "C", 10);
            g.InsertEdge("B", "D", 4);
            g.InsertEdge("C", "E", 6);
            g.InsertEdge("C", "D", 2);
            g.InsertEdge("D", "E", 1);

            g.Prims();

            Console.Read();
        }
    }
}
