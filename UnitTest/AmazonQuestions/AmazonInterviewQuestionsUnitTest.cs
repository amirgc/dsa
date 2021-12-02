using DataStrcutureAlgorithm.LeetCode;
using System.Collections.Generic;
using Xunit;

namespace UnitTest.AmazonQuestions
{
    public class AmazonInterviewQuestionsUnitTest
    {
        private readonly AmazonInterviewQuestions _amazonInterviewQuestions;
        private readonly FindOrderSolution _findOrderSolution;
        private readonly UndirectedGraph _undirectedGraph;

        public AmazonInterviewQuestionsUnitTest()
        {
            _amazonInterviewQuestions = new AmazonInterviewQuestions();
            _findOrderSolution = new FindOrderSolution();
            _undirectedGraph = new UndirectedGraph();
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
            test[3] = new char[] { '0', '0', '0', '1', '1' };

            var res = _amazonInterviewQuestions.NumIslands(test);

            Assert.Equal(3, res);
        }

        [Fact]
        public void FindOrderSolutiontest()
        {
            //[[1,0],[2,0],[3,1],[3,2]]
            var test = new int[4][];
            test[0] = new int[] { 1, 0 };
            test[1] = new int[] { 2, 0 };
            test[2] = new int[] { 3, 1 };
            test[3] = new int[] { 3, 2 };
            var res = _findOrderSolution.FindOrder(4, test);
        }

        [Fact]
        public void MeetingIntervalUnitTest()
        {
            //[[8,14],[12,13],[6,13],[1,9]] [[1,8],[6,20],[9,16],[13,17]]
            var interval = new int[4][];
            interval[0] = new int[] { 8, 14 };
            interval[1] = new int[] { 12, 13 };
            interval[2] = new int[] { 6, 13 };
            interval[3] = new int[] { 1, 9 };
            var res = _amazonInterviewQuestions.minMeetingRoomsSecondSolution(interval);

            Assert.Equal(3, res);
        }

        [Fact]
        public void MeetingIntervalUnitTestShouldReturn3()
        {
            //[[1,8],[6,20],[9,16],[13,17]]
            var interval = new int[4][];
            interval[0] = new int[] { 13, 17 };
            interval[1] = new int[] { 9, 16 };
            interval[2] = new int[] { 6, 20 };
            interval[3] = new int[] { 1, 8 };
            var res = _amazonInterviewQuestions.minMeetingRoomsSecondSolution(interval);

            Assert.Equal(3, res);
        }

        [Fact]
        void TotalPathinUnDrectedGraph()
        {
            //[[0, 1],[1,2],[3,4]]
            var test = new int[3][];
            test[0] = new int[] { 0, 1 };
            test[1] = new int[] { 1, 2 };
            test[2] = new int[] { 3, 4 };

            var res = _undirectedGraph.CountComponents(5, test);
            Assert.Equal(2, res);
        }
        [Fact]
        void FindCircleNumTest()
        {
            //[[1,1,0],[1,1,0],[0,0,1]]
            var test = new int[3][];
            test[0] = new int[] { 1, 1, 0 };
            test[1] = new int[] { 1, 1, 0 };
            test[2] = new int[] { 0, 0, 1 };

            var res = _amazonInterviewQuestions.findCircleNum(test);
            Assert.Equal(2, res);
        }

        [Fact]
        void SumSubarrayMinsTestTry()
        { 
            var test = new int[] { 2, 8, 9, 3, 4, 1 };
            var res = _amazonInterviewQuestions.SumSubarrayMins(test);
            Assert.Equal(63, res);
        }

        [Fact]
        void isPalindromeTest()
        {
            var res = _amazonInterviewQuestions.isPalindrome(12121);
            Assert.True(res);
        }

        [Fact]
        void FindTheDistanceBetweenTimeTest()
        {
            var res = _amazonInterviewQuestions.timeDifference(new List<string>() { "00:03", "23:59", "12:03" });
        }

        [Fact]
        void ReverseBitTest()
        {
            var res = _amazonInterviewQuestions.reverseBits(1);
            Assert.Equal(1, res);
        }
    }
}
