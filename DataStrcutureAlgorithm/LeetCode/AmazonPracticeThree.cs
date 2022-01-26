using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.LeetCode
{
    public class AmazonPracticeThree
    {
        HashSet<string> setSeen = new HashSet<string>();
        HashSet<string> set = new HashSet<string>();
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            wordList.Add(beginWord);
            foreach (var word in wordList)
            {
                set.Add(word);
            }

            if (!set.Contains(endWord))
                return 0;

            foreach (var word in wordList)
            {
                FindNeighbours(word, wordList);
            }
            queue.Enqueue(new Tuple<string, int>(beginWord, 1));
            var minLength = DoDFS(endWord, 2);
            minLength = minLength == int.MaxValue ? 0 : minLength;

            return minLength;
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

        private int DoDFS(string endWord, int len)
        {
            var beginWord = queue.Dequeue();
            var neighBours = dict[beginWord.Item1];

            if (beginWord.Item1 == endWord)
                return beginWord.Item2;

            setSeen.Add(beginWord.Item1);

            foreach (var word in neighBours)
            {
                if (!setSeen.Contains(word))
                {
                    queue.Enqueue(new Tuple<string, int>(word, beginWord.Item2 + 1));
                }
            }

            return DoDFS(endWord, len + 1);
        }
    }

}
