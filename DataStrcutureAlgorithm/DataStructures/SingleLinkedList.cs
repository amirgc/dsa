using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.DataStructures
{
    public class SingleLinkedList
    {
        string data;
        SingleLinkedList next = null;

        public SingleLinkedList(string d)
        {
            data = d;
        }

        public SingleLinkedList AddNodeToTail(string val)
        {
            var endNode = new SingleLinkedList(val);
            endNode.next = this;
            return endNode;
        }

        public void Print()
        {
            var test = this;
            while (test != null)
            {
                Console.Write(test.data + "->");
                test = test.next;
            }
        }
    }
}
