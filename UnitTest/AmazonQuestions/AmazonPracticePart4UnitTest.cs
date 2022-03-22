using DataStrcutureAlgorithm.LeetCode;
using System.Collections.Generic;
using Xunit;

namespace UnitTest.AmazonQuestions
{
    public class AmazonPracticePart4UnitTest
    {
        private readonly AmazonInterviewPart4 _amazon_part4;
        public AmazonPracticePart4UnitTest()
        {
            _amazon_part4 = new AmazonInterviewPart4();
        }

        [Fact]
        public void TestAccoutnMerge()
        {
            var testCase = new List<IList<string>>();
            testCase.Add(new List<string> { "John", "johnsmith@mail.com", "john_newyork@mail.com" });
            testCase.Add(new List<string> { "John", "johnsmith@mail.com", "john00@mail.com" });
            testCase.Add(new List<string> { "Mary", "mary@mail.com" });
            testCase.Add(new List<string> { "John", "johnnybravo@mail.com" });

            _amazon_part4.AccountsMerge(testCase);
        }

        [Fact]
        public void MinCostTest()
        {
            //[[17,2,17],[16,16,5],[14,3,19]]
            var testCase = new int[][] {
                new int[] { 17, 2, 17 },
                new int[] { 16, 16, 5 },
                new int[] { 14, 3, 19 }
                };
            var res = _amazon_part4.MinCost(testCase);
            Assert.Equal(10, res);
        }

        //[Fact]
        //public void MeetingPlanner()
        //{
        //    int[,] slotsA = new int[,] { { 10, 50 }, { 10, 50 }, { 10, 50 } };
        //    int[,] slotsB = new int[,] { { 2, 11 } };
        //    var res = _amazon_part4.MeetingPlanner(slotsA, slotsB, 5);
        //}

        [Fact]
        public void MeetingPlanner()
        {
            int[,] slotsA = new int[,] { { 10, 50 }, { 10, 50 }, { 10, 50 } };
            int[,] slotsB = new int[,] { { 2, 11 } };
            var res = _amazon_part4.reassignedShelves(new List<int> { 1, 12, 4, 12 });
        }

        [Fact]
        public void CountComponentsTEst()
        {
            int[,] slotsA = new int[,] { { 10, 50 }, { 10, 50 }, { 10, 50 } };
            int[,] slotsB = new int[,] { { 2, 11 } };
            var res = _amazon_part4.CountComponents(4, new int[][] {
                                                           new int []{2,3},
                                                           new int []{1,2},
                                                           new int []{1,3}
                                                   });
        }

        [Fact]
        public void CommonTest()
        {
            _amazon_part4.tip();
        }
    }
}
