using DataStrcutureAlgorithm.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.CrackingCodingInterview
{
    public class Chapter4Tree
    {
        public List<LinkedList<int>> AllSequence(TreeNode treeNode)
        {
            List<LinkedList<int>> result = new List<LinkedList<int>>();

            if (treeNode == null)
            {
                result.Add(new LinkedList<int>() { });
                return result;
            }

            LinkedList<int> prefix = new LinkedList<int>();
            prefix.AddLast(treeNode.val);

            List<LinkedList<int>> leftSeq = AllSequence(treeNode.left);
            List<LinkedList<int>> rightSeq = AllSequence(treeNode.right);

            foreach (var left in leftSeq)
            {
                foreach (var right in rightSeq)
                {
                    var weaved = new List<LinkedList<int>>();
                    weaveLists(left, right, weaved, prefix);
                    result.AddRange(weaved);
                }
            }

            return result;
        }

        private void weaveLists(LinkedList<int> first, LinkedList<int> second, List<LinkedList<int>> results, LinkedList<int> prefix)
        {

            if (first.Count == 0 || second.Count == 0)
            {
                LinkedList<int> result = new LinkedList<int>(prefix);

                foreach (var item in first)
                    result.AddLast(item);

                foreach (var item in second)
                    result.AddLast(item);

                results.Add(result);
                return;
            }

            int headFirst = first.First.Value;
            first.RemoveFirst();
            prefix.AddLast(headFirst);
            weaveLists(first, second, results, prefix);
            prefix.RemoveLast();
            first.AddLast(headFirst);

            int headsecond = second.First.Value;
            second.RemoveFirst();
            prefix.AddLast(headsecond);
            weaveLists(first, second, results, prefix);
            prefix.RemoveLast();
            second.AddFirst(headsecond);

        }

        private void printTree()
        {

        }

    }
}
