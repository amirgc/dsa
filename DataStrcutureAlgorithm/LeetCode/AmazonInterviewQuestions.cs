using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStrcutureAlgorithm.LeetCode
{
    public class AmazonInterviewQuestions
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<int, List<string>> listGroupByLength = new Dictionary<int, List<string>>();
            Dictionary<int, List<List<string>>> listGroupByLengthAndAnagrams = new Dictionary<int, List<List<string>>>();

            foreach (string str in strs)
            {
                int length = str.Length;
                if (listGroupByLength.ContainsKey(length))
                {
                    listGroupByLength[length].Add(str);
                }
                else
                {
                    listGroupByLength.Add(length, new List<string>() { str });
                }
            }

            foreach (var item in listGroupByLength)
            {
                foreach (string str in item.Value)
                {
                    if (listGroupByLengthAndAnagrams.ContainsKey(item.Key))
                    {
                        var stringWithSameLengthsAndAnagram = listGroupByLengthAndAnagrams[item.Key];

                        var anagramFound = false;
                        foreach (var group in stringWithSameLengthsAndAnagram)
                        {
                            var sampleStringFromGroup = group.FirstOrDefault();

                            if (checkifStringAreAnagramsOfEachOther(sampleStringFromGroup, str))
                            {
                                group.Add(str);
                                anagramFound = true;
                                continue;
                            }
                        }

                        if (!anagramFound)
                        {
                            listGroupByLengthAndAnagrams[item.Key].Add(new List<string>() { str });
                        }
                    }
                    else
                    {
                        var newItemGroupToList = new List<List<string>>();
                        newItemGroupToList.Add(new List<string>() { str });
                        listGroupByLengthAndAnagrams[item.Key] = newItemGroupToList;
                    }
                }
            }

            var res = new List<IList<string>>();

            foreach (var groups in listGroupByLengthAndAnagrams)
            {
                foreach (var group in groups.Value)
                {
                    res.Add(group);
                }
            }
            return res;
        }

        bool checkifStringAreAnagramsOfEachOther(string str1, string str2)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char ch in str1)
            {
                if (dict.ContainsKey(ch))
                {
                    dict[ch] += 1;
                }
                else
                {
                    dict.Add(ch, 1);
                }
            }

            foreach (char ch in str2)
            {
                if (!dict.ContainsKey(ch))
                {
                    return false;
                }
                else
                {
                    if (dict[ch] == 0)
                        return false;

                    dict[ch] -= 1;
                }
            }

            return true;
        }

        #region Exist Word Amazon Question
        HashSet<string> hashSet;
        public bool Exist(char[][] board, string word)
        {
            int row = board.Length;
            int column = board[0].Length;

            int counter = row * column;

            for (int i = 0; i < counter; i++)
            {
                var currRow = i / column;
                var currCol = i % column;
                hashSet = new HashSet<string>();

                if (board[currRow][currCol] == word[0])
                {
                    if (Exist(board, word, row, column, currRow, currCol))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool Exist(char[][] board, string word, int row, int column, int locx, int locy)
        {
            if (word.Length == 1)
            {
                return true;
            }

            hashSet.Add($"{locx}-{locy}");

            var locationsNextCharTupples = GetAllVerticesWithNextCharacter(row, column, locx, locy, word[1], board);

            foreach (var nextLocation in locationsNextCharTupples)
            {
                var found = Exist(board, word.Substring(1), row, column, nextLocation.Item1, nextLocation.Item2);

                if (found)
                {
                    return true;
                }
            }
            hashSet.Remove($"{locx}-{locy}");
            return false;
        }

        private List<Tuple<int, int>> GetAllVerticesWithNextCharacter(int row, int col, int locx, int locy, char ch,
            char[][] board)
        {
            List<Tuple<int, int>> tuples = new List<Tuple<int, int>>();

            if (isValidVertex(row, col, locx + 1, locy) && ch == board[locx + 1][locy])
            {
                var currentTuple = new Tuple<int, int>(locx + 1, locy);
                tuples.Add(currentTuple);
            }

            if (isValidVertex(row, col, locx - 1, locy) && ch == board[locx - 1][locy])
            {
                var currentTuple = new Tuple<int, int>(locx - 1, locy);
                tuples.Add(currentTuple);
            }

            if (isValidVertex(row, col, locx, locy + 1) && ch == board[locx][locy + 1])
            {
                var currentTuple = new Tuple<int, int>(locx, locy + 1);
                tuples.Add(currentTuple);
            }

            if (isValidVertex(row, col, locx, locy - 1) && ch == board[locx][locy - 1])
            {
                var currentTuple = new Tuple<int, int>(locx, locy - 1);
                tuples.Add(currentTuple);
            }

            return tuples;
        }

        private bool isValidVertex(int row, int col, int locx, int locy)
        {
            if (hashSet.Contains($"{locx}-{locy}"))
                return false;

            if (!(locx < row && locx >= 0))
                return false;

            if (!(locy < col && locy >= 0))
                return false;

            return true;
        }

        #endregion

        #region Does IsLand exist Amazon Question

        HashSet<string> vistedOnesCordinates;
        public int NumIslands(char[][] grid)
        {
            int row = grid.Length;
            int column = grid[0].Length;
            int totalPaths = 0;
            int counter = row * column;
            vistedOnesCordinates = new HashSet<string>();

            for (int i = 0; i < counter; i++)
            {
                var currRow = i / column;
                var currCol = i % column;

                if (grid[currRow][currCol] == '1' && vistedOnesCordinates.Contains($"{currRow}-{currCol}"))
                {
                    totalPaths++;
                    vistedOnesCordinates.Add($"{currRow}-{currCol}");
                    SearchForOtherPathFromCurrentOnes(row, column, currRow, currCol, grid);
                }
            }

            return totalPaths;
        }

        public void SearchForOtherPathFromCurrentOnes(int row, int col, int locx, int locy, char[][] grid)
        {
            var nextCordinatesWithOnes = GetAdjacentVerticesWithOne(row, col, locx, locy, grid);

            if (nextCordinatesWithOnes.Count == 0)
                return;

            foreach (var cordinates in nextCordinatesWithOnes)
            {
                vistedOnesCordinates.Add($"{cordinates.Item1}-{cordinates.Item2}");
            }

            foreach (var cordinates in nextCordinatesWithOnes)
            {
                SearchForOtherPathFromCurrentOnes(row, col, cordinates.Item1, cordinates.Item2, grid);
            }

        }

        private List<Tuple<int, int>> GetAdjacentVerticesWithOne(int row, int col, int locx, int locy, char[][] board)
        {
            List<Tuple<int, int>> tuples = new List<Tuple<int, int>>();

            if (isValidVertex1(row, col, locx + 1, locy) && '1' == board[locx + 1][locy])
            {
                var currentTuple = new Tuple<int, int>(locx + 1, locy);
                tuples.Add(currentTuple);
            }

            if (isValidVertex1(row, col, locx - 1, locy) && '1' == board[locx - 1][locy])
            {
                var currentTuple = new Tuple<int, int>(locx - 1, locy);
                tuples.Add(currentTuple);
            }

            if (isValidVertex1(row, col, locx, locy + 1) && '1' == board[locx][locy + 1])
            {
                var currentTuple = new Tuple<int, int>(locx, locy + 1);
                tuples.Add(currentTuple);
            }

            if (isValidVertex1(row, col, locx, locy - 1) && '1' == board[locx][locy - 1])
            {
                var currentTuple = new Tuple<int, int>(locx, locy - 1);
                tuples.Add(currentTuple);
            }

            return tuples;
        }

        private bool isValidVertex1(int row, int col, int locx, int locy)
        {
            if (vistedOnesCordinates.Contains($"{locx}-{locy}"))
                return false;

            if (!(locx < row && locx >= 0))
                return false;

            if (!(locy < col && locy >= 0))
                return false;

            return true;
        }

        #endregion
    }
}
