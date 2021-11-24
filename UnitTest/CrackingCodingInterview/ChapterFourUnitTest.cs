using DataStrcutureAlgorithm.CrackingCodingInterview;
using DataStrcutureAlgorithm.Models;
using Xunit;

namespace UnitTest.CrackingCodingInterview
{
    public class ChapterFourUnitTest
    {
        private readonly Chapter4Tree _chapter4Tree;
        public ChapterFourUnitTest()
        {
            _chapter4Tree = new Chapter4Tree();
        }

        [Fact]
        public void AllSequence()
        {
            var res = _chapter4Tree.AllSequence(PrepareTreeNode());
        }

        public TreeNode PrepareTreeNode()
        {
            var treeNode = new TreeNode();
            treeNode.val = 2;

            var left1 = new TreeNode();
            left1.val = 1;
            var right1 = new TreeNode();
            right1.val = 3;
            treeNode.left = left1;
            treeNode.right = right1;

            return treeNode;
        }
    }
}
