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
        private readonly TreeBuilder treeBuilder;
        public AmazonInterviewQuestionPart2UnitTest()
        {
            trieSearch = new TrieSearch();
            amazonInterviewQuestions = new AmazonInterviewQuestions();
            treeBuilder = new TreeBuilder();
        }

        [Fact]
        public void TreeBuildertest()
        {
            var test=treeBuilder.buildTree(new string[] { "3", "4", "+", "2", "*", "7", "/" });
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
    }
}
