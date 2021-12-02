using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.LeetCode
{
    public class TicTacToe
    {
        private int[] rows;
        private int[] cols;
        private int[] diagonals;
        private int[] antiDiagonal;
        private int total;
        public TicTacToe(int n)
        {
            rows = new int[n];
            cols = new int[n];
            diagonals = new int[1];
            antiDiagonal = new int[n];
            this.total = n;
        }

        public int Move(int row, int col, int player)
        {
            int resetValue = player == 1 ? 1 : -1;
            rows[row] += resetValue;
            cols[col] += resetValue;

            if (col == row) diagonals[0] += resetValue;

            if ((col + row + 1) == this.total) antiDiagonal[0] += resetValue;

            if (checkIfPlayerWin(player, row, col)) return player;

            return 0;
        }

        bool checkIfPlayerWin(int playerId, int row, int col)
        {
            int winvalue = playerId == 1 ? this.total : -this.total;

            if (rows[row] == winvalue || cols[col] == winvalue || antiDiagonal[0] == winvalue || diagonals[0] == winvalue) return true;
            
            return false;
        }
    }
}
