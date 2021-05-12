using System;
namespace MyRefList
{
    public class DoubleRefList : RefList
    {
        internal DoubleNode _head;

        public void ReftoDRef(RefList refList)
        {
            _head = new DoubleNode(refList._head);
            DoubleNode previous = _head;
            DoubleNode current = (DoubleNode)refList._head.next;

            for (int i = 1; i < refList.count; i++)
            {
                current.prev = previous;
                previous = current;
                current = (DoubleNode)current.next;
            }

           void Add(int value)
           {
                DoubleNode newDoubleNode = new DoubleNode(value)
                {
                    next = _head
                };
                    _head.next = newDoubleNode;
                _head.prev = newDoubleNode;
                _head = newDoubleNode;
                count++;
           }

            void AddToEnd(int value)
            {
                DoubleNode new_Node = new DoubleNode(value);
                new_Node.value = value;
                new_Node.next = null;
                new_Node.prev = null;
                if (_head == null)
                {
                    _head = new_Node;
                }
                else
                {
                    DoubleNode temp = _head;
                    while (temp.next != null)
                        temp = (DoubleNode)temp.next;
                    temp.next = new_Node;
                    new_Node.prev = temp;
                    count++;
                }

                void DeleteByIndex(int index, DoubleNode value)
                {
                    DoubleNode current = _head;
                    if (_head == null || index <= 0)
                        return;
                    for (int i = 1; current != null && i < index; i++)
                    {
                        current = (DoubleNode)current.next;
                    }

                    if (current == null)
                        return;
                    DeleteByValue(current);
                }

                void DeleteByValue(DoubleNode value)
                {
                    if (_head == null || value == null)
                    {
                        return;
                    }

                    if (_head == value)
                    {
                        _head = (DoubleNode)value.next;
                        _ = _head.prev == null;
                    }

                    if (value.next != null)
                    {
                        value.next.prev = value.prev;
                    }

                    if (value.prev != null)
                    {
                        value.prev.next = value.next;
                    }
                    count--;
                }

                void IndexOf(int value)
                {
                    base.IndexOf(value);
                }
            }
        }
    }
}
