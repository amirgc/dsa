using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrcutureAlgorithm.LeetCode
{
    public class StringToInteger
    {
        public static int MyAtoi(string str)
        {

            if (str == null || str == "") return 0;

            int minusFound = 0;
            int plusFound = 0;
            int res = 0;
            string r = "";

            for (int i = 0; i < str.Length; i++)
            {

                if (str[i] == '-') minusFound++;
                else if (str[i] == '+') plusFound++;
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
                    res= (int)(-1 * Math.Pow(2, 32));
                else
                  res= (int)Math.Pow(2, 31);
                return res;
            }

            if (minusFound >= 1) res = -1 * res;

            return res;
        }
    }
}
