using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrcutureAlgorithm.LeetCode
{
    public class LongestPalindrome
    {
        public static string GetLongestPalindrome(string s)
        {
            int prev = 0, current = 0, temp = 0, max = 1, start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                current = i; prev = i - 1;
                if (prev >= 0 && current < s.Length && s[current] == s[prev])
                {
                    while (prev >= 0 && current < s.Length && s[current] == s[prev])
                    {
                        temp = temp + 2;
                        current++; prev--;
                    }
                    if (max < temp)
                    {
                        max = temp;
                        start = prev + 1; end = current - 1;
                    }
                    temp = 0;

                    i = current - 1;
                }
                else if (prev - 1 >= 0 && current < s.Length && s[current] == s[prev - 1])
                {
                    temp = 1;
                    while (prev - 1 >= 0 && current < s.Length && s[current] == s[prev - 1])
                    {
                        temp = temp + 2;
                        current++; prev--;
                    }
                    if (max < temp)
                    {
                        max = temp;
                        start = prev; end = current - 1;
                    }
                    temp = 0;

                    i = current - 1;
                }
            }
            return s.Substring(start, end - start + 1);
        }

        public static string bestSolution(string s)
        {
            if (s == null || s.Length < 1) return "";
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i);
                int len2 = ExpandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }
            var strlen = s.Length;
            return s.Substring(start, end - start+1) ;
        }

        private static int ExpandAroundCenter(string s, int left, int right)
        {
            int L = left, R = right;
            while (L >= 0 && R < s.Length && s[L] == s[R])
            {
                L--;
                R++;
            }
            return R - L - 1;

        }
    }
}
