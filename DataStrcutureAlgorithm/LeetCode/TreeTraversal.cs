using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.LeetCode
{
    public class ExpTreeNode
    {
        public ExpTreeNode Left { get; set; }
        public ExpTreeNode Right { get; set; }
        public string Val { get; set; }
    }

    public abstract class Node
    {
        public ExpTreeNode rootNode { get; set; }
        public abstract int evaluate();
        // define your fields here
    };

    public class ExpNode : Node
    {
        public ExpNode()
        {
            rootNode = new ExpTreeNode();
        }

        override
        public int evaluate()
        {
            return DoInOrderTraversal(rootNode);
        }

        private int DoInOrderTraversal(ExpTreeNode node)
        {
            var operators = new List<string> { "+", "-", "/", "*" };
            if (operators.IndexOf(node.Val) < 0)
                return Convert.ToInt32(node.Val);

            var leftValue = DoInOrderTraversal(node.Left);
            var rightvalue = DoInOrderTraversal(node.Right);

            var res = 0;
            switch (node.Val)
            {
                case "+":
                    res = leftValue + rightvalue;
                    break;
                case "-":
                    res = leftValue - rightvalue;
                    break;
                case "*":
                    res = leftValue * rightvalue;
                    break;
                case "/":
                    res = leftValue / rightvalue;
                    break;
                default:
                    break;
            }

            return res;
        }
    }

    public class TreeBuilder
    {
        public Node buildTree(string[] postfix)
        {
            var rootNode = new ExpNode();
            rootNode.rootNode = new ExpTreeNode();
            BuildTree(postfix, rootNode.rootNode, 0, postfix.Length - 1);
            return rootNode;
        }

        public void BuildTree(string[] postfix, ExpTreeNode rootNode, int start, int end)
        {
            if (start > end)
                return;

            rootNode.Val = postfix[end];

            if (end == start)
                return;

            var operators = new List<string> { "+", "-", "/", "*" };
            if (operators.IndexOf(postfix[end - 1]) >= 0)
            {
                rootNode.Right = new ExpTreeNode();
                rootNode.Left = new ExpTreeNode() { Val = postfix[start] };
                BuildTree(postfix, rootNode.Right, start + 1, end - 1);
            }
            else
            {
                rootNode.Right = new ExpTreeNode() { Val = postfix[end - 1] };
                rootNode.Left = new ExpTreeNode();
                BuildTree(postfix, rootNode.Left, start, end - 2);
            }
        }
    }

}