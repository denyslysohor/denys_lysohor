using System;
using System.Collections;
using System.Collections.Generic;

namespace first
{
    public class Queue<T> : IQueue<T>, IEnumerable<T>
    {
        Node<T> head;
        Node<T> tail;
        int count;
        public int Count => count;

        public void Enqueue(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> tempNode = tail;
            tail = node;
            if (count == 0)
            {
                head = tail;
                count++;
            }
            else
            {
                tempNode.Next = tail;
                count++;
            }
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                try
                {
                    throw new Exception("Queue is empty");
                }
                catch
                {
                    Console.WriteLine("Error1");
                }
            }

            T output = head.Data;
            head = head.Next;
            count--;
            return output;
        }

        public T Peek()
        {
            if (count == 0)
            {
                try
                {
                    throw new Exception("Queue is empty");
                }
                catch
                {
                    Console.WriteLine("Error2");
                }
            }

            return head.Data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}