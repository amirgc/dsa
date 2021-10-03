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
    }

    public class DataStructureReview
    {

        public bool SearchMatrix(int[][] matrix, int target)
        {
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
   
    }
}
