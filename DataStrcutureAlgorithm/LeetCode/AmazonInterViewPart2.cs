using DataStrcutureAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStrcutureAlgorithm.LeetCode
{
    public class AmazonInterViewPart2
    {
        private List<int> allSums = new List<int>();

        public int maxProduct(TreeNode root)
        {
            // long is a 64-bit integer.
            long totalSum = treeSum(root);
            long best = 0;
            foreach (long sum in allSums)
            {
                best = Math.Max(best, sum * (totalSum - sum));
            }
            // We have to cast back to an int to match return value.
            return (int)(best % 1000000007);

        }

        private int treeSum(TreeNode subroot)
        {
            if (subroot == null) return 0;
            int leftSum = treeSum(subroot.left);
            int rightSum = treeSum(subroot.right);
            int totalSum = leftSum + rightSum + subroot.val;
            allSums.Add(totalSum);
            return totalSum;
        }

        public int LengthOfLongestSubstring(string s)
        {
            var dict = new HashSet<char>();
            int res = 0;
            int tempHigh = 0;

            foreach (char ch in s)
            {
                if (!dict.Contains(ch))
                {
                    dict.Add(ch);
                    tempHigh++;
                }
                else
                {
                    res = Math.Max(res, tempHigh);
                    tempHigh = 0;
                }
            }

            return res;
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var res = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length && nums[i] <= 0; i++)
            {
                if (i == 0 || nums[i - 1] != nums[i])
                {
                    twoSumII(nums, i, res);
                }
            }

            return res;
        }

        private void twoSumII(int[] nums, int i, List<IList<int>> res)
        {
            int lo = i + 1, hi = nums.Length - 1;
            while (lo < hi)
            {
                int sum = nums[i] + nums[lo] + nums[hi];
                if (sum < 0) lo++;
                else if (sum > 0) hi--;
                else
                {
                    res.Add(new List<int>() { nums[i], nums[lo++], nums[hi--] });
                    while (lo < hi && nums[lo] == nums[lo - 1])
                        lo++;
                }
            }
        }
        public int Search(int[] nums, int target)
        {
            int idx = 0;
            int min = int.MaxValue;

            for (int i = 0; i < nums.Length; i++)
            {
                if (min > nums[i])
                {
                    min = nums[i];
                    idx = i;
                }
            }

            if (nums[nums.Length - 1] > target)
            {
                return RecursiveSearch(nums, idx, nums.Length - 1, target);

            }
            return RecursiveSearch(nums, 0, idx - 1, target);

        }

        public int RecursiveSearch(int[] nums, int start, int end, int target)
        {
            if (end < start)
            {
                return -1;
            }

            int mid = (start + end) / 2;

            if (nums[mid] == target)
                return mid;

            if (target > nums[mid])
            {
                return RecursiveSearch(nums, mid + 1, end, target);
            }
            else
            {
                return RecursiveSearch(nums, start, mid - 1, target);
            }

        }

        private void backtrack(int remain, List<int> comb, int start, int[] candidates, List<IList<int>> results)
        {
            if (remain == 0)
            {
                results.Add(new List<int>(comb));
                return;
            }
            else if (remain < 0)
            {
                return;
            }

            for (int i = start; i < candidates.Length; ++i)
            {
                comb.Add(candidates[i]);
                backtrack(remain - candidates[i], comb, i, candidates, results);
                comb.RemoveAt(comb.Count - 1);
            }
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var results = new List<IList<int>>();
            List<int> comb = new List<int>();
            backtrack(target, comb, 0, candidates, results);
            return results;
        }

        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            PrintMatrix(matrix);
            for (int i = 0; i < (n + 1) / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    int temp = matrix[n - 1 - j][i];
                    matrix[n - 1 - j][i] = matrix[n - 1 - i][n - j - 1];
                    matrix[n - 1 - i][n - j - 1] = matrix[j][n - 1 - i];
                    matrix[j][n - 1 - i] = matrix[i][j];
                    matrix[i][j] = temp;
                    PrintMatrix(matrix);
                }
            }

        }

        public void PrintMatrix(int[][] matrix)
        {

            int n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i][j] + " |");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public bool CanJump(int[] nums)
        {
            var dict = new HashSet<int>(0);
            return Jump(nums, 0, dict);
        }

        public bool Jump(int[] nums, int start, HashSet<int> dict)
        {
            if (start >= nums.Length - 1 || start + nums[start] >= nums.Length - 1)
                return true;

            if (!dict.Contains(start))
                dict.Add(start);

            for (int i = nums[start]; i >= 0; i--)
            {
                if (!dict.Contains(i + start))
                    if (Jump(nums, i + start, dict))
                        return true;
            }

            return false;
        }

        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> listInterval = new List<int[]>();
            int start = newInterval[0], end = newInterval[1];
            int idx = 0;
            int n = intervals.Length;

            while (idx < n && start > intervals[idx][0])
            {
                listInterval.Add(intervals[idx++]);
            }

            if (listInterval.Count == 0 || listInterval[idx - 1][1] < start)
                listInterval.Add(newInterval);
            else
            {
                var temp = listInterval[idx - 1];
                listInterval.RemoveAt(idx - 1);
                listInterval.Add(new int[] { temp[0], Math.Max(end, temp[1]) });
            }

            while (idx < n)
            {
                var interval = intervals[idx++];

                if (listInterval[listInterval.Count - 1][1] < interval[0]) listInterval.Add(interval);

                else
                {
                    var temp = listInterval[listInterval.Count - 1];
                    listInterval.RemoveAt(listInterval.Count - 1);
                    listInterval.Add(new int[] { temp[0], Math.Max(interval[1], end) });
                }
            }



            return listInterval.ToArray();
        }

        int unique_path = 0;
        public int UniquePaths(int m, int n)
        {
            var pathMap = new HashSet<string>();
            pathMap.Add("0-0");
            GotoNextPoint(0, 0, m, n, pathMap);
            return unique_path;
        }

        private void GotoNextPoint(int x, int y, int m, int n, HashSet<string> map)
        {
            if (x == m - 1 && y == n - 1)
            {
                unique_path += 1;
                return;
            }

            var nextPaths = GetNextPaths(x, y, m, n, map);

            foreach (var cor in nextPaths)
            {
                map.Add($"{cor.Item1}-{cor.Item2}");
                var mapForNext = new HashSet<string>(map);
                GotoNextPoint(cor.Item1, cor.Item2, m, n, mapForNext);
            }
        }

        private List<Tuple<int, int>> GetNextPaths(int x, int y, int m, int n, HashSet<string> map)
        {
            int tx, ty;
            var res = new List<Tuple<int, int>>();

            //right
            tx = x + 1;
            ty = y;
            if (IsValidCordinate(tx, ty, m, n, map))
                res.Add(new Tuple<int, int>(tx, ty));

            //bottom
            tx = x;
            ty = y + 1;
            if (IsValidCordinate(tx, ty, m, n, map))
                res.Add(new Tuple<int, int>(tx, ty));

            return res;
        }

        private bool IsValidCordinate(int x, int y, int m, int n, HashSet<string> map)
        {
            if (map.Contains($"{x}-{y}"))
                return false;

            if (x < 0 || y < 0 || y > n - 1 || x > m - 1)
                return false;

            return true;
        }

        public int uniquePaths1(int m, int n)
        {
            int[][] d = new int[m][];

            for (int i = 0; i < m; i++)
            {
                d[i] = new int[n];
                Array.Fill(d[i], 1);
            }
            for (int col = 1; col < m; ++col)
            {
                for (int row = 1; row < n; ++row)
                {
                    d[col][row] = d[col - 1][row] + d[col][row - 1];
                }
            }
            return d[m - 1][n - 1];
        }

        public void SetZeroes(int[][] matrix)
        {
            var rows = new HashSet<int>();
            var cols = new HashSet<int>();
            string a = "amamd";
            a = a.Substring(0, a.Length - 1);
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                if (rows.Contains(i))
                {
                    matrix[i] = new int[matrix[i].Length];
                }
                else
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        if (cols.Contains(j))
                        {
                            matrix[i][j] = 0;
                        }
                    }
                }
            }
        }

        string substring = "";
        HashSet<string> subset;
        public string MinWindow(string s, string t)
        {
            subset = new HashSet<string>();
            GetSubstring(s, t);
            return substring;
        }

        public void GetSubstring(string s, string t)
        {
            if (s.Length < t.Length)
                return;

            if (ContainsWord(s, t))
            {
                if (substring.Length > s.Length || substring.Length == 0)
                {
                    substring = s;
                }
            }

            subset.Add(s);
            if (!subset.Contains(s.Substring(1)))
                GetSubstring(s.Substring(1), t);

            if (!subset.Contains(s.Substring(0, s.Length - 1)))
                GetSubstring(s.Substring(0, s.Length - 1), t);
        }

        public bool ContainsWord(string s, string t)
        {
            var sn = convertWordToInt(s);
            var tn = convertWordToInt(t);
            for (int i = 0; i < 26; i++)
            {
                if (tn[i] > 0 && sn[i] < tn[i])
                    return false;
            }

            return true;
        }

        private int[] convertWordToInt(string s)
        {
            var res = new int[26];
            s = s.ToLower();
            foreach (char ch in s)
            {
                res[ch - 'a'] += 1;
            }
            return res;
        }

        public string minWindow(string s, string t)
        {

            if (s.Length == 0 || t.Length == 0)
            {
                return "";
            }

            // Dictionary which keeps a count of all the unique characters in t.
            Dictionary<char, int> dictT = new Dictionary<char, int>();
            for (int i = 0; i < t.Length; i++)
            {
                if (!dictT.ContainsKey(t[i]))
                {
                    dictT.Add(t[i], 0);
                }
                dictT[t[i]] += 1;
            }

            // Number of unique characters in t, which need to be present in the desired window.
            int required = dictT.Count;

            // Left and Right pointer
            int l = 0, r = 0;

            // formed is used to keep track of how many unique characters in t
            // are present in the current window in its desired frequency.
            // e.g. if t is "AABC" then the window must have two A's, one B and one C.
            // Thus formed would be = 3 when all these conditions are met.
            int formed = 0;

            // Dictionary which keeps a count of all the unique characters in the current window.
            Dictionary<char, int> windowCounts = new Dictionary<char, int>();

            // ans list of the form (window length, left, right)
            int[] ans = { -1, 0, 0 };

            while (r < s.Length)
            {
                // Add one character from the right to the window
                char c = s[r];

                if (!windowCounts.ContainsKey(c))
                {
                    windowCounts.Add(c, 0);
                }
                windowCounts[c] += 1;

                // If the frequency of the current character added equals to the
                // desired count in t then increment the formed count by 1.
                if (dictT.ContainsKey(c) && windowCounts[c] == dictT[c])
                {
                    formed++;
                }

                // Try and contract the window till the point where it ceases to be 'desirable'.
                while (l <= r && formed == required)
                {
                    c = s[l];
                    // Save the smallest window until now.
                    if (ans[0] == -1 || r - l + 1 < ans[0])
                    {
                        ans[0] = r - l + 1;
                        ans[1] = l;
                        ans[2] = r;
                    }

                    // The character at the position pointed by the
                    // `Left` pointer is no longer a part of the window.
                    //windowCounts.Add(c, windowCounts[c] - 1);
                    windowCounts[c] -= 1;
                    if (dictT.ContainsKey(c) && windowCounts[c] < dictT[c])
                    {
                        formed--;
                    }

                    // Move the left pointer ahead, this would help to look for a new window.
                    l++;
                }

                // Keep expanding the window once we are done contracting.
                r++;
            }

            return ans[0] == -1 ? "" : s.Substring(ans[1], s.Length - ans[1]);
        }

        Dictionary<int, int> memo = new Dictionary<int, int>();

        public int numDecodings(String s)
        {
            return recursiveWithMemo(0, s);
        }

        private int recursiveWithMemo(int index, String str)
        {
            // Have we already seen this substring?
            if (memo.ContainsKey(index))
            {
                return memo[index];
            }

            // If you reach the end of the string
            // Return 1 for success.
            if (index == str.Length)
            {
                return 1;
            }
            // If the string starts with a zero, it can't be decoded
            if (str[index] == '0')
            {
                return 0;
            }

            if (index == str.Length - 1)
            {
                return 1;
            }
            //Char.IsLetterOrDigit('8')

            int ans = recursiveWithMemo(index + 1, str);

            if (int.Parse(str.Substring(index, 2)) <= 26)
            {
                ans += recursiveWithMemo(index + 2, str);
            }

            // Save for memoization
            memo.Add(index, ans);

            return ans;
        }
        public int LongestConsecutive(int[] nums)
        {

            var num_set = new HashSet<int>();
            foreach (int num in nums)
            {
                num_set.Add(num);
            }

            int longestSteak = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int tempLongestSteak = 0;
                int num = nums[i];

                while (num_set.Contains(num))
                {
                    tempLongestSteak += 1;
                    num_set.Remove(num);
                    num += 1;
                }

                num = nums[i] - 1;
                while (num_set.Contains(num))
                {
                    tempLongestSteak += 1;
                    num_set.Remove(num);
                    num -= 1;
                }
                longestSteak = Math.Max(tempLongestSteak, longestSteak);
            }

            return longestSteak;
        }
        Dictionary<char, List<string>> collection = new Dictionary<char, List<string>>();
        public bool WordBreak(string s, IList<string> wordDict)
        {
            foreach (var str in wordDict)
            {
                if (!collection.ContainsKey(str[0]))
                {
                    collection.Add(str[0], new List<string>());
                }

                collection[str[0]].Add(str);
            }
            return startWorkSearch(s);
        }

        private bool startWorkSearch(string str)
        {
            if (string.IsNullOrEmpty(str))
                return true;

            if (!collection.ContainsKey(str[0]))
                return false;

            var list = collection[str[0]].OrderByDescending(x => x);

            foreach (string s in list)
            {
                if (str.Length >= s.Length && str.Substring(0, s.Length) == s)
                {
                    if (startWorkSearch(str.Substring(s.Length)))
                    {
                        return true;
                    }
                }
            }
            Dictionary<char, string> map = new Dictionary<char, string>();
            map.Add('2', "abc");
            map.Add('3', "def");
            map.Add('4', "ghi");
            map.Add('5', "jkl");
            map.Add('6', "mno");
            map.Add('7', "pqrs");
            map.Add('8', "tuv");
            map.Add('9', "wxyz");
            return false;
        }
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var mergedArray = MergeArray(nums1, nums2);
            int medVal = mergedArray.Length / 2;
            double median;
            if (mergedArray.Length % 2 == 0)
            {
                var med = mergedArray[medVal - 1] + mergedArray[medVal];
                median = med / 2.00;
            }
            else
            {
                median = mergedArray[medVal];
            }
            Random random_num = new Random();
            int pivot_index = 1 + random_num.Next(1 - 1);

            return median;
        }

        public int[] MergeArray(int[] nums1, int[] nums2)
        {
            var res = new int[nums1.Length + nums2.Length];

            int p1 = 0; int p2 = 0; int p3 = 0;

            while (p1 < nums1.Length && p2 < nums2.Length)
            {
                if (nums1[p1] > nums2[p2])
                {
                    res[p3++] = nums2[p2++];
                }
                else
                {
                    res[p3++] = nums1[p1++];
                }
            }

            while (p1 < nums1.Length)
                res[p3++] = nums1[p1++];

            while (p2 < nums2.Length)
                res[p3++] = nums2[p2++];

            return res;
        }

    }


}
