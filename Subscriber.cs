using System;
using System.Collections.Generic;

namespace Thready.Publisher_Subscriber
{
    class Subscriber
    {
        public void Consume(Queue<object> queue)
        {
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}
