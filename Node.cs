using System;
namespace MyRefList
{
    internal class Node
    {
        public int value;
        public Node next;
        internal Node prev;

        public Node(int value)
        {
            value = value;
            next = null;
        }

        public Node(int vl, Node nxt)
        {
            value = vl;
            next = nxt;
        }
    }
}
