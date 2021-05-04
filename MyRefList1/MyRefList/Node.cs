using System;
namespace MyRefList
{
    public class Node
    {
        public int value;
        public Node next;

        public Node(int value)
        {
            value = value;
            next = null;
        }

        public Node(int i, Node n)
        {
            value = i;
            next = n;
        }
    }
}
