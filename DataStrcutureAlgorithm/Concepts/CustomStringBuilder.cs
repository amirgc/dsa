using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.Concepts
{
    public class CustomStringBuilder
    {

        public static int InitialCapacity = 10;
        public int Length { get; set; } = 0;

        char[] chars = new char[InitialCapacity];

        public CustomStringBuilder(string value)
        {
            Append(value);
        }

        public CustomStringBuilder Append(string value)
        {
            if (Length + value.Length > InitialCapacity)
            {
                ResizeArray();
            }

            foreach (char ch in value)
            {
                chars[Length] = ch;
                Length++;
            }

            return this;
        }

        private void ResizeArray()
        {
            InitialCapacity *= 2;
            var newChars = new char[InitialCapacity];
            int counter = 0;
            foreach (char ch in chars)
            {
                newChars[counter++] = ch;
            }
            chars = newChars;
        }

        public override string ToString()
        {
            return new string(chars, 0, Length);
        }
    }
}
