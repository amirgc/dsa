using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.DataStructures
{
    public class AVLTreeNode
    {
        public int Val { get; set; }
        public int Height { get; set; }
        public AVLTreeNode Left { get; set; }
        public AVLTreeNode Right { get; set; }
    }

    public class AVLTree
    {
        public AVLTreeNode InsertAVL(int[] items, int threshHold)
        {
            if (items == null || items.Length == 0)
                return null;

            AVLTreeNode root = new AVLTreeNode() { Val = items[0] };

            for (int idx = 1; idx < items.Length; idx++)
            {
                root = Insert(root, items[idx], threshHold);
            }

            return root;
        }

        private AVLTreeNode Insert(AVLTreeNode node, int key, int threshold)
        {
            if (node == null)
                return new AVLTreeNode() { Val = key };

            if (key < node.Val)
            {
                node.Left = Insert(node.Left, key, threshold);
            }
            else
            {
                node.Right = Insert(node.Right, key, threshold);
            }

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
            int balance = GetBalance(node);

            if (balance > threshold)
            {
                if (GetBalance(node.Left) > 0)
                {
                    node = RotateRight(node);
                }
                else
                {
                    node = RotateLeft(node);
                }
            }
            else if (balance < -threshold)
            {
                if (GetBalance(node.Right) <= 0)
                {
                    node = RotateLeft(node);
                }
                else
                {
                    node = RotateRightLeft(node);
                }
            }
            return node;
        }

        private AVLTreeNode RotateRightLeft(AVLTreeNode node)
        {
            throw new NotImplementedException();
        }

        private AVLTreeNode RotateLeft(AVLTreeNode node)
        {
            throw new NotImplementedException();
        }

        private AVLTreeNode RotateRight(AVLTreeNode node)
        {
            throw new NotImplementedException();
        }

        private int GetHeight(AVLTreeNode node)
        {
            if (node == null) return -1;

            return node.Height;
        }

        private int GetBalance(AVLTreeNode node)
        {
            if (node == null) return 0;

            return GetHeight(node.Left) - GetHeight(node.Right);
        }
    }


}
