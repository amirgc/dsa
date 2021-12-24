using DataStrcutureAlgorithm.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTest.AmazonQuestions
{
    public class AmazonInterviewQuestionPart2UnitTest
    {
        private readonly TrieSearch trieSearch;
        public AmazonInterviewQuestionPart2UnitTest()
        {
            trieSearch = new TrieSearch();

        }

        [Fact]
        public void TestTrieSearch()
        {
            var test = new string[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" };
            var res = trieSearch.suggestedProducts(test, "mouse");
        }
    }
}
