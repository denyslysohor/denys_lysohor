using System;
using RefList;

namespace MyRefList
{
    public class RefList : IRefList
    {
        private Node head;

        public int this[int index] { get { return index; } set { if (value > 0) ; } }

        public int count;

        public int Length
        {
            get { return count; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Длина списка не может быть отрицательной");
                }
                else
                {
                    count = value;
                    head = null;
                }
            }
        }

        public void Add(int value)
        {
            head = new Node(value, head);
            count++;
        }

        public void AddToEnd(int value)
        {
            Node newNode = new Node(value);
            if (head != null)
            {
                Node h = head;
                while (h.next != null) h = h.next;
                h.next = newNode;
            }
            else
            {
                head = newNode;
            }
            count++;
        }

        public void DeleteByIndex(int index, Node current)
        {
            current = head;
            if (index > count)
            {
                Console.WriteLine("Элемента с таким номером несуществует");
            }
            else if (index == 0)
            {
                head = head.next;
                count--;
            }
            else if (current.next.next == null && index == 2)
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
            if (value == head.value)
            {
                head = head.next;
            }
            else
            {
                Node h = head;
            }
            while (head.next != null)
            {
                if (head.next.value != value)
                {
                    head = head.next;
                }
                else
                {
                    head.next = head.next.next;
                }
            }
            count--;
        }

        public void IndexOf(int value)
        {
            Node temp = head;
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
