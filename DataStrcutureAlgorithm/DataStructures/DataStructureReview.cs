using DataStrcutureAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.DataStructures
{
    //   *
    //* Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
        public ListNode(int x = 0, ListNode n = null)
        {
            val = x;
            next = n;
        }
    }

    public class DataStructureReview
    {

        public bool SearchMatrix(int[][] matrix, int target)
        {
            int r = matrix.Length;
            int c = matrix[0].Length;
            int len = r * c;

            int startIndex = 0;
            int endIndex = len - 1;

            while (startIndex <= endIndex)
            {
                int currIndex = (startIndex + endIndex) / 2;
                int val = matrix[currIndex / r][currIndex / c];

                if (val == target)
                {
                    return true;
                }

                if (target < val)
                {
                    endIndex = currIndex - 1;

                }
                else
                {
                    startIndex = currIndex + 1;
                }

            }

            return false;
        }

        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]] += 1;
                }
                else
                {
                    dict.Add(s[i], 1);
                }
            }

            foreach (KeyValuePair<char, int> item in dict)
            {
                if (item.Value == 1)
                    return s.IndexOf(item.Key);
            }

            return -1;
        }

        public bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < magazine.Length; i++)
            {
                if (dict.ContainsKey(magazine[i]))
                {
                    dict[magazine[i]] += 1;
                }
                else
                {
                    dict.Add(magazine[i], 1);
                }
            }

            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (dict.ContainsKey(ransomNote[i]) && dict[ransomNote[i]] > 0)
                {
                    dict[ransomNote[i]] -= 1;
                }
                else
                {
                    return false;
                }
            }


            return true;
        }

        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]] += 1;
                }
                else
                {
                    dict.Add(s[i], 1);
                }
            }

            for (int i = 0; i < t.Length; i++)
            {
                if (dict.ContainsKey(t[i]) && dict[t[i]] > 0)
                {
                    dict[t[i]] -= 1;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool HasCycle(ListNode head)
        {
            var h = new HashSet<ListNode>();

            do
            {
                if (h.Contains(head))
                    return true;

                h.Add(head);

                if (head != null)
                    head = head.next;

            } while (head != null);

            return false;
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode res = null;
            ListNode tail = null;
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            if (l1.val < l2.val)
            {
                var newNode = new ListNode(l1.val); ;
                res = newNode;
                tail = newNode;
                l1 = l1.next;
            }
            else
            {
                var newNode = new ListNode(l2.val);
                res = newNode;
                tail = newNode;
                l2 = l2.next;
            }

            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    var newNode = new ListNode(l1.val);

                    tail.next = newNode;
                    tail = newNode;
                    l1 = l1.next;
                }
                else
                {
                    var newNode = new ListNode(l2.val);
                    tail.next = newNode;
                    tail = newNode;
                    l2 = l2.next;
                }

            }

            if (l1 == null)
                tail.next = l2;
            else if (l2 == null)
                tail.next = l1;

            return res;
        }

        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null)
                return null;

            if (head.val == val)
            {
                return RemoveElements(head.next, val);
            }

            head.next = RemoveElements(head.next, val);

            return head;
        }

        public ListNode ReverseList(ListNode head)
        {
            Stack<int> listNodesStack = new Stack<int>();

            while (head != null)
            {
                listNodesStack.Push(head.val);
                head = head.next;
            }

            var newhead = AddNewNode(new ListNode(), listNodesStack);

            return newhead;
        }

        public ListNode AddNewNode(ListNode listNode, Stack<int> listNodesStack)
        {
            if (listNodesStack.Count == 0)
                return null;

            listNode.next = new ListNode(listNodesStack.Pop(), null);
            listNode = listNode.next;

            listNode.next = AddNewNode(listNode, listNodesStack);

            return listNode;
        }

        public ListNode DeleteDuplicates(ListNode head)
        {
            return DeleteDuplicates(head, new HashSet<int>());
        }

        private ListNode DeleteDuplicates(ListNode head, HashSet<int> hashSet)
        {
            if (head == null)
                return null;

            if (hashSet.Contains(head.val))
            {
                DeleteDuplicates(head.next, hashSet);
            }

            hashSet.Add(head.val);

            head.next = DeleteDuplicates(head.next, hashSet);

            return head;
        }

        public bool IsValid(string s)
        {
            Stack<char> vs = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {

                switch (s[i])
                {
                    case '(':
                    case '[':
                    case '{':
                        vs.Push(s[i]);
                        break;
                    case ')':
                        if (vs.Peek() != '(')
                            return false;
                        vs.Pop();
                        break;
                    case ']':
                        if (vs.Peek() != '[')
                            return false;
                        vs.Pop();
                        break;
                    case '}':
                        if (vs.Peek() != '{')
                            return false;
                        vs.Pop();
                        break;
                    default:
                        break;
                }
            }

            return vs.Count == 0;
        }

        public IList<int> PreorderTraversal(TreeNode root)
        {
            var res = PreorderTraversal(root, new List<int>());

            if (res == null)
            {
                return new List<int>();
            }

            return res;
        }

        private IList<int> PreorderTraversal(TreeNode root, IList<int> res)
        {
            if (root == null)
                return null;

            res.Add(root.val);
            PreorderTraversal(root.left, res);
            PreorderTraversal(root.right, res);

            return res;
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var dict = new Dictionary<int, List<int>>();
            var recurseValue = TraverseLevelOrder(root, dict, 0);
            var res = new List<IList<int>>();

            foreach (var val in recurseValue)
            {
                res.Add(val.Value);
            }

            return res;
        }

        private Dictionary<int, List<int>> TraverseLevelOrder(TreeNode root, Dictionary<int, List<int>> dict, int level)
        {
            if (root == null)
                return dict;

            if (dict.ContainsKey(level))
            {
                dict[level].Add(root.val);
            }
            else
            {
                dict.Add(level, new List<int>() { root.val });
            }
            TraverseLevelOrder(root.left, dict, level + 1);
            TraverseLevelOrder(root.right, dict, level + 1);

            return dict;
        }

        public int MaxDepth(TreeNode root)
        {
            return TraverseMaxDephth(root, 0);
        }

        private int TraverseMaxDephth(TreeNode root, int current_depth)
        {
            if (root == null)
                return current_depth;

            int leftMaxDept = TraverseMaxDephth(root.left, current_depth + 1);
            int rightMaxDepth = TraverseMaxDephth(root.right, current_depth + 1);

            return leftMaxDept > rightMaxDepth ? leftMaxDept : rightMaxDepth;
        }

        public bool IsSymmetric(TreeNode root)
        {
            return isMirror(root, root);
        }
        public Boolean isMirror(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null) return true;
            if (t1 == null || t2 == null) return false;
            return (t1.val == t2.val)
                && isMirror(t1.right, t2.left)
                && isMirror(t1.left, t2.right);
        }

        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;

            ReverseNode(root, root.left, root.right);
            return root;
        }

        private void ReverseNode(TreeNode h1, TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
                return;

            h1.left = t2;
            h1.right = t1;

            ReverseNode(t1, t1?.left, t1?.right);
            ReverseNode(t2, t2?.left, t2?.left);

        }

        public bool HasPathSum(TreeNode root, int targetSum)
        {
            return hasPathSum(root, targetSum, 0);
        }

        private bool hasPathSum(TreeNode root, int target, int currentSum)
        {
            if (root == null)
            {
                if (target != currentSum)
                    return false;
                else
                    return true;
            }

            currentSum = currentSum + root.val;

            if (root.left == null && root.right != null)
            {
                return hasPathSum(root.right, target, currentSum);
            }
            else if (root.left != null && root.right == null)
            {
                return hasPathSum(root.left, target, currentSum);
            }
            else
            {
                return hasPathSum(root.left, target, currentSum) || hasPathSum(root.right, target, currentSum);
            }
        }

        public TreeNode SearchBST(TreeNode root, int val)
        {
            while (root != null)
            {
                if (root.val == val)
                    return root;

                if (val < root.val)
                    root = root.left;
                else
                    root = root.right;
            }

            return null;
        }

        public int search(int[] nums, int target)
        {
            int pivot, left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                pivot = left + (right - left) / 2;
                if (nums[pivot] == target) return pivot;
                if (target < nums[pivot]) right = pivot - 1;
                else left = pivot + 1;
            }
            return -1;
        }

        public int Tribonacci(int n)
        {

            if (n == 0)
                return 0;

            if (n == 1 || n == 2)
                return 1;

            int t0 = 0;
            int t1 = 1;
            int t2 = 1;
            int res = 0;
            int counter = 3;
            //T0 = 0, T1 = 1, T2 = 1, and Tn+3 = Tn + Tn + 1 + Tn + 2 for n >= 0.

            while (counter <= n)
            {
                res = t0 + t1 + t2;
                t0 = t1;
                t1 = t2;
                t2 = res;
                counter++;
            }
            return res;
        }

        public int[][] Merge(int[][] intervals)
        {


            Array.Sort(intervals, (a, b) => Comparer<int>.Default.Compare(a[0], b[0]));

            LinkedList<int[]> merged = new LinkedList<int[]>();

            foreach (int[] interval in intervals)
            {
                // if the list of merged intervals is empty or if the current
                // interval does not overlap with the previous, simply append it.
                if (merged.Count == 0 || merged.Last.Value[1] < interval[0])
                {
                    merged.AddLast(interval);
                }
                // otherwise, there is overlap, so we merge the current and previous
                // intervals.
                else
                {
                    merged.Last.Value[1] = Math.Max(merged.Last.Value[1], interval[1]);
                }
            }
            var res = new int[merged.Count][];
            int counter = 0;
            while (merged.Count != 0)
            {
                res[counter] = merged.Last.Value;
                merged.RemoveLast();
                counter++;
            }

            return res;
        }
        public int ClimbStairs(int n)
        {
            if (n == 1) return 1;

            int[] fib = new int[n];
            fib[0] = 0;
            fib[1] = 1;
            fib[2] = 2;

            for (int i = 3; i <= n; i++)
            {

                fib[i] = fib[i - 1] + fib[i - 2];
            }

            return fib[n];

        }
       
    }
}
