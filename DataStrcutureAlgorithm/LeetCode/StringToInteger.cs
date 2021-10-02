using System;
using System.Collections.Generic;

namespace DataStrcutureAlgorithm.LeetCode
{
    public static class StringToInteger
    {
        public static int MyAtoi(string str)
        {
            Dictionary<int, bool> dict = new Dictionary<int, bool>();
            dict.Add(1, true);

            bool val = dict.ContainsKey(1);
            int[] nums = { 1, 2, 3 };


            if (str == null || str == "") return 0;

            int minusFound = 0;
            int plusFound = 0;
            int res = 0;
            string r = "";

            for (int i = 0; i < str.Length; i++)
            {

                if (str[i] == '-') minusFound++;
                else if (str[i] == '+') plusFound++;
                else if (r.Length > 0 && str[i] == ' ') break;
                else if ((str[i] == '+' || str[i] == '-') && r.Length > 0) break;
                else if (str[i] == '+' || str[i] == ' ') continue;
                else if (minusFound > 1 || plusFound > 1 || (minusFound >= 1 && plusFound >= 1)) return 0;
                else if (str[i] >= '0' && str[i] <= '9') r += str[i];
                else if (r.Length == 0) return 0;
                else break;
            }

            try
            {
                if (r.Length > 0)
                    res = Convert.ToInt32(r);
                else
                    return 0;
            }
            catch
            {
                if (minusFound >= 1)
                    res = (int)(-1 * Math.Pow(2, 32));
                else
                    res = (int)Math.Pow(2, 31);
                return res;
            }

            if (minusFound >= 1) res = -1 * res;

            return res;
        }

        public static int MaxSubArray(int[] nums)
        {
            int maxValue = 0;
            int minIndexVal = 0;
            int maxIndexVal = nums.Length - 1;

            for (int i = minIndexVal; i <= maxIndexVal; i++)
            {
                for (int j = i; i <= maxIndexVal; j++)
                {
                    int sum = SumOfArray(nums, i, j);
                    if (sum > maxValue)
                    {
                        maxValue = sum;
                    }
                }
            }

            return 0;

        }

        public static int MaxProfit(int[] prices)
        {
            int finalMinBP = 0; int maximumSP = 1; int minBP = maximumSP; int maxSP = 2;

            if (prices.Length == 1) return 0;

            int maxProfit = prices[maximumSP] - prices[finalMinBP];
            bool isMinChanged = false;

            while (minBP < prices.Length - 1 && maxSP < prices.Length)
            {
                int currentMax = prices[maxSP] - prices[finalMinBP];
                if (isMinChanged)
                {
                    currentMax = prices[maxSP - 1] - prices[finalMinBP];
                    isMinChanged = false;
                    maxSP--;
                }

                if (currentMax > maxProfit)
                {
                    maxProfit = currentMax;
                }

                maxSP++;

                if ((prices[minBP] < prices[finalMinBP]) && !isMinChanged)
                {
                    finalMinBP = minBP;
                    isMinChanged = true;
                }

                if (!isMinChanged)
                {
                    minBP++;
                }

            }
            int finalTest = prices[maxSP - 1] - prices[finalMinBP];

            if (finalTest > maxProfit && finalTest > 0)
                return finalTest;

            if (maxProfit > 0) return maxProfit;

            else return 0;
        }

        public static int SumOfArray(int[] nums, int i, int j)
        {
            int totalSum = 0;
            for (int a = i; a <= j; a++)
            {
                totalSum += nums[a];
            }

            return totalSum;
        }
        public static IList<IList<int>> Generate(int numRows)
        {
            List<IList<int>> res = new List<IList<int>>();
            int current_row = 2;
            if (numRows == 0) return res;
            res.Add(new List<int>() { 1 });
            if (numRows == 1) return res;
            res.Add(new List<int>() { 1, 1 });
            if (numRows == 2) return res;

            while (current_row <= numRows)
            {
                current_row++;
            }

            return res;
        }

        public static int[][] Generatet(int numRows)
        {
            int[][] res = new int[numRows][];
            int current_row = 2;

            if (numRows == 0) return res;
            res[0] = new int[] { 1 };

            if (numRows == 1) return res;
            res[1] = new int[] { 1, 1 };

            if (numRows == 2) return res;

            while (current_row < numRows)
            {
                int current_column = 0;
                int last_row = current_row - 1;
                int cloumn_num = current_row + 1;
                res[current_row] = new int[cloumn_num];

                bool isEvenColumn = cloumn_num % 2 == 0 ? true : false;

                while (
                        (isEvenColumn && current_column < cloumn_num / 2) ||
                        (!isEvenColumn && current_column < (cloumn_num / 2) + 1)
                       )
                {
                    if (current_column == 0)
                    {
                        res[current_row][current_column] = 1;
                        res[current_row][current_row - current_column] = 1;
                    }
                    else
                    {
                        int new_val = res[last_row][current_column - 1] + res[last_row][current_column];
                        res[current_row][current_column] = new_val;

                        if (!isEvenColumn && current_column < cloumn_num / 2)
                            res[current_row][current_row - current_column] = new_val;
                        else if (isEvenColumn)
                            res[current_row][current_row - current_column] = new_val;
                    }

                    current_column++;
                }
                current_row++;
            }

            return res;
        }

        public static bool IsValidSudoku(char[][] board)
        {
            Dictionary<char, char> dict = new Dictionary<char, char>();

            for (int counter = 0; counter < 81; counter++)
            {
                int currRow = counter / 9;
                var val = board[currRow][counter % 9];
                if (IsInvalidValue(val, dict)) return false;

                if (val >= '1' && val <= '9') dict.Add(val, val);

                if ((counter + 1) / 9 != currRow) dict = new Dictionary<char, char>();
            }

            for (int counter = 0; counter < 81; counter++)
            {
                int currCol = counter / 9;
                var val = board[counter % 9][currCol];

                if (IsInvalidValue(val, dict)) return false;

                if (val >= '1' && val <= '9') dict.Add(val, val);

                if ((counter + 1) / 9 != currCol) dict = new Dictionary<char, char>();
            }

            for (int i = 0; i < 9;)
            {
                for (int j = 0; j < 9;)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        var val = board[i + (k / 3)][j + (k % 3)];
                       
                        if (IsInvalidValue(val, dict))
                        {
                            return false;
                        }

                        if (val >= '1' && val <= '9') dict.Add(val, val);
                    }

                    dict = new Dictionary<char, char>();

                    j += 3;
                }
                i += 3;
            }

            return true;
        }

        private static bool IsInvalidValue(char val, Dictionary<char, char> dict)
        {
            return !((val >= '1' && val <= '9') || val == '.') || dict.ContainsKey(val);
        }
    }
}
