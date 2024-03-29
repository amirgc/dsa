﻿using DataStrcutureAlgorithm.Algorithms;
using DataStrcutureAlgorithm.BTBSWE;
using DataStrcutureAlgorithm.CrackingCodingInterview;
using DataStrcutureAlgorithm.DataStructures;
using DataStrcutureAlgorithm.LeetCode;
using System;
using System.Collections.Generic;

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



            //UnDirectedWeightedGraph g = new UnDirectedWeightedGraph();
            //g.InsertVertex("A");
            //g.InsertVertex("B");
            //g.InsertVertex("C");
            //g.InsertVertex("D");
            //g.InsertVertex("E");

            //g.InsertEdge("A", "C", 3);
            //g.InsertEdge("B", "C", 10);
            //g.InsertEdge("B", "D", 4);
            //g.InsertEdge("C", "E", 6);
            //g.InsertEdge("C", "D", 2);
            //g.InsertEdge("D", "E", 1);

            //g.Prims();

            int[,] graph =  {   // A  B   C  D   E   F   G    H   I
                                 { 0, 6,  0, 0,  0,  0,  0,   9,  0 }, //A
                                 { 6, 0,  9, 0,  0,  0,  0,   11, 0 }, //B
                                 { 0, 9,  0, 5,  0,  6,  0,   0,  2 }, //C
                                 { 0, 0,  5, 0,  9,  16, 0,   0,  0 }, //D
                                 { 0, 0,  0, 9,  0,  10, 0,   0,  0 }, //E
                                 { 0, 0,  6, 0,  10, 0,  2,   0,  0 }, //F
                                 { 0, 0,  0, 16, 0,  2,  0,   1,  6 }, //G
                                 { 9, 11, 0, 0,  0,  0,  1,   0,  5 }, //H
                                 { 0, 0,  2, 0,  0,  0,  6,   5,  0 }  //I
                            };
            var obj = new Dijkstra();
            obj.DijkstraAlgo(graph, 0, 9);

            //DijkstraGraph g = new DijkstraGraph();
            //g.FindMinimumDistancePathBetweenNode();
            //var _amazonInterviewQuestions = new AmazonInterviewQuestions();
            //var points = new int[][] {new int[]{ 2,1,1},
            //                          new int[]{1,1,0},
            //                          new int[]{ 0, 1, 1 }
            //                         };
            //var res = _amazonInterviewQuestions.OrangesRotting(points);

            //var ob = new AmazonInterViewPart2();
            //var testCase = new int[][]
            //{
            //    new int[]{ 1,2,3,4,5},
            //    new int[]{6,7,8,9,10 },
            //    new int[]{11,12,13,14,15 },
            //    new int[]{16,17,18,19,20 },
            //    new int[]{21,22,23,24,25 },
            //};

            //ob.Rotate(testCase);

            //var ob = new SelectionSort();
            //ob.FindKthLargest(new int[] { 3, 2, 1, 4, 6, 5 }, 2);

            //var med = new MedianFinder();
            //med.AddNum(1);
            //med.AddNum(2);
            //med.FindMedian();
            //med.AddNum(3);
            //med.FindMedian();
            var new_list = new List<List<int>>();
            new_list.Add(new List<int>());
            var res=SubSets(0, new int[] { 1, 2, 3, 4 }, new_list);
            foreach (var items in res)
            {
                Console.Write($"[");
                foreach (var item in items )
                {
                    Console.Write($"{item},");
                }

                Console.Write($"]");
                Console.WriteLine();
            }
            Console.Read();
        }

        public static List<List<int>> SubSets(int idx, int[] nums, List<List<int>> sets)
        {
            if (idx >= nums.Length) return sets;

            var new_sets = new List<List<int>>(sets);

            foreach (var item in sets)
            {
                var new_set = new List<int>(item);
                new_set.Add(nums[idx]);
                new_sets.Add(new_set);
            }

            return SubSets(idx + 1, nums, new_sets);

        }
    }
}
