using System;
using System.Collections.Generic;
using System.Threading;

namespace Thready.Publisher_Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<object> queue = new Queue<object>();

            Publisher publisher = new();
            Publisher publisher1 = new();

            Subscriber subscriber = new();

            Thread myThread = new Thread(Threading);
            myThread.Start();
            Thread myThread1 = new Thread(Threading1);
            myThread1.Start();

            void Threading()
            {
                publisher.Produce(queue);
                publisher1.Produce(queue);
                Thread.Sleep(200);

            }

            void Threading1()
            {
                subscriber.Consume(queue);
                Thread.Sleep(400);

            }
        }
    }
}
