using DataStrcutureAlgorithm.LeetCode;
using System.Collections.Generic;
using Xunit;

namespace UnitTest.AmazonQuestions
{
    public class AmazonPracticeThreeUnitTest
    {
        private readonly AmazonPracticeThree _amazonPracticeThree;
        public AmazonPracticeThreeUnitTest()
        {
            _amazonPracticeThree = new AmazonPracticeThree();
        }

        [Fact]
        public void TestWordLadder()
        {
            var res = _amazonPracticeThree.LadderLength("hit", "cog", new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" });
            Assert.Equal(5, res);
        }
    }
}
