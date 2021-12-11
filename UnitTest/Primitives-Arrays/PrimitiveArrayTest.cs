using DataStrcutureAlgorithm.BTBSWE;
using DataStrcutureAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTest.Primitives_Arrays
{
    public class PrimitiveArrayTest
    {
        private readonly Primitives _primitives;

        public PrimitiveArrayTest()
        {
            _primitives = new Primitives();
        }

        [Fact]
        public void threeSumTest()
        {
            var res = _primitives.threeSum(new int[] { -3, -1, 1, 0, 2, 10, -2, 8 });
        }

        [Fact]
        public void spiralTest()
        {

            var res = _primitives.spiralOrder(new int[][] {
                                                        new int[] { 1, 2, 3 ,5},
                                                        new int[] { 1, 2, 3 ,5},
                                                        new int[] { 1, 2, 3 ,5},
                                                        new int[] { 1, 2, 3 ,5},
                                                       }
                                           );
        }


        [Fact]
        public void kSmallestElementsTest()
        {
            var res = _primitives.kSmallestElements(new int[] { 3, 1, -2, 5, 7 }, 2);

        }
        [Fact]
        public void wordSubsetsTest()
        {

            var res = _primitives.wordSubsets(new List<string> { "padding", "css", "randomcs" },
                                              new List<string> { "cs", "c" }
                                           );
        }

        [Fact]
        public void makeStringValidTest()
        {

            var res = _primitives.makeStringValid("((()");
        }

        [Fact]
        public void lowestCommonAncestorTest()
        {
            var leaf0 = new TreeNode(1);
            var leaf1 = new TreeNode(17);
            var leaf2 = new TreeNode(80);
            var leaf3 = new TreeNode(101);

            var level1Left = new TreeNode(25, leaf0, leaf1);
            var level1Right = new TreeNode(100, leaf2, leaf3);

            var root = new TreeNode(50, level1Left, level1Right);

            var res = _primitives.lowestCommonAncestor(root, 80, 100);

            Assert.Equal(50, res.val);
        }
    }
}
