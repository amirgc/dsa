using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace DataStrcutureAlgorithm.LeetCode
{
    public class AmazonInterviewPart4
    {

        public class CustomComaprer : IComparer<string>
        {
            private string RemoveSpecialCharacters(string str)
            {
                StringBuilder sb = new StringBuilder();
                foreach (char c in str)
                {
                    if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                    {
                        sb.Append(c);
                    }
                }
                return sb.ToString();
            }
            public int Compare(string x, string y)
            {
                x = RemoveSpecialCharacters(x);
                y = RemoveSpecialCharacters(y);
                return x.CompareTo(y);
            }
        }

        HashSet<string> visited = new HashSet<string>();
        Dictionary<string, List<string>> adjacent = new Dictionary<string, List<string>>();

        private void DFS(List<string> mergedAccount, string email)
        {
            visited.Add(email);
            // Add the email vector that contains the current component's emails
            mergedAccount.Add(email);

            if (!adjacent.ContainsKey(email))
            {
                return;
            }

            foreach (string neighbor in adjacent[email])
            {
                if (!visited.Contains(neighbor))
                {
                    DFS(mergedAccount, neighbor);
                }
            }
        }

        public IList<IList<string>> AccountsMerge(IList<IList<string>> accountList)
        {
            int accountListSize = accountList.Count;

            foreach (List<string> account in accountList)
            {
                int accountSize = account.Count;

                // Building adjacency list
                // Adding edge between first email to all other emails in the account
                string accountFirstEmail = account[1];

                for (int j = 2; j < accountSize; j++)
                {
                    string accountEmail = account[j];

                    if (!adjacent.ContainsKey(accountFirstEmail))
                    {
                        adjacent.Add(accountFirstEmail, new List<string>());
                    }
                    adjacent[accountFirstEmail].Add(accountEmail);

                    if (!adjacent.ContainsKey(accountEmail))
                    {
                        adjacent.Add(accountEmail, new List<string>());
                    }
                    adjacent[accountEmail].Add(accountFirstEmail);
                }
            }

            // Traverse over all th accounts to store components
            List<IList<string>> mergedAccounts = new List<IList<string>>();

            foreach (List<string> account in accountList)
            {
                string accountName = account[0];
                string accountFirstEmail = account[1];

                // If email is visited, then it's a part of different component
                // Hence perform DFS only if email is not visited yet
                if (!visited.Contains(accountFirstEmail))
                {
                    List<string> mergedAccount = new List<string>();
                    // Adding account name at the 0th index
                    mergedAccount.Add(accountName);

                    DFS(mergedAccount, accountFirstEmail);

                    mergedAccount.Sort(1, mergedAccount.Count - 1, new CustomComaprer());

                    mergedAccounts.Add(mergedAccount);
                }
            }

            return mergedAccounts;
        }
        public int LongestSubstring(String s, int k)
        {
            return longestSubstringUtil(s, 0, s.Length, k);
        }

        int longestSubstringUtil(String s, int start, int end, int k)
        {
            if (end < k) return 0;
            int[] countMap = new int[26];
            // update the countMap with the count of each character
            for (int i = start; i < end; i++)
                countMap[s[i] - 'a']++;
            for (int mid = start; mid < end; mid++)
            {
                if (countMap[s[mid] - 'a'] >= k) continue;
                int midNext = mid + 1;
                while (midNext < end && countMap[s[midNext] - 'a'] < k) midNext++;
                return Math.Max(longestSubstringUtil(s, start, mid, k),
                        longestSubstringUtil(s, midNext, end, k));
            }
            return (end - start);
        }

        Dictionary<string, int> memo = new Dictionary<string, int>();
        private int[][] costs;
        public int MinCost(int[][] costs)
        {

            int res = int.MaxValue;
            this.costs = costs;
            for (int i = 0; i < 3; i++)
            {
                res = Math.Min(PaintHouse(0, i), res);
            }

            return res;
        }

        private int PaintHouse(int n, int color)
        {
            if (memo.ContainsKey($"{n}-{color}"))
                return memo[$"{n}-{color}"];

            int totalCost = costs[n][color];
            if (n == costs.Length - 1)
            {
            }
            else if (color == 0)
            { // Red
                totalCost += Math.Min(PaintHouse(n + 1, 1), PaintHouse(n + 1, 2));
            }
            else if (color == 1)
            { // Green
                totalCost += Math.Min(PaintHouse(n + 1, 0), PaintHouse(n + 1, 2));
            }
            else
            { // Blue
                totalCost += Math.Min(PaintHouse(n + 1, 0), PaintHouse(n + 1, 1));
            }

            memo.Add($"{n}-{color}", totalCost);
            return totalCost;
        }

        public long MaxPoints(int[][] points)
        {
            var long_res = new long[points.Length][];

            for (int i = 0; i < points.Length; i++)
            {
                long_res[i] = new long[points[i].Length];
                for (int j = 0; j < points[i].Length; j++)
                {
                    long_res[i][j] = points[i][j];
                }
            }

            for (int i = long_res.Length - 2; i >= 0; i--)
            {
                for (int j = 0; j < long_res[i].Length; j++)
                {
                    long max_val = long.MinValue;
                    for (int k = 0; k < long_res[i].Length; k++)
                    {
                        max_val = Math.Max(long_res[i][j] + long_res[i + 1][k] - Math.Abs(k - j), max_val);
                    }

                    long_res[i][j] = (int)max_val;
                }
            }

            long res = long.MinValue;

            for (int j = 0; j < long_res[0].Length; j++)
            {
                res = Math.Max(long_res[0][j], res);
            }

            return res;
        }

        public int[] MeetingPlanner(int[,] slotsA, int[,] slotsB, int dur)
        {
            // your code goes here
            int ptr1 = 0;
            int ptr2 = 0;
            int[] result = new int[2];
            while (ptr1 < slotsA.GetLength(0) && ptr2 < slotsB.GetLength(0))
            {
                int start = Math.Max(slotsA[ptr1, 0], slotsB[ptr2, 0]);
                int end = Math.Min(slotsA[ptr1, 1], slotsB[ptr2, 1]);

                if (start + dur <= end)
                {
                    result[0] = start;
                    result[1] = start + dur;
                    return result;
                }

                if (slotsA[ptr1, 1] < slotsB[ptr2, 1]) ptr1++;
                else ptr2++;
            }
            return result;
        }

        public List<int> reassignedShelves(List<int> shelves)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            var orginal_shelves = new List<int>(shelves);
            shelves.Sort();

            int counter = 1;

            foreach (int item in shelves)
            {
                if (!map.ContainsKey(item))
                {
                    map.Add(item, counter++);
                }
            }

            var result = new List<int>();

            foreach (int item in orginal_shelves)
            {
                result.Add(map[item]);
            }

            return result;
        }

        public static List<string> areSimilarOrders(List<string> x, List<string> y)
        {
            var result = new List<string>();

            for (int i = 0; i < x.Count; i++)
            {
                if (IsOrderSame(x[i], y[i])) result.Add("YES");
                else result.Add("NO");
            }

            return result;
        }

        private static bool IsOrderSame(string order1, string order2)
        {

            return true;
        }

        public static List<string> processEvents(List<string> logs, int maximumTime)
        {
            var result = new List<string>();
            HashSet<int> h = new HashSet<int>();

            foreach (var log in logs)
            {
                string[] row = log.Split(' ');
                int a = int.Parse(row[1]);

            }
            return result;
        }

        int[] parent;
        public int CountComponents(int n, int[][] edges)
        {
            parent = new int[n];
            HashSet<int> set = new HashSet<int>();

            for (int i = 0; i < n; i++) parent[i] = i;

            for (int i = 0; i < edges.Length; i++) Union(edges[i][0], edges[i][1]);

            int totalCount = 0;
            bool[] map = new bool[n];
            int counter = 0;
            while (counter < n)
            {
                int a = parent[counter];
                if (!map[counter])
                {
                    map[a] = true;
                    while (a != parent[a])
                    {
                        a = parent[a];
                        map[a] = true;
                    }

                    totalCount++;
                }
                counter++;
            }

            return totalCount;
        }

        private bool Union(int a, int b)
        {
            int p1 = find(a);
            int p2 = find(b);

            if (p1 == p2) return false;

            parent[b] = p1;

            return true;
        }

        private int find(int a)
        {
            while (a != parent[a])
            {
                a = parent[a];
            }

            return a;
        }

        public class HastSetComparer : IEqualityComparer<Student>
        {

            public bool Equals([AllowNull] Student x, [AllowNull] Student y)
            {
                return x.Id == y.Id;

            }

            public int GetHashCode([DisallowNull] Student obj)
            {
                return base.GetHashCode();
            }
        }

        public void tip()
        {
            char.IsLetter('2');
            char.IsDigit('r');
            int a = 'c';
            var str = a.ToString();
            string st = "amir";
            char[] ch = st.ToCharArray();
            st.Substring(0);
            int[] chInt = new int[ch.Length];
            for (int i = 0; i < ch.Length; i++)
            {
                chInt[i] = ch[i];
            }
            if (string.IsNullOrEmpty(st))
            {

            }
            st.CompareTo(st);
            var test = new int[3][] { new int[] { 4, 2 }, new int[] { 1, 2 }, new int[] { 3, 2 } };

            Array.Sort(test, (a, b) => a[0] - b[0]);
            var t = test;
            List<string> data_list = new List<string>();
            //  data_list.RemoveAt(0);
            data_list.Count();
            HashSet<Student> set = new HashSet<Student>(new HastSetComparer());

            set.Add(new Student() { Id = 1, Name = "amir" });
            set.Add(new Student() { Id = 2, Name = "amir" });

            set.Add(new Student() { Id = 2, Name = "amir" });
            int jj = set.Count;

            Queue<int> queuq = new Queue<int>();
            queuq.Enqueue(12);
            queuq.Dequeue();
            queuq.Peek();
            queuq.Count();
        }

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public string MinWindow(string s, string t)
        {
            if (s.Length == 0 || t.Length == 0) return "";
            Dictionary<int, int> abc = new Dictionary<int, int>();

            HashSet<char> set = new HashSet<char>();
            foreach (char ch in t) set.Add(ch);

            // Left and Right pointer
            int l = 0, r = 0;
            int[] ans = new int[2] { -1, int.MaxValue };

            while (l < s.Length)
            {
                var temp_set = new HashSet<char>(set);
                r = l;

                while (temp_set.Count > 0 && r < s.Length)
                {
                    if (temp_set.Contains(s[r])) temp_set.Remove(s[r]);
                    r++;
                }

                if (temp_set.Count == 0)
                {
                    if (r - l < ans[1])
                    {
                        ans[0] = l;
                        ans[1] = r - l;
                    }
                }

                l++;
            }

            return ans[0] == -1 ? "" : s.Substring(ans[1], ans[1]);
        }

        public class Solution
        {
            Dictionary<int, List<string>> cost_map;
            public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
            {
                cost_map = new Dictionary<int, List<string>>();

                for (int i = 0; i < n; i++)
                {
                    if (!cost_map.ContainsKey(flights[i][0])) cost_map.Add(flights[i][0], new List<string>());
                    cost_map[flights[i][0]].Add($"{flights[i][1]}-{flights[i][2]}");
                }
                var result = recurse(src, k, dst, 0);
                return result == int.MaxValue ? -1 : result;
            }

            private int recurse(int src, int k, int dest, int totalCost)
            {
                if (k < 0) return int.MaxValue;
                if (src == dest) return totalCost;

                int minCost = int.MaxValue;
                var node = cost_map[src];

                foreach (var item in node)
                {
                    var arr = item.Split("-");
                    var s = int.Parse(arr[0]);
                    var cost = int.Parse(arr[1]);
                    minCost = Math.Min(minCost, recurse(s, k - 1, dest, totalCost + cost));
                }

                return minCost;
            }
        }

        
    }
}
