using DataStrcutureAlgorithm.Algorithms;
using Xunit;

namespace UnitTest.Algorithms
{
    public class AglorithmPart1UnitTest
    {
        private readonly AlgorithmReviewPartOne algorithmReviewPartOne;
        private readonly KrusKalAlgorithm krusKalAlgorithm;
        public AglorithmPart1UnitTest()
        {
            algorithmReviewPartOne = new AlgorithmReviewPartOne();
            krusKalAlgorithm = new KrusKalAlgorithm();
        }

        [Fact]
        public void SortedSquaresTest()
        {
            var ip = new int[] { -4, -1, 0, 3, 10 };
            var op = new int[] { 0, 1, 9, 16, 100 };
            var res = algorithmReviewPartOne.SortedSquares(ip);
            Assert.Equal(op, res);
        }

        [Fact]
        public void RotateTest()
        {
            algorithmReviewPartOne.Rotate(new int[] { 1, 2 }, 3);
        }

        [Fact]
        public void KruskalAlgorithmTest()
        {
            var test = new int[][]
            {
               new int[] {1, 2, 5},
               new int[] {1, 3, 6},
               new int[] { 2, 3,1 }
            };

            var res = krusKalAlgorithm.minimumCost(3, test);
            Assert.Equal(6, res);
        }

        [Fact]
        public void KruskalAlgorithmTestWithOOA()
        {
            var test = new int[][]
            {
               new int[] {1, 2, 5},
               new int[] {1, 3, 6},
               new int[] { 2, 3,1 }
            };

            var res = krusKalAlgorithm.MinimumCost2(3, test);
            Assert.Equal(6, res);
        }
    }
}
