using System;
using System.Collections.Generic;
using System.IO;

namespace first
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Dmitrii");
            queue.Enqueue("Dmitrii1");
            queue.Enqueue("Dmitrii2");
            queue.Enqueue("Dmitrii3");
            queue.Enqueue("Dmitrii4");

            queue.Dequeue();

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}