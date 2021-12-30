using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.LeetCode1
{
    public abstract class Node
    {
        public abstract int evaluate();
    };

    public class TreeNode : Node
    {
        public string Value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(string data = null, TreeNode left = null, TreeNode right = null)
        {
            this.Value = data;
            this.Left = left;
            Right = right;
        }

        public override int evaluate()
        {
            return dfs(this);
        }

        private int dfs(TreeNode node)
        {
            if (node.Left == null && node.Right == null)
            {
                return Convert.ToInt32(node.Value);
            }

            int left = dfs(node.Left);
            int right = dfs(node.Right);
            int res = 0;

            if (node.Value == "+")
                res = left + right;
            else if (node.Value == "-")
                res = left - right;
            else if (node.Value == "/")
                res = left / right;
            else if (node.Value == "*")
                res = left * right;

            return res;
        }
    }

    public class TreeBuilder
    {
        Stack<TreeNode> treeStack = new Stack<TreeNode>();
        List<string> operators = new List<string> { "+", "-", "/", "*" };

        public Node buildTree(string[] postfix)
        {
            for (int i = 0; i < postfix.Length; i++)
            {
                if (!operators.Contains(postfix[i]))
                {
                    treeStack.Push(new TreeNode(postfix[i]));
                }
                else
                {
                    var right = treeStack.Pop();
                    var left = treeStack.Pop();
                    var node = new TreeNode(postfix[i], left, right);
                    treeStack.Push(node);
                }
            }

            return treeStack.Pop();
        }
    }
}