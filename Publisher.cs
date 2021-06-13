using System;
using System.Collections.Generic;

namespace Thready.Publisher_Subscriber
{
    class Publisher
    {
        static object locker = new object();

        public void Produce(Queue<object> queue)
        {
            lock (locker)
            {
                for (int i = 0; i < 2; i++)
                {
                    Random random = new();
                    queue.Enqueue(random.Next(1, 5));
                }
            }
        }
    }
}
