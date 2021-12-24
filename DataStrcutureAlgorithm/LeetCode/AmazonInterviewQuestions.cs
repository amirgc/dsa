using DataStrcutureAlgorithm.DataStructures;
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

                if (grid[currRow][currCol] == '1' && !vistedOnesCordinates.Contains($"{currRow}-{currCol}"))
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

        #region Meeting Intervals

        /* Given an array of meeting time intervals
              intervals where intervals[i] = [starti, endi],
                 return the minimum number of conference rooms required.*/
        public class MeetingIntervals
        {
            public int StartTime { get; set; }
            public int EndTime { get; set; }
        }

        public int MinMeetingRooms(int[][] intervals)
        {
            int totalRoomsRequired = 0;
            List<MeetingIntervals> meetingIntervals = new List<MeetingIntervals>();
            foreach (var interval in intervals)
            {
                meetingIntervals.Add(new MeetingIntervals()
                {
                    StartTime = interval[0],
                    EndTime = interval[1]
                });
            }

            meetingIntervals = meetingIntervals.OrderBy(x => x.StartTime).ThenBy(x => x.EndTime).ToList(); ;

            Stack<MeetingIntervals> meetingIntervalsScheduleOrder = new Stack<MeetingIntervals>();

            foreach (var currentInterval in meetingIntervals)
            {
                if (meetingIntervalsScheduleOrder.Count == 0)
                {
                    meetingIntervalsScheduleOrder.Push(currentInterval);
                    totalRoomsRequired++;
                }
                else
                {
                    var lastLastInterval = meetingIntervalsScheduleOrder.Peek();
                    if (lastLastInterval.EndTime > currentInterval.StartTime)
                    {
                        totalRoomsRequired++;
                    }
                    meetingIntervalsScheduleOrder.Push(currentInterval);
                }
            }

            return totalRoomsRequired;
        }

        public int minMeetingRoomsSecondSolution(int[][] intervals)
        {

            // Check for the base case. If there are no intervals, return 0
            if (intervals.Length == 0)
            {
                return 0;
            }

            // Min heap
            PriorityQueueC allocator = new PriorityQueueC(intervals.Length);

            // Sort the intervals by start time
            Array.Sort(
                intervals, (int[] a, int[] b) => { return a[0] - b[0]; }
             );

            //    // Add the first meeting
            allocator.Add(intervals[0][1]);

            //    // Iterate over remaining intervals
            for (int i = 1; i < intervals.Length; i++)
            {

                // If the room due to free up the earliest is free, assign that room to this meeting.
                if (intervals[i][0] >= allocator.Peek())
                {
                    allocator.Poll();
                }

                //// If a new room is to be assigned, then also we add to the heap,
                //// If an old room is allocated, then also we have to add to the heap with updated end time.
                allocator.Add(intervals[i][1]);
            }

            //    // The size of the heap tells us the minimum rooms required for all the meetings.
            return allocator.GetHeapSize();
        }

        #endregion

        public int[] getModifiedArray(int length, int[][] updates)
        {
            int[] myArray = new int[length];
            int[] toModify = new int[length]; //maintaining the range

            foreach (int[] currRange in updates)
            {

                int start = currRange[0];
                int end = currRange[1];
                int inc = currRange[2];

                toModify[start] = toModify[start] + inc; //starting index to increase/add
                if (end + 1 < length) toModify[end + 1] = toModify[end + 1] - inc; //till this index we have to add/increase

            }

            int currSum = 0;
            //calculate the result based on values present in 'toModify' array
            for (int i = 0; i < length; i++)
            {
                myArray[i] = currSum + toModify[i];
                currSum = myArray[i];
            }
            return myArray;
        }

        #region FindCircleNum
        /*
         There are n cities. Some of them are connected, while some are not. If city a is connected directly with city b, 
        and city b is connected directly with city c, then city a is connected indirectly with city c.
        A province is a group of directly or indirectly connected cities and no other cities outside of the group.
        You are given an n x n matrix isConnected where isConnected[i][j] = 1 if the ith city and the jth city are directly
        connected, and isConnected[i][j] = 0 otherwise.
        Return the total number of provinces.*/

        public void dfs(int[][] M, int[] visited, int i)
        {
            for (int j = 0; j < M.Length; j++)
            {
                if (M[i][j] == 1 && visited[j] == 0)
                {
                    visited[j] = 1;
                    dfs(M, visited, j);
                }
            }
        }
        public int findCircleNum(int[][] isConnected)
        {
            int[] visited = new int[isConnected.Length];
            int count = 0;
            for (int i = 0; i < isConnected.Length; i++)
            {
                if (visited[i] == 0)
                {
                    dfs(isConnected, visited, i);
                    count++;
                }
            }
            return count;
        }
        #endregion


        private int MOD = (int)(1e9 + 7);
        public int SumSubarrayMins(int[] arr)
        {
            int N = arr.Length;
            long res = 0;
            Stack<int> monoTone_Stack = new Stack<int>();
            int[] previousMin = new int[N];
            int[] nextMin = new int[N];

            for (int i = 0; i < arr.Length; i++)
            {
                while (monoTone_Stack.Count != 0 && arr[monoTone_Stack.Peek()] > arr[i])
                {
                    monoTone_Stack.Pop();
                }
                previousMin[i] = monoTone_Stack.Count == 0 ? -1 : monoTone_Stack.Peek();
                monoTone_Stack.Push(i);
            }

            monoTone_Stack = new Stack<int>();
            for (int i = N - 1; i >= 0; i--)
            {
                while (monoTone_Stack.Count != 0 && arr[monoTone_Stack.Peek()] > arr[i])
                {
                    monoTone_Stack.Pop();
                }
                nextMin[i] = monoTone_Stack.Count == 0 ? N : monoTone_Stack.Peek();
                monoTone_Stack.Push(i);
            }

            for (int i = 0; i < N; i++)
            {
                res = (res + arr[i] * (i - previousMin[i]) * (nextMin[i] - i)) % MOD;
            }

            return (int)(res % MOD);
        }

        public bool isPalindrome(int x)
        {
            string intStringValue = "";
            int integerLength = 0;

            if (x < 0)
                return false;

            while (x > 0)
            {
                int remainder = x % 10;
                x = x / 10;
                intStringValue += remainder.ToString();
                integerLength++;
            }

            for (int i = 0; i < integerLength / 2; i++)
            {
                if (intStringValue[i] != intStringValue[integerLength - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
        public int timeDifference(List<string> times)
        {
            int minTime = 0;

            string lastTime = null;
            int lastTimeInt = 0;
            times.Sort();
            bool comparisionStarted = false;

            foreach (string time in times)
            {
                if (string.IsNullOrEmpty(lastTime))
                {
                    lastTime = time;
                    lastTimeInt = ConvertIntToMinutes(time);
                }
                else
                {
                    int currentTime = ConvertIntToMinutes(time);
                    int diff = FindTheDistanceBetweenTime(lastTimeInt, currentTime);
                    lastTimeInt = currentTime;
                    if ((minTime == 0 && !comparisionStarted))
                    {
                        minTime = diff;
                    }
                    else if (minTime > diff && comparisionStarted)
                    {
                        minTime = diff;
                    }

                    comparisionStarted = true;
                }
            }
            int diffFInalTest = FindTheDistanceBetweenTime(ConvertIntToMinutes(times.First()),
                ConvertIntToMinutes(times.Last()));
            int res = minTime > diffFInalTest ? diffFInalTest : minTime;

            return res;
        }
        public int FindTheDistanceBetweenTime(int time1, int time2)
        {
            int regularDifference = Math.Abs(time1 - time2);
            int backwardTimeDifference = time1 > time2 ? 1440 - time1 + time2 : 1440 - time2 + time1;
            return regularDifference < backwardTimeDifference ? regularDifference : backwardTimeDifference;
        }

        public int ConvertIntToMinutes(string time)
        {
            int timeInMinutes = 0;
            var hourMinutesSplit = time.Split(":");
            timeInMinutes = Convert.ToInt32(hourMinutesSplit[0]) * 60 + Convert.ToInt32(hourMinutesSplit[1]);
            return timeInMinutes;
        }

        public int reverseBits(int input)
        {
            bool isOneFound = false;
            Stack<int> bitStack = new Stack<int>();

            while (input > 0)
            {
                int rem = input % 2;
                input = input / 2;

                if (rem == 1 && !isOneFound)
                {
                    isOneFound = true;
                }

                if (isOneFound)
                {
                    bitStack.Push(rem);
                }
            }


            Stack<int> tempStack = new Stack<int>();

            while (bitStack.Count != 0)
            {
                tempStack.Push(bitStack.Pop());
            }

            double res = 0;
            double pow = tempStack.Count - 1;

            while (tempStack.Count != 0)
            {
                res += tempStack.Pop() * Math.Pow(2.00, pow);
                pow--;
            }

            return (int)res;
        }

        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            var nodesValFromTargetNode = new List<int>();
            FindTheTargetNode(root, target, nodesValFromTargetNode, k);
            return nodesValFromTargetNode;
        }

        private void FindNodeWithinKDistance(TreeNode node, List<int> nodesValFromTargetNode, int? distance)
        {
            if (node == null)
                return;

            if (distance == 0 && node != null)
            {
                nodesValFromTargetNode.Add(node.val);
                return;
            }

            if (distance < 0)
            {
                return;
            }

            FindNodeWithinKDistance(node.left, nodesValFromTargetNode, distance - 1);
            FindNodeWithinKDistance(node.right, nodesValFromTargetNode, distance - 1);
        }

        private int? FindTheTargetNode(TreeNode root, TreeNode targetNode, List<int> nodesValFromTargetNode, int distance)
        {
            if (root == null)
                return null;

            if (root != null && root.val == targetNode.val)
            {
                FindNodeWithinKDistance(targetNode, nodesValFromTargetNode, distance);
                return distance - 1;
            }

            var res = FindTheTargetNode(root.left, targetNode, nodesValFromTargetNode, distance);

            if (res != null)
            {
                if (res == 0)
                {
                    nodesValFromTargetNode.Add(root.val);
                }
                else
                {
                    FindNodeWithinKDistance(root.right, nodesValFromTargetNode, res - 1);
                    return res - 1;
                }
            }
            else
            {
                res = FindTheTargetNode(root.right, targetNode, nodesValFromTargetNode, distance);

                if (res == 0)
                {
                    nodesValFromTargetNode.Add(root.val);
                }
                else
                {
                    FindNodeWithinKDistance(root.left, nodesValFromTargetNode, res - 1);
                    return res - 1;
                }
            }

            return null;

        }


        public int[][] KClosest(int[][] points, int k)
        {
            var res = new int[k][];
            Array.Sort(points, (a, b) => CalculateDistnace(a[0], a[1]) - CalculateDistnace(b[0], b[1]));

            Array.Copy(points, res, k);
            return res;
        }

        private int CalculateDistnace(int x, int y)
        {
            var hash = new HashSet<int>();
            var ququ = new Queue<int>();
            int a = ququ.Count();
            return x * x + y * y;
        }

        public int OrangesRotting(int[][] grid)
        {
            var rottenOranges = new Queue<Tuple<int, int>>();
            var totalOnes = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        rottenOranges.Enqueue(new Tuple<int, int>(i, j));
                    }
                    else if (grid[i][j] == 1)
                    {
                        totalOnes++;
                    }
                }
            }

            if (totalOnes == 0)
                return 0;

            if (rottenOranges.Count == 0)
                return -1;

            int res = FindOutMinTimeToRotOranges(grid, rottenOranges, 0);

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        return -1;
                    }
                }
            }
            return res;
        }

        private int FindOutMinTimeToRotOranges(int[][] grid, Queue<Tuple<int, int>> rottenOranges, int spentMinutes)
        {
            if (rottenOranges.Count == 0)
                return spentMinutes - 1;

            var newlyRottedOranges = new Queue<Tuple<int, int>>();

            while (rottenOranges.Count > 0)
            {
                MakeAdjacenOrangestRotten(grid, rottenOranges.Dequeue(), newlyRottedOranges);
            }

            return FindOutMinTimeToRotOranges(grid, newlyRottedOranges, spentMinutes + 1);

        }

        private void MakeAdjacenOrangestRotten(int[][] grid, Tuple<int, int> point, Queue<Tuple<int, int>> rottenOranges)
        {
            int row = point.Item1;
            int col = point.Item2;
            int totalRows = grid.Length;
            int rx, ry;
            rx = row; ry = col + 1;
            if (IsValidCell(grid, rx, ry))
            {
                grid[rx][ry] = 2;
                rottenOranges.Enqueue(new Tuple<int, int>(rx, ry));
            }

            rx = row; ry = col - 1;
            if (IsValidCell(grid, rx, ry))
            {
                grid[rx][ry] = 2;
                rottenOranges.Enqueue(new Tuple<int, int>(rx, ry));
            }

            rx = row - 1; ry = col;
            if (IsValidCell(grid, rx, ry))
            {
                grid[rx][ry] = 2;
                rottenOranges.Enqueue(new Tuple<int, int>(rx, ry));
            }

            rx = row + 1; ry = col;
            if (IsValidCell(grid, rx, ry))
            {
                grid[rx][ry] = 2;
                rottenOranges.Enqueue(new Tuple<int, int>(rx, ry));
            }

        }

        private bool IsValidCell(int[][] grid, int rx, int ry)
        {
            return rx >= 0 && ry >= 0 && rx < grid.Length && ry < grid[0].Length && grid[rx][ry] == 1;
        }

        public int NumPairsDivisibleBy60(int[] time)
        {
            int[] remainders = new int[60];
            int count = 0;
            foreach (int t in time)
            {
                if (t % 60 == 0)
                { // check if a%60==0 && b%60==0
                    count += remainders[0];
                }
                else
                { // check if a%60+b%60==60
                    count += remainders[60 - t % 60];
                }
                remainders[t % 60]++; // remember to update the remainders
            }
            return count;
        }
        public Boolean isRobotBounded(String instructions)
        {
            // north = 0, east = 1, south = 2, west = 3
            int[][] directions = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
            // Initial position is in the center
            int x = 0, y = 0;
            // facing north
            int idx = 0;
            var a = int.MaxValue;

            foreach (char i in instructions)
            {
                if (i == 'L')
                    idx = (idx + 3) % 4;
                else if (i == 'R')
                    idx = (idx + 1) % 4;
                else
                {
                    x += directions[idx][0];
                    y += directions[idx][1];
                }
            }

            // after one cycle:
            // robot returns into initial position
            // or robot doesn't face north
            return (x == 0 && y == 0) || (idx != 0);
        }

        public int MinSwaps(int[] data)
        {
            Array.Sort(data);
            int ones = data.Sum();
            int cnt_one = 0, max_one = 0;
            int left = 0, right = 0;
            var dictTimeStampMaping = new Dictionary<int, List<int>>();
            while (right < data.Length)
            {
                // updating the number of 1's by adding the new element
                cnt_one += data[right++];
                // maintain the length of the window to ones
                if (right - left > ones)
                {
                    // updating the number of 1's by removing the oldest element
                    cnt_one -= data[left++];
                }
                // record the maximum number of 1's in the window
                max_one = Math.Max(max_one, cnt_one);
            }
            return ones - max_one;
        }

        public class Pair
        {
            public int TimeStamp { get; set; }
            public string Website { get; set; }

        }

        public List<String> mostVisitedPattern(String[] username, int[] timestamp, String[] website)
        {
            Dictionary<String, List<Pair>> map = new Dictionary<String, List<Pair>>();
            int n = username.Length;
            // collect the website info for every user, key: username, value: (timestamp, website)
            for (int i = 0; i < n; i++)
            {
                if (!map.ContainsKey(username[i]))
                    map.Add(username[i], new List<Pair>());
                map[username[i]].Add(new Pair() { TimeStamp = timestamp[i], Website = website[i] });
            }

            // count map to record every 3 combination occuring time for the different user.
            Dictionary<String, int> count = new Dictionary<String, int>();

            String res = "";
            foreach (var keyvalue in map)
            {
                HashSet<String> set = new HashSet<String>();
                // this set is to avoid visit the same 3-seq in one user
                keyvalue.Value.Sort((a, b) => a.TimeStamp - b.TimeStamp);// sort by time
                var list = keyvalue.Value;                              // brutal force O(N ^ 3)
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        for (int k = j + 1; k < list.Count; k++)
                        {
                            String str = list[i].Website + " " + list[j].Website + " " + list[k].Website;
                            if (!set.Contains(str))
                            {
                                if (!count.ContainsKey(str))
                                {
                                    count.Add(str, 0);
                                }
                                count[str] += 1;
                                set.Add(str);
                            }

                            if (res.Equals("") || count[res] < count[str] ||
                                    (count[res] == count[str] &&
                                    res.CompareTo(str) > 0))
                            {
                                // make sure the right lexi order
                                res = str;
                            }
                        }
                    }
                }
            }

            // grab the right answer
            String[] r = res.Split(" ");
            List<String> result = new List<string>();
            foreach (String str in r)
            {
                result.Add(str);
            }

            return result;
        }

        public int connectSticks(int[] sticks)
        {
            int totalCost = 0;

            PriorityQueueC pq = new PriorityQueueC(sticks.Length);

            // add all sticks to the min heap.
            foreach (int stick in sticks)
            {
                pq.Add(stick);
            }

            //// combine two of the smallest sticks until we are left with just one.
            while (pq.GetHeapSize() > 1)
            {
                int stick1 = pq.Poll();
                int stick2 = pq.Poll();

                int cost = stick1 + stick2;
                totalCost += cost;

                pq.Add(stick1 + stick2);
            }

            return totalCost;
        }
    }
}
