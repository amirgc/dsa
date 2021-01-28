using System;
using System.Collections.Generic;

namespace DataStrcutureAlgorithm.DataStructures
{
    public class HashmapLinkedList
    {
        private static int ARRAY_SIZE = 20;
        internal class HashNode
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }

        LinkedList<HashNode>[] linkedLists = new LinkedList<HashNode>[ARRAY_SIZE];

        public void Add(object key, object value)
        {
            var newNode = new HashNode
            {
                Key = key,
                Value = value
            };

            int hashvalue = GetHash(key);
            int index = hashvalue % ARRAY_SIZE;

            if (linkedLists[index] == null)
            {
                linkedLists[index] = new LinkedList<HashNode>();
            }

            linkedLists[index].AddLast(newNode);
        }

        public object GetValue(object key)
        {
            int hashvalue = GetHash(key);
            int index = hashvalue % ARRAY_SIZE;
            var list = linkedLists[index];

            if (list == null)
            {
                return null;
            }

            foreach (var node in list)
            {
                if (node.Key.Equals(key))
                {
                    return node.Value;
                }
            }

            return null;
        }


        public void printHashMap()
        {

            Console.WriteLine("==============================================");
            int index = 0;

            while (index < ARRAY_SIZE)
            {
                LinkedList<HashNode> mainNode = this.linkedLists[index];

                if (mainNode != null)
                {

                    for (LinkedListNode<HashNode> node = mainNode.First; node != null; node = node.Next)
                    {

                        Console.WriteLine(node.Value.Key.ToString() + " -> ");
                        Console.WriteLine(node.Value.Value.ToString());
                    }


                    Console.WriteLine("");
                }
            }
        }
        protected int GetHash(object key)
        {
            return key.GetHashCode();
        }

    }
}
