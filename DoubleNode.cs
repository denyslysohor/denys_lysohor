using System;
namespace MyRefList
{
    internal class DoubleNode : Node
    {
        internal Node prev;

        public DoubleNode(int vl, Node nxt, Node prv) : base(vl, nxt)
        {
            prev = prv;
        }

        public DoubleNode(int vl, Node nxt) : base(vl, nxt)
        {
            prev = null;
        }
 
        public DoubleNode(Node node) : base(node.value,node.next)
        {
            prev = null;
        }

        public DoubleNode(int value) : base(value)
        {
            value = value;
        }
    }
}
