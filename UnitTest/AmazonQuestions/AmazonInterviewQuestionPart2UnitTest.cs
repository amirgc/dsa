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
    }
}
