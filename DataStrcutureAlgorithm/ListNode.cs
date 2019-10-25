using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ListNode
    {
        internal class Node
        {
            public int val;
            public Node next;

            public Node(int val)
            {
                this.val = val;
            }
        }
        private Node head;
        private Node Tail;

        public void AddFirst(int val)
        {
            Node node = new Node(val);
            if (head == null)
            {
                head = Tail = node;
            }
            else
            {
                node.next = head;
                head = node;
            }

        }

        public void AddLast(int val)
        {
            Node new_node = new Node(val);
            if (head == null)
            {
                head = new_node;
                return;
            }

            new_node.next = null;

            Node last = head;
            while (last.next != null)
                last = last.next;
            last.next = new_node;
        }
        public void Print()
        {
            while (head != null)
            {
                Console.Write(head.val + "->");
                head = head.next;
            }
        }
    }
}
