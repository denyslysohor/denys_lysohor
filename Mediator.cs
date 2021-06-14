using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public delegate void MessageRecievingDelegate(string message, string sender);
    public class Mediator
    {
        public event MessageRecievingDelegate MessageRecievingEvent;

        public void Send(string message, string sender)
        {
            if (MessageRecievingEvent != null)
            {
                Console.WriteLine($"{sender} sent message: {message}");
                MessageRecievingEvent(message, sender);
            }
        }
    }
}
