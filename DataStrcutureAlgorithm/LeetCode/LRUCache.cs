using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.LeetCode
{
    public class LRUCache
    {
        public class DLinkedNode
        {
            public int key { get; set; }
            public int value { get; set; }
            public DLinkedNode prev { get; set; }
            public DLinkedNode next { get; set; }
        }
        private int size;
        private int capacity;
        private DLinkedNode head, tail;

        private void addNode(DLinkedNode node)
        {
            /**
             * Always add the new node right after head.
             */
            node.prev = head;
            node.next = head.next;

            head.next.prev = node;
            head.next = node;
        }

        private void removeNode(DLinkedNode node)
        {
            /**
             * Remove an existing node from the linked list.
             */
            DLinkedNode prev = node.prev;
            DLinkedNode next = node.next;

            prev.next = next;
            next.prev = prev;
        }

        private void moveToHead(DLinkedNode node)
        {
            /**
             * Move certain node in between to the head.
             */
            removeNode(node);
            addNode(node);
        }

        private DLinkedNode popTail()
        {
            /**
             * Pop the current tail.
             */
            DLinkedNode res = tail.prev;
            removeNode(res);
            return res;
        }

        private Dictionary<int, DLinkedNode> cache = new Dictionary<int, DLinkedNode>();

        public LRUCache(int capacity)
        {
            this.size = 0;
            this.capacity = capacity;

            head = new DLinkedNode();
            tail = new DLinkedNode();

            head.next = tail;
            tail.prev = head;
        }

        public int Get(int key)
        {
            if (!cache.ContainsKey(key)) return -1;
            DLinkedNode node = cache[key];
            // move the accessed node to the head;
            moveToHead(node);

            return node.value;
        }

        public void Put(int key, int value)
        {
            DLinkedNode node = new DLinkedNode();

            if (!cache.ContainsKey(key))
            {
                DLinkedNode newNode = new DLinkedNode();
                newNode.key = key;
                newNode.value = value;

                cache.Add(key, newNode);
                addNode(newNode);

                ++size;

                if (size > capacity)
                {
                    // pop the tail
                    DLinkedNode tail = popTail();
                    cache.Remove(tail.key);
                    --size;
                }
            }
            else
            {
                // update the value.
                node = cache[key];
                node.value = value;
                moveToHead(node);
            }
        }
    }
}
