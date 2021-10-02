
using System;

namespace DataStrcutureAlgorithm.CrackingCodingInterview
{
    public static class Chapter1
    {
        public static bool isUniqueChars(string str)
        {
            int checker = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i] - 'a';

                if ((checker & (1 << val)) > 0)
                {
                    return false;
                }
                var test = (1 << val);
                checker |= (1 << val);
            }
            return true;
        }
    }

    public class Chapter1_Palindrome
    {
        public static bool IsPermutationOfPalindrome(string phrase)
        {
            int bitVector = createBitVector(phrase);
            return bitVector == 0 || checkExactlyOneBitSet(bitVector);
        }

        private static bool checkExactlyOneBitSet(int bitVector)
        {
            return (bitVector & (bitVector - 1)) == 0;
        }

        private static int createBitVector(string phrase)
        {
            int bitVector = 0;

            foreach (char ch in phrase)
            {
                int x = ch;
                bitVector = toggle(bitVector, x);
            }
            return bitVector;
        }

        private static int toggle(int bitVector, int index)
        {
            if (index < 0) return bitVector;
            Console.WriteLine($"Before bitVector: {Convert.ToString(bitVector, toBase: 2),4}");
            Console.WriteLine($"Before index: {Convert.ToString(index, toBase: 2),4}");
            
            int mask = 1 << index;
           
            Console.WriteLine($"Before mask: {Convert.ToString(mask, toBase: 2),4}");
            if ((bitVector & mask) == 0)
            {
                Console.WriteLine($"Before if bitVector: {Convert.ToString(bitVector, toBase: 2),4}");
                bitVector |= mask;
                Console.WriteLine($"After bitVector: {Convert.ToString(bitVector, toBase: 2),4}");
            }
            else
            {
                bitVector &= ~mask;
                Console.WriteLine($"After bitVector: {Convert.ToString(bitVector, toBase: 2),4}");
                Console.WriteLine($"After not mask : {Convert.ToString(~mask, toBase: 2),4}");
            }

            return bitVector;
        }
    }
}
