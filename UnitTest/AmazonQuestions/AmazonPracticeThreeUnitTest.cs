using DataStrcutureAlgorithm.LeetCode;
using System.Collections.Generic;
using Xunit;
using static DataStrcutureAlgorithm.LeetCode.AmazonPracticeThree;

namespace UnitTest.AmazonQuestions
{
    public class AmazonPracticeThreeUnitTest
    {
        private readonly AmazonPracticeThree _amazonPracticeThree;
        public AmazonPracticeThreeUnitTest()
        {
            _amazonPracticeThree = new AmazonPracticeThree();
        }

        //[Fact]
        //public void TestWordLadder()
        //{
        //    var res = _amazonPracticeThree.LadderLength("hit", "cog", new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" });
        //    Assert.Equal(5, res);
        //}
        //[Fact]
        //public void TestWordLadder1()
        //{
        //    var res = _amazonPracticeThree.LadderLength("hot", "dog", new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" });
        //    Assert.Equal(5, res);
        //}

        [Fact]
        public void TestWordLadderII()
        {
            var res = _amazonPracticeThree.FindLadders("hit", "cog", new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" });
            //Assert.Equal(5, res);
        }

        [Fact]
        public void ReverseInt()
        {
            var res = _amazonPracticeThree.reverse(-123);
        }

        [Fact]
        public void RandomCopyTest()
        {
            NodeRandom node4 = new NodeRandom(1)
            {
                random = null
            };

            NodeRandom node3 = new NodeRandom(10)
            {
                next = node4,
                random = null
            };

            NodeRandom node2 = new NodeRandom(11)
            {
                next = node3,
                random = null
            };

            NodeRandom node1 = new NodeRandom(13)
            {
                next = node2,
                random = null
            };

            NodeRandom node0 = new NodeRandom(7)
            {
                next = node1,
                random = null
            };
            node1.random = node0;
            node2.random = node4;
            node3.random = node2;
            node4.random = node0;

            var res = _amazonPracticeThree.CopyRandomList(node0);
        }

        [Fact]
        public void ThreeSumNearest()
        {
            var _res = _amazonPracticeThree.ThreeSumClosest(new int[] { -1, 2, 1, -4 }, 1);
        }
        [Fact]
        public void TrapWaterTest()
        {
            var res = _amazonPracticeThree.Trap(new int[] { 2, 6, 3, 2, 4, 2, 3, 7, 3, 5 });

            Assert.Equal(18, res);
        }
        [Fact]
        public void ForestTest()
        {
            //[1,2,1,1] [[1,2,3],[0,0,4],[7,6,5]] [[],
            //["Mary","mary@mail.com"],["John","johnnybravo@mail.com"]]
            var forest = new int[][] {
                                new int[] { 1, 2, 3 },
                                new int[] { 0, 0, 4 },
                                new int[] { 7, 6, 5 }
                             };
           _amazonPracticeThree.SortList(new List<string>() { "John", "john_newyork@mail.com", "john00@mail.com", "johnsmith@mail.com" });
        }
    }
}
