using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStrcutureAlgorithm.DataStructures
{

    public class Solution
    {
        public class TrieNode
        {
            public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
            public string word { get; set; }
        }

        char[][] _board = null;
        List<string> _result = new List<string>();

        public IList<string> FindWords(char[][] board, string[] words)
        {
            // Step 1). Construct the Trie
            TrieNode root = new TrieNode();

            foreach (var word in words)
            {
                TrieNode node = root;

                foreach (char letter in word)
                {
                    if (node.children.ContainsKey(letter))
                    {
                        node = node.children[letter];
                    }
                    else
                    {
                        TrieNode newNode = new TrieNode();
                        node.children.Add(letter, newNode);
                        node = newNode;
                    }
                }
                node.word = word;  // store words in Trie
            }

            this._board = board;
            // Step 2). Backtracking starting for each cell in the board
            for (int row = 0; row < board.Length; ++row)
            {
                for (int col = 0; col < board[row].Length; ++col)
                {
                    if (root.children.ContainsKey(board[row][col]))
                    {
                        backtracking(row, col, root);
                    }
                }
            }

            return this._result;
        }

        private void backtracking(int row, int col, TrieNode parent)
        {
            char letter = this._board[row][col];
            TrieNode currNode = parent.children[letter];

            // check if there is any match
            if (currNode.word != null)
            {
                this._result.Add(currNode.word);
                currNode.word = null;
            }

            // mark the current letter before the EXPLORATION
            this._board[row][col] = '#';

            // explore neighbor cells in around-clock directions: up, right, down, left
            int[] rowOffset = { -1, 0, 1, 0 };
            int[] colOffset = { 0, 1, 0, -1 };
            for (int i = 0; i < 4; ++i)
            {
                int newRow = row + rowOffset[i];
                int newCol = col + colOffset[i];
                if (newRow < 0 || newRow >= this._board.Length || newCol < 0
                    || newCol >= this._board[0].Length)
                {
                    continue;
                }
                if (currNode.children.ContainsKey(this._board[newRow][newCol]))
                {
                    backtracking(newRow, newCol, currNode);
                }
            }

            // End of EXPLORATION, restore the original letter in the board.
            this._board[row][col] = letter;

            // Optimization: incrementally remove the leaf nodes
            if (currNode.children.Count == 0)
            {
                parent.children.Remove(letter);
            }
        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> result = new List<int>();
            int rows = matrix.Length;
            int columns = matrix[0].Length;
            int up = 0;
            int left = 0;
            int right = columns - 1;
            int down = rows - 1;

            while (result.Count < rows * columns)
            {
                // Traverse from left to right.
                for (int col = left; col <= right; col++)
                {
                    result.Add(matrix[up][col]);
                }
                // Traverse downwards.
                for (int row = up + 1; row <= down; row++)
                {
                    result.Add(matrix[row][right]);
                }
                // Make sure we are now on a different row.
                if (up != down)
                {
                    // Traverse from right to left.
                    for (int col = right - 1; col >= left; col--)
                    {
                        result.Add(matrix[down][col]);
                    }
                }
                // Make sure we are now on a different column.
                if (left != right)
                {
                    // Traverse upwards.
                    for (int row = down - 1; row > up; row--)
                    {
                        result.Add(matrix[row][left]);
                    }
                }
                left++;
                right--;
                up++;
                down--;
            }

            return result;
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var res = new List<IList<string>>();
            if (strs.Length == 0)
                return res;

            Dictionary<string, List<string>> ans = new Dictionary<string, List<string>>();
            int[] count = new int[26];
            foreach (string s in strs)
            {
                Array.Fill(count, 0);
                foreach (char c in s)
                    count[c - 'a']++;

                StringBuilder sb = new StringBuilder("");
                for (int i = 0; i < 26; i++)
                {
                    sb.Append('#');
                    sb.Append(count[i]);
                }
                string key = sb.ToString();
                if (!ans.ContainsKey(key))
                    ans.Add(key, new List<string>());

                ans[key].Add(s);
            }
            ans.Values.ToList().ForEach(x => res.Add(x));

            return res;
        }

    }
}
