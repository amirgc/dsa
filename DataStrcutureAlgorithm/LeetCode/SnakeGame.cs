using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.LeetCode
{
    public class SnakeGame
    {
        public int SnakesAndLadders(int[][] board)
        {
            int leastNumberOfMove = -1;
            int boardLength = board.Length;

            if (boardLength == 0)
                return leastNumberOfMove;

            Dictionary<int, int> shortestPathMaping = new Dictionary<int, int>();

            FindMePathToEnd(1, board, 0, shortestPathMaping);

            leastNumberOfMove = shortestPathMaping[boardLength * boardLength];

            return leastNumberOfMove;
        }

        private int[] GetNextMoveRange(int currentPosition, int n)
        {
            var res = new int[] { currentPosition + 1, Math.Min(currentPosition + 6, n * n) };
            return res;
        }

        private void FindMePathToEnd(int currentPosition, int[][] board, int currentMove, Dictionary<int, int> maping)
        {
            if (maping.ContainsKey(currentPosition))
            {
                if (maping[currentPosition] > currentMove)
                {
                    maping[currentPosition] = currentMove;
                }
            }
            else
            {
                maping[currentPosition] = currentMove;
            }

            if (currentPosition == board.Length * board.Length) return;

            var nextMoves = GetNextMoveRange(currentPosition, board.Length);

            
            bool isSpecialCellFound = false;
            for (int i = nextMoves[0]; i <= nextMoves[1]; i++)
            {
                int totalRows = board.Length, totalColumns = board.Length;

                int currR = totalRows - 1 - ((i - 1) / board.Length);

                int currC;
                if (currR % 2 == 0)
                    currC = totalColumns - 1 - (i - 1) % board.Length;
                else
                    currC = (i - 1) % board.Length;

                if (board[currR][currC] != -1 && board[currR][currC] != currentPosition)
                {
                    FindMePathToEnd(board[currR][currC], board, currentMove + 1, maping);
                    isSpecialCellFound = true;
                }

            }

            if (!isSpecialCellFound)
                FindMePathToEnd(nextMoves[1], board, currentMove + 1, maping);

        }
    }
}
