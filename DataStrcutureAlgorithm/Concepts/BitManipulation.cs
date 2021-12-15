using System;

namespace DataStrcutureAlgorithm.Concepts
{
    public class BitManipulation
    {
        public int ShitftBit(int n)
        {
            return n << 1;
        }

        public static void BitWiseOperatorTest()
        {
            uint a = 5, b = 9; // a = 5(00000101), b = 9(00001001) 
            //   00000101
            //   00001001
            Console.WriteLine($"a =     {Convert.ToString(a, toBase: 2)}, b = {Convert.ToString(b, toBase: 2)}");
            Console.WriteLine($"a&b =   {Convert.ToString(a & b, toBase: 2)}"); // The result is  00000001 
            Console.WriteLine($"a|b =   {Convert.ToString(a | b, toBase: 2)}");  // The result is 00001101 
            Console.WriteLine($"a^b =   {Convert.ToString(a ^ b, toBase: 2)}"); // The result is  00001100 
            a = ~a;
            Console.WriteLine($"~a   =  {Convert.ToString(a, toBase: 2)}");   // The result is 11111010 
            Console.WriteLine($"b<<1 =  {Convert.ToString(b << 1, toBase: 2)}");  // The result is 00010010  
            Console.WriteLine($"b>>1 =  {Convert.ToString(b >> 1, toBase: 2)}");  // The result is 00000100 
        }
    }
}
