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

            //var charTy = new char[][]
            //        {
            //         new char[] {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
            //         new char[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
            //         new char[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
            //         new char[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
            //         new char[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
            //         new char[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
            //         new char[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
            //         new char[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
            //         new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9'}
            //        };

            var charTy = new char[][]
            {
               new char[]{'.', '.', '.', '.', '.', '.', '5', '.', '.'},
               new char[]{'.', '.', '.', '.', '.', '.', '.', '.', '.'},
               new char[]{'.', '.', '.', '.', '.', '.', '.', '.', '.'},
               new char[]{'9', '3', '.', '.', '2', '.', '4', '.', '.'},
               new char[]{'.', '.', '7', '.', '.', '.', '3', '.', '.'},
               new char[]{'.', '.', '.', '.', '.', '.', '.', '.', '.'},
               new char[]{'.', '.', '.', '3', '4', '.', '.', '.', '.'},
               new char[]{'.', '.', '.', '.', '.', '3', '.', '.', '.'},
               new char[]{'.', '.', '.', '.', '.', '5', '2', '.', '.' }
            };

            var res = LeetCode.StringToInteger.IsValidSudoku(charTy);

            Console.Read();
        }
    }
}
