using DataStrcutureAlgorithm.LeetCode;
using Xunit;

namespace UnitTest.AmazonQuestions
{
    public class AmazonInterviewQuestionsUnitTest
    {
        private readonly AmazonInterviewQuestions _amazonInterviewQuestions;
        public AmazonInterviewQuestionsUnitTest()
        {
            _amazonInterviewQuestions = new AmazonInterviewQuestions();
        }

        [Fact]
        public void GroupAnagramsTest()
        {
            var test = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            var result = _amazonInterviewQuestions.GroupAnagrams(test);
        }

        [Fact]
        public void WordExistText()
        {
            var test = new char[3][];
            test[0] = new char[] { 'A', 'B', 'Y', 'E' };
            test[1] = new char[] { 'B', 'F', 'C', 'S' };
            test[2] = new char[] { 'B', 'D', 'E', 'E' };

            var res = _amazonInterviewQuestions.Exist(test, "ABBDEE");

            Assert.True(res);
        }

        [Fact]
        public void WordExistText1()
        {
            var test = new char[3][];
            test[0] = new char[] { 'A', 'B', 'C', 'E' };
            test[1] = new char[] { 'S', 'F', 'C', 'S' };
            test[2] = new char[] { 'A', 'D', 'E', 'E' };

            var res = _amazonInterviewQuestions.Exist(test, "ABCB");

            Assert.False(res);
        }

        [Fact]
        public void WordExistText2()
        {
            var test = new char[3][];
            test[0] = new char[] { 'A', 'B', 'C', 'E' };
            test[1] = new char[] { 'S', 'F', 'C', 'S' };
            test[2] = new char[] { 'A', 'D', 'E', 'E' };

            var res = _amazonInterviewQuestions.Exist(test, "ABCC");

            Assert.True(res);
        }

        [Fact]
        public void NumOfIsLandTest()
        {
            var test = new char[4][];
            test[0] = new char[] { '1', '1', '0', '0', '0' };
            test[1] = new char[] { '1', '1', '0', '0', '0' };
            test[2] = new char[] { '0', '0', '1', '0', '0' };
            test[2] = new char[] { '0', '0', '0', '1', '1' };

            var res = _amazonInterviewQuestions.NumIslands(test);

            Assert.Equal(3, res);
        }
    }
}
