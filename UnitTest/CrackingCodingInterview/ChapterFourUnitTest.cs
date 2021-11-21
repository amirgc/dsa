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

            var left1 = new TreeNode();
            var right1 = new TreeNode();

            treeNode.left = left1;
            treeNode.right = right1;

            return treeNode;
        }
    }
}
