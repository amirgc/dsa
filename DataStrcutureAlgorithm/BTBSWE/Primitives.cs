﻿using DataStrcutureAlgorithm.DataStructures;
using DataStrcutureAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStrcutureAlgorithm.BTBSWE
{
    public class Primitives
    {

        public String changeBase(String numAsString, int b1, int b2)
        {
            Boolean isNegative = numAsString.StartsWith("-");

            /*
            * start: If the number has a minus sign "-", then we start decomposing
            * 'numAsString' from index 1 instead of from index 0.
            * 
            * maxPower: The power applied to the base that the most significant digit will
            * be multiplied by. Ex: "324" -> maxPower will be 2 since "324" = (3 x 10^2) +
            * (2 x 10^1) + (4 x 10^0) ^ maxPower
            * 
            * numberUnderBase10: The number we are slowly going to build
            */
            int start = isNegative ? 1 : 0;
            int maxPower = numAsString.Length - 1;
            int numberUnderBase10 = 0;

            /*
            * Loop over every digit & add it to the base 10 integer representation we are
            * building. We will later take this base 10 integer and convert it into b2.
            */
            for (int i = start; i < numAsString.Length; i++)
            {
                /*
                * Get the integer value that this place "contributes", or in other words, the
                * value that will be multiplied by (base)^(digit's position).
                */
                bool isPlaceADigit = char.IsNumber(numAsString[i]);
                int valueContributedByPlace = isPlaceADigit ? numAsString[i] - '0' : numAsString[i] - 'A' + 10;

                /*
                * So if we have "895", it means:
                * 
                * (8 x 10^2) + (9 x 10^1) + (5 x 10^0) (800) + (90) + (5) 895
                * 
                * If we have "1AB" (under base 16, hex), it means:
                * 
                * A => 10 B => 11 (1 x 16^2) + (10 x 16^1) + (11 x 16^0) (256) + (160) + (11)
                * 427
                */
                int positionPowerWeight = maxPower - i;
                numberUnderBase10 += (int)(valueContributedByPlace * Math.Pow(b1, positionPowerWeight));
            }

            if (numberUnderBase10 == 0)
            {
                return "0";
            }
            else
            {
                return (isNegative ? "-" : "") + Base10ToNewBase(numberUnderBase10, b2);
            }
        }

        private String Base10ToNewBase(int numberUnderBase10, int baseValue)

        {
            if (numberUnderBase10 == 0)
            {
                return "";
            }

            // lsd => "least significant digit"
            char lsdAsChar;
            int lsdUnderFinalBase = numberUnderBase10 % baseValue;

            bool needsHexConversion = lsdUnderFinalBase >= 10;
            if (needsHexConversion)
            {
                /*
                * Convert digit into a letter (theoretically 'A'-'Z') because we can't express
                * values 10 and above as single digit values.
                * 
                * If we go past base 36 this will break.
                */
                lsdAsChar = (char)('A' + lsdUnderFinalBase - 10);
            }
            else
            {
                // 'lsdUnderFinalBase' can be expressed as a single digit
                lsdAsChar = (char)('0' + lsdUnderFinalBase);
            }

            int base10NumberWithoutLsd = numberUnderBase10 / baseValue;
            String everythingElseToOurLeft = Base10ToNewBase(base10NumberWithoutLsd, baseValue);

            return everythingElseToOurLeft + lsdAsChar;
        }

        public List<List<int>> threeSum(int[] A)
        {

            Array.Sort(A); // Sorting array of integers can take O(n) time via Bucket Sort or Radix Sort

            // Hash set is used to avoid the duplicate 
            HashSet<List<int>> allThreeSums = new HashSet<List<int>>();
            int secondToLastIndex = A.Length - 2;

            // Find two sum function should run for each value of i
            for (int i = 0; i < secondToLastIndex; i++)
            {
                findTwoSum(i, A, allThreeSums);
            }

            return new List<List<int>>(allThreeSums);
        }

        private void findTwoSum(int rootIndex, int[] A, HashSet<List<int>> allThreeSums)
        {
            int left = rootIndex + 1;
            int right = A.Length - 1;
            var uniqueQueue = new HashSet<string>();
            // Loop till left index is less than right index
            while (left < right)
            {
                int threeNumberSum = A[rootIndex] + A[left] + A[right];
                // If we get the ans than increase left index
                // Decrease right index
                // And add the solution to the set
                var sums = new List<int>() { A[rootIndex], A[left], A[right] };
                var key = string.Join("-", sums);
                if (threeNumberSum == 0 && !uniqueQueue.Contains(key))
                {
                    allThreeSums.Add(sums);
                    uniqueQueue.Add(key);
                    left++; right--;
                }
                else if (threeNumberSum < 0)
                {
                    // If sum<0 only increase left index to increase the value of sum
                    left++;
                }
                else
                {
                    // If sum>0 only decrease the right index to decrease the value of sum
                    right--;
                }
            }
        }

        public int[] sortArray_0_1_2(int[] nums)
        {
            int count0 = 0, count1 = 0, count2 = 0;

            //Iterate through the array and count the frequencies of each number
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0) { count0++; }
                if (nums[i] == 1) { count1++; }
                if (nums[i] == 2) { count2++; }
            }

            //Fill the original array
            //First fill all 0, then 1 and at last 2
            for (int i = 0; i < nums.Length; i++)
            {
                if (i < count0) { nums[i] = 0; }
                else if (i < count0 + count1) { nums[i] = 1; }
                else { nums[i] = 2; }
            }


            return nums;
        }

        public bool validSudoku(int[][] board)
        {
            Dictionary<string, bool> seen = new Dictionary<string, bool>();
            string row, col, box;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] != 0)
                    {
                        row = i + "(" + board[i][j] + ")";
                        col = "(" + board[i][j] + ")" + j;
                        box = (i / 3) + "(" + board[i][j] + ")" + (j / 3);

                        /* Verify row correctness. */
                        /* Verify column correctness. */
                        /* Verify box correctness. */
                        // If any one is false return false
                        if (seen.ContainsKey(row) || seen.ContainsKey(col) || seen.ContainsKey(box))
                            return false;

                        seen.Add(row, true);
                        seen.Add(col, true);
                        seen.Add(box, true);
                    }
                }
            }
            return true;
        }

        public List<int> spiralOrder(int[][] matrix)
        {
            int matrixRows = matrix.Length;
            int matrixColumn = matrix[0].Length;

            var res = new List<int>();
            int row1Pointer = matrixRows;
            int column1Pointer = matrixColumn;
            int levelCounter = 0;

            for (int i = 0; i < (matrixRows / 2); i++)
            {
                for (int j = 0; j < column1Pointer; j++)
                {
                    res.Add(matrix[i][levelCounter + j]);
                }

                //last column
                for (int j = 0; j < row1Pointer - 1; j++)
                {
                    res.Add(matrix[levelCounter + j + 1][matrixColumn - 1 - levelCounter]);
                }

                // bottom row
                for (int j = 0; j < column1Pointer; j++)
                {
                    res.Add(matrix[matrixRows - 1 - levelCounter][matrixColumn - 1 - levelCounter - j]);
                }

                for (int j = 0; j < row1Pointer - 2; j++)
                {
                    res.Add(matrix[i][matrixRows - 1 - levelCounter - j]);
                }

                row1Pointer = row1Pointer - 2;
                column1Pointer = column1Pointer - 2;
                levelCounter++;
            }

            return res;
        }


        public List<string> wordSubsets(List<string> A, List<string> B)
        {
            var result = new List<string>() { };
            var subSetsString = string.Concat(string.Join("", B).OrderBy(c => c));

            foreach (var word in A)
            {
                var orderedWord = string.Concat(word.OrderBy(c => c));
                if (orderedWord.Contains(subSetsString))
                {
                    result.Add(word);
                }
            }

            return result;
        }

        public int MyAtoi(string str)
        {

            if (str == null || str == "") return 0;

            int minusFound = 0;
            int plusFound = 0;
            int res = 0;
            string r = "";

            for (int i = 0; i < str.Length; i++)
            {

                if (str[i] == '-')
                {
                    minusFound++;
                    if (i < str.Length - 1 && str[i + 1] >= '0' && str[i + 1] <= '9') continue;
                    else return 0;
                }
                else if (str[i] == '+')
                {
                    plusFound++;
                    if (i < str.Length - 1 && str[i + 1] >= '0' && str[i + 1] <= '9') continue;
                    else return 0;
                }
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
                    return -2147483648;
                else
                    return 2147483647;
            }

            if (minusFound >= 1) res = -1 * res;
            LinkedListNode<int> linkedListNode = new LinkedListNode<int>(1);
            return res;
        }

        public DataStructures.ListNode swapInPairs(ListNode head)
        {
            var result = head;

            int totalNode = 0;

            while (head != null)
            {
                totalNode++;
                head = head.next;
            }

            ListNode[] nodeArr = new ListNode[totalNode];

            head = result;
            int counter = 0;

            while (counter < totalNode)
            {
                nodeArr[counter++] = head;
                head = head.next;
            }

            int shiftValue = 3;

            for (int i = 0; i < counter; i++)
            {
                if (i == counter - 3)
                {
                    shiftValue = 2;
                }

                if (i % 2 == 0 && (i + shiftValue) < counter)
                {
                    nodeArr[i].next = nodeArr[i + shiftValue];
                }
                else
                {
                    nodeArr[i].next = nodeArr[i - 1];
                }
            }


            return result;
        }

        public string makeStringValid(string s)
        {
            var list = new List<char>();

            Stack<char> _stack = new Stack<char>();

            foreach (var ch in s)
            {
                if (ch == '(')
                {
                    _stack.Push(ch);
                }
                else if (ch == ')' && _stack.Count == 0)
                {
                    continue;
                }
                else if (ch == ')' && _stack.Count > 0)
                {
                    _stack.Pop();
                }

                list.Add(ch);
            }

            if (_stack.Count > 0)
            {
                while (_stack.Count == 0)
                {
                    list.IndexOf('(');
                    list.RemoveAt(list.IndexOf('('));
                    _stack.Pop();
                }
            }

            var result = new string(list.ToArray());
            return result;
        }

        public TreeNode lowestCommonAncestor(TreeNode root, int x, int y)
        {
            /*
             * 1) Both values are less than our root value.
             */
            if (x < root.val && y < root.val)
            {
                return lowestCommonAncestor(root.left, x, y);
            }

            /*
             * 2) Both values are greater than our root value.
             */
            if (x > root.val && y > root.val)
            {
                return lowestCommonAncestor(root.right, x, y);
            }

            /*
             * 3) One of x or y is equal to the root.
             * OR
             * 4) One of x or y is less than root and the other is greater than root.
             */
            return root;
        }

        public List<int> kSmallestElements(int[] elements, int k)
        {
            Stack<int> minElemStack = new Stack<int>();

            for (int i = 0; i < elements.Length; i++)
            {
                PushToMinStoneStack(minElemStack, elements[i], k);
            }
            var res = new List<int>();

            while (minElemStack.Count != 0)
            {
                res.Add(minElemStack.Pop());
            }

            return res;
        }

        private void PushToMinStoneStack(Stack<int> minElemStack, int element, int k)
        {
            Stack<int> backUpStack = new Stack<int>();

            if (minElemStack.Count == 0)
            {
                minElemStack.Push(element);
                return;
            }

            if (element > minElemStack.Peek() && minElemStack.Count == k)
            {
                return;
            }

            while (minElemStack.Count > 0 && minElemStack.Peek() > element)
            {
                backUpStack.Push(minElemStack.Pop());
            }

            minElemStack.Push(element);

            while (minElemStack.Count < k && backUpStack.Count > 0)
            {
                minElemStack.Push(backUpStack.Pop());
            }

        }

        public int[][] mergeOverlappingIntervals(int[][] A)
        {

            Stack<int> finalStack = new Stack<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (finalStack.Count == 0)
                {
                    finalStack.Push(A[i][0]);
                    finalStack.Push(A[i][1]);
                }
                else
                {
                    if (finalStack.Peek() >= A[i][0] && finalStack.Peek() < A[i][1])
                    {
                        finalStack.Pop();
                        finalStack.Push(A[i][1]);
                    }
                    else if (finalStack.Peek() < A[i][0])
                    {
                        finalStack.Push(A[i][0]);
                        finalStack.Push(A[i][1]);
                    }
                }
            }
            var res = new int[finalStack.Count / 2][];

            int counter = 0;
            while (finalStack.Count != 0)
            {
                int a = finalStack.Pop();
                int b = finalStack.Pop();
                res[counter++] = new int[] { b, a };
            }

            return res;
        }

        private Dictionary<int, string> digitToPossibleLetters = new Dictionary<int, string>() {
            { 0,"" }, {1,""    },{2,"abc" }, {3,"def" },{4,"ghi" },  {5,"jkl" }, {6,"mno" }, {7,"pqrs"}, {8,"tuv" },{9,"wxyz" }};

        public List<String> letterCombinations(String digits)
        {
            // When input string is empty
            if (digits.Length == 0)
            {
                return new List<String>();
            }

            List<String> mnemonics = new List<String>();
            exploreCombinations(0, new StringBuilder(), digits, mnemonics);
            return mnemonics;
        }

        // Helper function for recursively calculating the ans
        private void exploreCombinations(int currentDigit, StringBuilder partialMnemonic, string digits, List<String> mnemonics)
        {

            // Base Case - We have got an answer
            if (currentDigit == digits.Length)
            {
                mnemonics.Add(partialMnemonic.ToString());
                return;
            }

            char digitCharacter = digits[currentDigit];
            int digitAsInt = digitCharacter - '0';

            string letters = digitToPossibleLetters[digitAsInt];

            foreach (char possibleLetter in letters)
            {
                // 1.) Choose - Append the letter that this digit can materialize into
                partialMnemonic.Append(possibleLetter);

                // 2.) Explore - Recurse on the decision with changed state. We advance the digit we are working on.
                exploreCombinations(currentDigit + 1, partialMnemonic, digits, mnemonics);

                // 3.) Unchoose - We have returned to this stack frame of choice. Remove the choice, next loop will choose again.
                partialMnemonic.Remove(partialMnemonic.Length - 1, 1);
            }
        }

        public List<string> restoreIpAddresses(string rawIpString)
        {
            var res = new List<string>();
            restoreIpAddresses(new StringBuilder(), rawIpString, 1, res);
            res.ForEach(x => Console.WriteLine(x));
            return res;
        }

        public void restoreIpAddresses(StringBuilder partialIp, string remainingRawIPString, int position, List<string> result)
        {
            if (position == 4)
            {
                partialIp.Append(remainingRawIPString);
                result.Add(partialIp.ToString());
                return;
            }
            int remainingRawIPStringLength = remainingRawIPString.Length;
            int characterThatRemainingFieldCanHold = (4 - position) * 3;
            int minCharacterRequiredForNext = 4 - position;
            int minimumCharacterItShouldHave = 1;
            int maximumCharacterItCanHave = 3;

            if (characterThatRemainingFieldCanHold - remainingRawIPStringLength >= 0)
            {
                maximumCharacterItCanHave = remainingRawIPStringLength - minCharacterRequiredForNext > 0 ? 3 :
                                         remainingRawIPStringLength - minCharacterRequiredForNext;

            }
            else if (characterThatRemainingFieldCanHold - remainingRawIPStringLength < 0)
            {
                minimumCharacterItShouldHave = -1 * (characterThatRemainingFieldCanHold - remainingRawIPStringLength);
            }

            position += 1;
            for (int i = minimumCharacterItShouldHave; i <= maximumCharacterItCanHave; i++)
            {
                var sb = new StringBuilder(partialIp.ToString());
                sb.Append(remainingRawIPString.Substring(0, i) + '.');
                restoreIpAddresses(sb, remainingRawIPString.Substring(i), position, result);
            }
        }


        public List<String> restoreIpAddressesBSW(String rawIpString)
        {
            List<String> restoredIps = new List<String>();
            restoreIps(0, 0, new int[4], rawIpString, restoredIps);

            return restoredIps;
        }

        private void restoreIps(int progressIndex, int currentSegment, int[] ipAddressSegments, String rawIpString, List<String> restoredIps)
        {
            /*
              If we have filled 4 segments (0, 1, 2, 3) and we are on the 4th,
              we will only record an answer if the string was decomposed fully
            */
            if (currentSegment == 4 && progressIndex == rawIpString.Length)
            {
                restoredIps.Add(buildIpStringFromSegments(ipAddressSegments));
            }
            else if (currentSegment == 4)
            {
                return;
            }

            /*
              Generate segments to try, a segment can be 1 to 3 digits long.
            */
            for (int segLength = 1; segLength <= 3 && progressIndex + segLength <= rawIpString.Length; segLength++)
            {

                // Calculate 1 index past where the segment ends index-wise in the original raw ip string
                int onePastSegmentEnd = progressIndex + segLength;

                // Extract int value from our snapshot from the raw ip string
                String segmentAsString = rawIpString.Substring(progressIndex, onePastSegmentEnd);
                int segmentValue = int.Parse(segmentAsString);

                // Check the "snapshot's" validity - if invalid break iteration
                if (segmentValue > 255 || segLength >= 2 && segmentAsString[0] == '0')
                {
                    break;
                }

                // Add the extracted segment to the working segments
                ipAddressSegments[currentSegment] = segmentValue;

                // Recurse on the segment choice - when finished & we come back here, the next loop iteration will try another segment
                restoreIps(progressIndex + segLength, currentSegment + 1, ipAddressSegments, rawIpString, restoredIps);
            }
        }

        // Helper Function for building IP address from Integer
        private String buildIpStringFromSegments(int[] ipAddressSegments)
        {
            return ipAddressSegments[0] + "." + ipAddressSegments[1] + "." + ipAddressSegments[2] + "." + ipAddressSegments[3];
        }

        public List<List<int>> powerset(int[] inputSet)
        {
            var res = new List<List<int>>();
            res.Add(new List<int>() { });

            if (inputSet.Length == 0)
                return res;

            for (int i = 0; i < inputSet.Length; i++)
            {
                var superSubSetForCurrentItem = new List<List<int>>();
                AddSuperSetForCurrent(inputSet, superSubSetForCurrentItem, i, new List<int>() { inputSet[i] });
                res.AddRange(superSubSetForCurrentItem);
            }

            return res;

        }

        private void AddSuperSetForCurrent(int[] inputSet, List<List<int>> powerSet, int index, List<int> prefix)
        {
            powerSet.Add(prefix);
   
            if (index < inputSet.Length)
            {
                for (int j = index + 1; j < inputSet.Length; j++)
                {
                    var localPrefix = new List<int>(prefix);
                    localPrefix.Add(inputSet[j]);
                    AddSuperSetForCurrent(inputSet, powerSet, j, localPrefix);
                }
            }
        }


    }
}
