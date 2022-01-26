using DataStrcutureAlgorithm.DataStructures;
using DataStrcutureAlgorithm.LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTest.AmazonQuestions
{
    public class AmazonInterviewQuestionPart2UnitTest
    {
        private readonly TrieSearch trieSearch;
        private readonly AmazonInterviewQuestions amazonInterviewQuestions;
        private readonly AmazonInterViewPart2 amazonInterViewPart2;
        private readonly TreeBuilder treeBuilder;
        private readonly ShortestPathGetFood shortestPathGetFood;
        public AmazonInterviewQuestionPart2UnitTest()
        {
            trieSearch = new TrieSearch();
            amazonInterviewQuestions = new AmazonInterviewQuestions();
            treeBuilder = new TreeBuilder();
            shortestPathGetFood = new ShortestPathGetFood();
            amazonInterViewPart2 = new AmazonInterViewPart2();
        }

        [Fact]
        public void TreeBuildertest()
        {
            var test = treeBuilder.buildTree(new string[] { "3", "4", "+", "2", "*", "7", "/" });
            var res = test.evaluate();

            Assert.Equal(2, res);
        }
        [Fact]
        public void TestTrieSearch()
        {
            var test = new string[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" };
            var res = trieSearch.suggestedProducts(test, "mouse");
        }

        [Fact]
        public void testMaxEvents()
        {
            var res = amazonInterviewQuestions.MaxEvents(new int[][] {
                                                                        new int[]{1,2 },
                                                                        new int[]{2,3 },
                                                                        new int[]{3,4 },
                                                                        new int[]{1,2 }
                                                                    });

            Assert.Equal(4, res);
        }

        [Fact]
        public void WordBreakUnitTest()
        {
            var res = amazonInterviewQuestions.WordBreak("applepenapple", new List<string>() { "apple", "pen" });

            Assert.True(res);
        }
        [Fact]
        public void testMaxProfit()
        {
            var res = amazonInterviewQuestions.MaxProfit(new int[] { 2, 5 }, 4);
            Assert.Equal(14, res);
        }

        [Fact]
        public void ShortestPathGetFoodTest()
        {
            var grid = new char[][]
            {
                new char[]{'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
                new char[]{'X', '*', 'O', 'X', 'O', '#', 'O', 'X'},
                new char[]{'X', 'O', 'O', 'X', 'O', 'O', 'X', 'X'},
                new char[]{'X', 'O', 'O', 'O', 'O', '#', 'O', 'X'},
                new char[]{'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'}

            };
            var res = shortestPathGetFood.GetFood(grid);
            Assert.Equal(6, res);
        }


        //[[-1,-1,2],[-1,0,1]]
        [Fact]
        public void ThreeSumTes()
        {
            var res = amazonInterViewPart2.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            Assert.Equal(new List<List<int>>() {
                new List<int>() { -1, -1, 2 },
                new List<int>() { -1, 0, 1 }

            }, res);
        }

        [Fact]
        public void SearchRotated()
        {
            var res = amazonInterViewPart2.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0);
            Assert.Equal(4, res);
        }

        [Fact]
        public void RotateMatrixTest()
        {
            var testCase = new int[][]
            {
                new int[]{ 1,2,3,4,5},
                new int[]{6,7,8,9,10 },
                new int[]{11,12,13,14,15 },
                new int[]{16,17,18,19,20 },
                new int[]{21,22,23,24,25 },
            };

            amazonInterViewPart2.Rotate(testCase);

        }

        [Fact]
        public void CanJumpTest()
        {
            amazonInterViewPart2.CanJump(new int[] { 1, 1, 1, 0 });

        }


        [Fact]
        public void InsetTest()
        {  //
            amazonInterViewPart2.Insert(new int[][] {
                                                     new int[]{1,2},
                                                     new int[]{3,5},
                                                     new int[]{6,7},
                                                     new int[]{8,10},
                                                     new int[]{12,16}
                                                 },
                                                 new int[] { 4, 8 });

        }

        [Fact]
        public void UniquePathsTest()
        {  //
            var res = amazonInterViewPart2.UniquePaths(7, 3);
            Assert.Equal(28, res);

        }

        [Fact]
        public void SetZerosTest()
        {  //[[0,1,2,0],[3,4,5,2],[1,3,1,5]]
            var testcase = new int[3][]{
             new int[]{0,1,2,0 },
             new int[]{ 3,4,5,2},
             new int[]{1,3,1,5 },
            };
            amazonInterViewPart2.SetZeroes(testcase);

        }

        [Fact]
        public void MinimumWindowTest()
        {  //"ADOBECODEBANC"
            //"ABC"
            var res = amazonInterViewPart2.minWindow("ADOBECODEBANC", "ABC");
            Assert.Equal("BANC", res);

        }

        //[Fact]
        //public void DecodeTest()
        //{  //"ADOBECODEBANC"
        //    //"ABC"
        //    var res = amazonInterViewPart2.NumDecodings("12");
        //    Assert.Equal(2, res);

        //}

        [Fact]
        public void WordBreakTest()
        {  //"ADOBECODEBANC"
           //"ABC"
           //[]
            var s = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab";
            var res = amazonInterViewPart2.WordBreak(s, new List<string>() {
                "a","aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa"
            });
            //Assert.Equal(2, res);

        }

        [Fact]
        public void LongestConsecutiveTest()
        {  //"ADOBECODEBANC"
            //"ABC"
            var res = amazonInterViewPart2.LongestConsecutive(new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 });
            //Assert.Equal(2, res);

        }

        [Fact]
        public void FindMedianSortedArraysTest()
        {  //"ADOBECODEBANC"
            //"ABC"
            var res = amazonInterViewPart2.FindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2, 4 });
            //Assert.Equal(2, res);

        }

        [Fact]
        public void TopKFrequentTest()
        {  //"ADOBECODEBANC" []
           //3
           //"ABC" [3,0,1,0]
            var res = amazonInterViewPart2.TopKFrequent(new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 }, 3);
            //Assert.Equal(2, res);

        }
        [Fact]
        public void reverseBitsTest()
        {  //"ADOBECODEBANC" []
           //3
           //"ABC" [3,0,1,0]
           //var res = amazonInterViewPart2.CoinChange(new int[] { 186, 419, 83, 408 }, 6249);
            var res = amazonInterViewPart2.CoinChange(new int[] { 1, 2, 5 }, 11);

            //Assert.Equal(2, res);
            //Assert.Equal(2, res);

        }

        [Fact]
        public void RomanToIntTest()
        {  //"ADOBECODEBANC" []
           //3
           //"ABC" [3,0,1,0]
           //var res = amazonInterViewPart2.CoinChange(new int[] { 186, 419, 83, 408 }, 6249);
            var res = amazonInterViewPart2.RomanToInt("LVIII");

            //Assert.Equal(2, res);
            //Assert.Equal(2, res);

        }
    }
}
