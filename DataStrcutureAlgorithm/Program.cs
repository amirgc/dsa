using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            //int a = -1;
            //string b = a.ToString();
            //char[] arr = b.ToArray();
            //arr = arr.Reverse().ToArray();
            //b = new string(arr);

            //int[] ab = new int[] { 1, 3, 45, 66, 5, 6, 3, 10 };

            //print(ab);
            //System.Console.WriteLine();
            //ab = MergeSortClass.MergeSort(ab);
            //print(ab);

            int intValue = StringToInteger.MyAtoi("2147483648");
            Console.Read();
        }
        public static void print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + ",");
        }

        public static int Reverse(int x)
        {
            string intStr;
            string minus;


            if (x < 0) { minus = "-"; x = -1 * x; }
            else minus = "";
            intStr = x.ToString();
            int len = intStr.Length;

            //loop
            char temp;

            char[] arr = intStr.ToArray();

            for (int i = 0; i < len / 2; i++)
            {
                temp = arr[i];
                arr[i] = arr[len - 1 - i];
                arr[len - 1 - i] = temp;
            }

            intStr = new string(arr);
            intStr = minus + intStr;

            return Convert.ToInt32(intStr);

        }
    }
}
