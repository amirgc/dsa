using DataStrcutureAlgorithm.Algorithms;
using Xunit;

namespace UnitTest.Algorithms
{
    public class AglorithmPart1UnitTest
    {
        private readonly AlgorithmReviewPartOne algorithmReviewPartOne;
        public AglorithmPart1UnitTest()
        {
            algorithmReviewPartOne = new AlgorithmReviewPartOne();
        }

        [Fact]
        public void SortedSquaresTest()
        {
            var ip = new int[] { -4, -1, 0, 3, 10 };
            var op = new int[] { 0, 1, 9, 16, 100 };
            var res = algorithmReviewPartOne.SortedSquares(ip);
            Assert.Equal(op, res);
        }
    }
}
