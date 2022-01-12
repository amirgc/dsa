using DataStrcutureAlgorithm.Models;
using System;
using System.Collections.Generic;
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
            ty = y - 1;
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
    }
}
