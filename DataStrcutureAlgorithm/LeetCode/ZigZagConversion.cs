using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrcutureAlgorithm.LeetCode
{
    public class ZigZagConversion
    {
        public static string Convert(string s, int numRows)
        {

            int strLen = s.Length; int betnCol = numRows - 2; int columnLen = 0;
            int tempBetCol = betnCol;
            //col length;
            for (int i = 0; strLen > 0; i++)
            {
                if (betnCol == tempBetCol)
                {
                    strLen = strLen - numRows;
                    tempBetCol = 0;
                }
                else
                {
                    strLen = strLen - 1;
                    tempBetCol++;
                }
                columnLen++;
            }
            char[,] mat = new char[numRows, columnLen];

            strLen = s.Length; tempBetCol = betnCol; int tempRow = numRows; int col = 0; int row = 0;
            for (int i = 0; i < strLen;)
            {
                if (betnCol == tempBetCol)
                {
                    row = 0;
                    tempRow = numRows;
                    tempBetCol = 0;
                    while (tempRow > 0 && i < strLen)
                    {
                        mat[row, col] = s[i];
                        i++;
                        row++;
                        tempRow--;
                    }
                    col++;
                    row--;
                }
                else
                {
                    row--;
                    mat[row, col] = s[i];
                    tempBetCol++;
                    i++;
                    col++;
                }
            }

            string str = "";
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < columnLen; j++)
                {
                    if (mat[i, j] != default(char))
                    {
                        str += mat[i, j];
                    }
                }
            }
            return str;
        }

    }
}
