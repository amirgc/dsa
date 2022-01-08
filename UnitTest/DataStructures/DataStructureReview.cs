using DataStrcutureAlgorithm.DataStructures;
using DataStrcutureAlgorithm.Models;
using UnitTest.DataStructures;
using Xunit;

namespace DataStrcutureAlgorithm.UnitTest.DataStructures
{
    public class DataStructureReviewTestClass
    {
        private readonly DataStructureReview dataStructureReview;
        private readonly DataStructureReviewTwo dataStructureReviewtwo;
        private readonly SortingAlgorithms mergeSort;
        public DataStructureReviewTestClass()
        {
            dataStructureReview = new DataStructureReview();
            dataStructureReviewtwo = new DataStructureReviewTwo();
            mergeSort = new SortingAlgorithms();
        }
        [Fact]
        public void MergeSortUnitTest()
        {
            var res = mergeSort.mergeSort(new int[] { 7, 5, 2, 9, 1 });
            Assert.Equal(res, new int[] { 1, 2, 5, 7, 9 });
        }

        [Fact]
        public void QuickSortTest()
        {
            var res = mergeSort.quicksort(new int[] { 11, 7, 9, 2, 1, 8, 5 });
            Assert.Equal(res, new int[] { 1, 2, 5, 7, 8, 9, 11 });

            //var res = mergeSort.quicksort(new int[] { 4, 2, 7, 3, 1 });
            //Assert.Equal(res, new int[] { 1, 2, 5, 7, 8, 9, 11 });
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

        [Fact]
        public void RemoveElementsTest()
        {
            var l1 = new ListNode(1);
            var l2 = new ListNode(2);
            var l3 = new ListNode(2);
            var l4 = new ListNode(1);

            l1.next = l2;
            l2.next = l3;
            l3.next = l4;

            var res = dataStructureReview.RemoveElements(l1, 2);

            Assert.Equal(1, res.val);
        }

        [Fact]
        public void ReverseListTest()
        {
            var l1 = new ListNode(1);
            var l2 = new ListNode(2);
            var l3 = new ListNode(3);
            var l4 = new ListNode(4);
            var l5 = new ListNode(5);

            l1.next = l2;
            l2.next = l3;
            l3.next = l4;
            l4.next = l5;

            var res = dataStructureReview.ReverseList(l1);

            Assert.Equal(5, res.val);
        }

        [Fact]
        public void IsValidTest()
        {
            var res = dataStructureReview.IsValid("()[]{}");
            Assert.True(res);

        }

        [Fact]
        public void IsSymmetricTect()
        {
            var rootNode = new TreeNode(val: 1);

            rootNode.right = new TreeNode(val: 2);
            rootNode.left = new TreeNode(val: 2);

            rootNode.right.left = new TreeNode(val: 3);
            rootNode.right.right = new TreeNode(val: 4);

            rootNode.left.left = new TreeNode(val: 4);
            rootNode.left.right = new TreeNode(val: 3);

            var res = dataStructureReview.IsSymmetric(rootNode);
            Assert.True(res);

        }

        [Fact]
        public void IsFoundBadversion()
        {
            var res = dataStructureReviewtwo.FirstBadVersion(2126753390);
            Assert.Equal(1702766720, res);
        }

        [Fact]
        public void MergeTest()
        {
            var testSet = new int[6][];
            testSet[0] = new int[2] { 2, 3 };
            testSet[1] = new int[2] { 4, 5 };
            testSet[2] = new int[2] { 6, 7 };
            testSet[3] = new int[2] { 8, 9 };
            testSet[4] = new int[2] { 1, 10 };

            testSet[0] = new int[2] { 1, 3 };
            testSet[1] = new int[2] { 2, 6 };
            testSet[2] = new int[2] { 8, 10 };
            testSet[3] = new int[2] { 8, 16 };
            testSet[4] = new int[2] { 15, 18 };
            testSet[5] = new int[2] { 20, 24 };
            var res = dataStructureReview.Merge(testSet);
        }
    }
}
