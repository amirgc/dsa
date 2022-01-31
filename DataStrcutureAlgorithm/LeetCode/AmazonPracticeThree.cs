using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace DataStrcutureAlgorithm.LeetCode
{
    public class AmazonPracticeThree
    {
        //HashSet<string> setSeen = new HashSet<string>();
        //HashSet<string> set = new HashSet<string>();
        //Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        //Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();

        //public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        //{
        //    wordList.Add(beginWord);
        //    foreach (var word in wordList)
        //    {
        //        set.Add(word);
        //    }

        //    if (!set.Contains(endWord))
        //        return 0;
        //    if (!set.Contains(beginWord))
        //        wordList.Add(beginWord);

        //    foreach (var word in wordList)
        //    {
        //        FindNeighbours(word, wordList);
        //    }

        //    queue.Enqueue(new Tuple<string, int>(beginWord, 1));

        //    var minLength = DoDFS(endWord, 2);
        //    minLength = minLength == int.MaxValue ? 0 : minLength;


        //    List<string> res = new List<string>();
        //    res.Remove('abc");

        //    return minLength;
        //}

        //private void FindNeighbours(string word, IList<string> wordList)
        //{
        //    dict.Add(word, new List<string>());

        //    for (int i = 1; i <= word.Length; i++)
        //    {
        //        string pre = word.Substring(0, i - 1);
        //        string post = word.Substring(i);
        //        for (int j = 0; j < 26; j++)
        //        {
        //            char ch = (char)((int)'a' + j);
        //            string sw = pre + ch + post;
        //            if (sw != word && set.Contains(sw))
        //            {
        //                dict[word].Add(pre + ch + post);
        //            }
        //        }
        //    }

        //}

        //private int DoDFS(string endWord, int len)
        //{
        //    var beginWord = queue.Dequeue();
        //    var neighBours = dict[beginWord.Item1];

        //    if (beginWord.Item1 == endWord)
        //        return beginWord.Item2;

        //    setSeen.Add(beginWord.Item1);

        //    foreach (var word in neighBours)
        //    {
        //        if (!setSeen.Contains(word))
        //        {
        //            queue.Enqueue(new Tuple<string, int>(word, beginWord.Item2 + 1));
        //        }
        //    }

        //    return DoDFS(endWord, len + 1);
        //}

        HashSet<string> setSeen = new HashSet<string>();
        HashSet<string> set = new HashSet<string>();
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        Queue<Tuple<string, string>> queue = new Queue<Tuple<string, string>>();
        List<IList<string>> result = new List<IList<string>>();
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            foreach (var word in wordList)
                set.Add(word);

            if (!set.Contains(endWord))
                return result;

            if (!set.Contains(beginWord))
                wordList.Add(beginWord);

            foreach (var word in wordList)
                FindNeighbours(word, wordList);

            var res = new List<string>();
            res.Add(beginWord);
            queue.Enqueue(new Tuple<string, string>(beginWord, null));

            DoDFS(endWord, res);

            return result;
        }

        private void DoDFS(string endWord, List<string> res)
        {
            if (queue.Count == 0)
                return;

            var node = queue.Dequeue();
            var neighBours = dict[node.Item1];

            if (node.Item1 == endWord)
            {
                result.Add(new List<string>(res));
                return;
            }
            setSeen.Add(node.Item1);

            foreach (var word in neighBours)
            {
                if (!setSeen.Contains(word))
                {
                    queue.Enqueue(new Tuple<string, string>(word, node.Item1));
                    res.Add(word);

                    res.Remove(word);
                }
            }

            DoDFS(endWord, res);
        }

        private void FindNeighbours(string word, IList<string> wordList)
        {
            dict.Add(word, new List<string>());

            for (int i = 1; i <= word.Length; i++)
            {
                string pre = word.Substring(0, i - 1);
                string post = word.Substring(i);
                for (int j = 0; j < 26; j++)
                {
                    char ch = (char)((int)'a' + j);
                    string sw = pre + ch + post;
                    if (sw != word && set.Contains(sw))
                    {
                        dict[word].Add(pre + ch + post);
                    }
                }
            }

        }

        public int reverse(int x)
        {
            int rev = 0;
            while (x != 0)
            {
                int pop = x % 10;
                x /= 10;
                if (rev > int.MaxValue / 10 || (rev == int.MaxValue / 10 && pop > 7)) return 0;
                if (rev < int.MinValue / 10 || (rev == int.MinValue / 10 && pop < -8)) return 0;
                rev = rev * 10 + pop;
            }
            return rev;
        }



        // Definition for a Node.
        public class NodeRandom
        {
            public int val;
            public NodeRandom next;
            public NodeRandom random;

            public NodeRandom(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }

        public NodeRandom CopyRandomList(NodeRandom head)
        {
            if (head == null)
                return null;

            Dictionary<NodeRandom, NodeRandom> dict = new Dictionary<NodeRandom, NodeRandom>();

            var res_head = new NodeRandom(0);
            NodeRandom deep_head = new NodeRandom(0);
            NodeRandom tail = new NodeRandom(0);
            res_head.next = deep_head;
            tail = head;

            while (head != null)
            {
                if (dict.ContainsKey(head))
                {
                    tail.next = dict[head];
                    tail = tail.next;
                    deep_head = tail;
                }
                else
                {
                    deep_head.val = head.val;
                }

                if (head.random != null && dict.ContainsKey(head.random))
                {
                    deep_head.random = dict[head.random];
                }
                else if (head.random != null)
                {
                    var random = new NodeRandom(head.random.val);
                    dict.Add(head.random, random);
                    deep_head.random = random;
                }
                else
                {
                    deep_head.random = null;
                }

                if (!dict.ContainsKey(head))
                {
                    dict.Add(head, deep_head);
                }

                tail = deep_head;
                deep_head.next = new NodeRandom(0);
                deep_head = deep_head.next;
                head = head.next;

            }
            tail.next = null;

            return res_head.next;


        }

        public int ThreeSumClosest(int[] nums, int target)
        {

            Array.Sort(nums);
            int sum = 0;
            int minDiff = int.MaxValue;

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int a = nums[i];
                int lp = i + 1;
                int rp = nums.Length - 1;

                while (lp < rp && lp < nums.Length)
                {
                    int curr_sum = a + nums[lp] + nums[rp];

                    if (Math.Abs(target - curr_sum) < minDiff)
                    {
                        sum = curr_sum;
                        minDiff = Math.Abs(target - sum);
                    }

                    if (curr_sum < target) lp++;
                    else rp--;
                }
            }

            return sum;
        }

        public int Trap(int[] height)
        {

            int ans = 0, current = 0;

            Stack<int> st = new Stack<int>();

            while (current < height.Length)
            {

                while (st.Count != 0 && height[current] > height[st.Peek()])
                {
                    int top = st.Pop();

                    if (st.Count == 0)
                        break;

                    int distance = current - st.Peek() - 1;

                    int bounded_height = Math.Min(height[current], height[st.Peek()]) - height[top];

                    ans += distance * bounded_height;
                }

                st.Push(current++);
            }

            return ans;
        }

        public class CustomComparer : IComparer<string>
        {
            public int Compare([AllowNull] string log1, [AllowNull] string log2)
            {
                // split each log into two parts: <identifier, content>
                string[] split1 = log1.Split(" ", 2);
                string[] split2 = log2.Split(" ", 2);

                bool isDigit1 = char.IsDigit(split1[1][0]);
                bool isDigit2 = char.IsDigit(split2[1][0]);

                // case 1). both logs are letter-logs
                if (!isDigit1 && !isDigit2)
                {
                    // first compare the content
                    int cmp = split1[1].CompareTo(split2[1]);
                    if (cmp != 0)
                        return cmp;
                    // logs of same content, compare the identifiers
                    return split1[0].CompareTo(split2[0]);
                }

                // case 2). one of logs is digit-log
                if (!isDigit1 && isDigit2)
                    // the letter-log comes before digit-logs
                    return -1;
                else if (isDigit1 && !isDigit2)
                    return 1;
                else
                    // case 3). both logs are digit-log
                    return 0;
            }
        }

        public string[] ReorderLogFiles(string[] logs)
        {
            var myComp = new CustomComparer();
            string paragraph = "";
            paragraph.Replace("'", "");
            string[] allWords = paragraph.Split(new char[] { ' ', '!', '?', ',', ';', '.' });
            Array.Sort(logs, myComp);
            return logs;
        }

        Dictionary<int, int> memo = new Dictionary<int, int>();

        public int CompareVersion(string version1, string version2)
        {
            var arr1 = version1.Split(".");
            var arr2 = version2.Split(".");

            int counter = Math.Min(arr1.Length, arr2.Length);
            int index = 0;
            while (index < counter)
            {
                if (int.Parse(arr1[counter]) < int.Parse(arr2[counter]))
                {
                    return -1;
                }
                else if (int.Parse(arr1[counter]) > int.Parse(arr2[counter]))
                {
                    return 1;
                }
                index++;
            }

            if (version1.Length == version2.Length)
            {
                return 0;
            }

            return version1.Length > version2.Length ? -1 : 1;
        }

        public string MostCommonWord(string paragraph, string[] banned)
        {
            string[] test = "dsf sdfsd".Split(" ");
            var bannedDict = banned.ToHashSet();
            paragraph = paragraph.ToLower();
            paragraph.Replace("'", "");
            string[] allWords = paragraph.Split(new char[] { ' ', '!', '?', ',', ';', '.' });

            int max_rep = 0; string curr_max_rep_word = null;
            var store = new Dictionary<string, int>();

            foreach (string word in allWords)
            {
                if (!bannedDict.Contains(word) && !string.IsNullOrEmpty(word))
                {
                    if (!store.ContainsKey(word)) store.Add(word, 0);

                    store[word]++;

                    if (max_rep < store[word])
                    {
                        curr_max_rep_word = word;
                        max_rep = store[word];
                    }
                }
            }

            return curr_max_rep_word;
        }

        public int StrStr(string haystack, string needle)
        {
            if (needle == "") return 0;

            if (haystack.Length < needle.Length) return -1;

            int p1 = 0;

            while (!string.IsNullOrEmpty(haystack))
            {
                if (compareWord(haystack, needle))
                    return p1;
                p1++;
                haystack = haystack.Substring(1);

            }

            return -1;
        }

        private bool compareWord(string haystack, string needle)
        {
            if (haystack.Length < needle.Length) return false;

            bool isMatch = true; int idx = 0;

            while (idx < needle.Length)
            {
                if (haystack[idx] != needle[idx]) return false;
                idx++;
            }

            return isMatch;
        }
        public String one(int num)
        {
            switch (num)
            {
                case 1: return "One";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                case 5: return "Five";
                case 6: return "Six";
                case 7: return "Seven";
                case 8: return "Eight";
                case 9: return "Nine";
            }
            return "";
        }

        public String twoLessThan20(int num)
        {
            switch (num)
            {
                case 10: return "Ten";
                case 11: return "Eleven";
                case 12: return "Twelve";
                case 13: return "Thirteen";
                case 14: return "Fourteen";
                case 15: return "Fifteen";
                case 16: return "Sixteen";
                case 17: return "Seventeen";
                case 18: return "Eighteen";
                case 19: return "Nineteen";
            }
            return "";
        }

        public String ten(int num)
        {
            switch (num)
            {
                case 2: return "Twenty";
                case 3: return "Thirty";
                case 4: return "Forty";
                case 5: return "Fifty";
                case 6: return "Sixty";
                case 7: return "Seventy";
                case 8: return "Eighty";
                case 9: return "Ninety";
            }
            return "";
        }

        public String two(int num)
        {
            if (num == 0)
                return "";
            else if (num < 10)
                return one(num);
            else if (num < 20)
                return twoLessThan20(num);
            else
            {
                int tenner = num / 10;
                int rest = num - tenner * 10;
                if (rest != 0)
                    return ten(tenner) + " " + one(rest);
                else
                    return ten(tenner);
            }
        }

        public String three(int num)
        {
            int hundred = num / 100;
            int rest = num - hundred * 100;
            String res = "";
            if (hundred * rest != 0)
                res = one(hundred) + " Hundred " + two(rest);
            else if ((hundred == 0) && (rest != 0))
                res = two(rest);
            else if ((hundred != 0) && (rest == 0))
                res = one(hundred) + " Hundred";
            return res;
        }

        public string NumberToWords(int num)
        {
            if (num == 0)
                return "Zero";

            int billion = num / 1000000000;
            int million = (num - billion * 1000000000) / 1000000;
            int thousand = (num - billion * 1000000000 - million * 1000000) / 1000;
            int rest = num - billion * 1000000000 - million * 1000000 - thousand * 1000;

            String result = "";
            if (billion != 0)
                result = three(billion) + " Billion";
            if (million != 0)
            {
                if (!string.IsNullOrEmpty(result))
                    result += " ";
                result += three(million) + " Million";
            }
            if (thousand != 0)
            {
                if (!string.IsNullOrEmpty(result))
                    result += " ";
                result += three(thousand) + " Thousand";
            }
            if (rest != 0)
            {
                if (!string.IsNullOrEmpty(result))
                    result += " ";
                result += three(rest);
            }
            return result;
        }
    }
}
