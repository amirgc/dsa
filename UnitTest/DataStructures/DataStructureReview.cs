using DataStrcutureAlgorithm.DataStructures;
using Xunit;

namespace DataStrcutureAlgorithm.UnitTest.DataStructures
{
    public class DataStructureReviewTestClass
    {
        private readonly DataStructureReview dataStructureReview;
        public DataStructureReviewTestClass()
        {
            dataStructureReview = new DataStructureReview();
        }

        [Fact]
        public void ShouldReturnTrue()
        {
            var ip = new int[][]
            {
                    new int[]{ 1, 3, 5, 7},
                    new int[]{ 10,11,16,20},
                    new int[]{ 23,30,34,60},
            };

            var res = dataStructureReview.SearchMatrix(ip, 3);
            bool expected = false;
            Assert.Equal(res, expected);
        }

        [Fact]
        public void FirstUniqCharTest()
        {
            var res = dataStructureReview.FirstUniqChar("loveleetcode");
            Assert.Equal(2, res);
        }

        [Fact]
        public void CanConstructTest()
        {
            var res = dataStructureReview.CanConstruct("z", "b");

            Assert.True(!res);
        }

        [Fact]
        public void IsAnagramTest()
        {
            var res = dataStructureReview.IsAnagram("z", "b");

            Assert.True(!res);
        }

        [Fact]
        public void MergeTwoListsTest()
        {
            var l1 = new ListNode(4);
            var la = new ListNode(2);
            var lb = new ListNode(1);

            lb.next = la;
            la.next = l1;

            var l2 = new ListNode(4);
            var lc = new ListNode(3);
            var ld = new ListNode(1);

            ld.next = lc;
            lc.next = l2;

            var res = dataStructureReview.MergeTwoLists(lb, ld);

            Assert.Equal(1, res.val);
        }
    }
}
