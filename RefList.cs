using System;
using RefList;

namespace MyRefList
{
    public class RefList: IRefList
    {
        internal Node _head;

        public int count;

        public int this[int index] { get { return index; } set { if (value > 0) ; } }


        private int Count
        {
            get { return count; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Длина списка не может быть отрицательной!");
                }
                else
                {
                    count = value;
                    _head = null;
                }
            }
        }

        public virtual void Add(int value)
        {
            _head = new Node(value, _head);
            count++;
        }

        public void AddToEnd(int value)
        {
            Node newNode = new Node(value);
            if (_head != null)
            {
                Node hd = _head;
                while (hd.next != null) hd = hd.next;
                hd.next = newNode;
            }
            else
            {
                _head = newNode;
            }
            count++;
        }

        internal void DeleteByIndex(int index, Node current)
        {
            int end = 2;
            current = _head;
            if (index > count)
            {
                Console.WriteLine("Элемента с таким номером несуществует");
            }
            else if (index == 0)
            {
                _head = _head.next;
                count--;
            }
            else if (current.next.next == null && index == end)
            {
                current.next = null;
                count--;
            }
            else if (index == 1)
            {
                current.next = current.next.next;
                count--;
            }
            else
            {
                DeleteByIndex(index - 1, current.next);
            }
        }

        public void DeleteByValue(int value)
        {
            if (value == _head.value)
            {
                _head = _head.next;
            }
            else
            {
                Node hd = _head;
            }
            while (_head.next != null)
            {
                if (_head.next.value != value)
                {
                    _head = _head.next;
                }
                else
                {
                    _head.next = _head.next.next;
                }
            }
            count--;
        }

        public void IndexOf(int value)
        {
            Node temp = _head;
            while (temp != null)
            {
                if (temp.value == value)
                {
                    Console.Write(temp.value);
                }
                temp = temp.next;
            }
        }
    }
}
