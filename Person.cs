using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public class Person
    {
        private string _name;
        private Mediator _mediator;

        public Person(Mediator mediator, string name)
        {
            _mediator = mediator;
            _name = name;
            _mediator.MessageRecievingEvent += Recieving;
        }

        public void Send(string message)
        {
            _mediator.Send(message, _name);
        }

        public void Recieving(string message, string sender)
        {
            if (sender != _name)
            {
                Console.WriteLine($"{_name} recieved message: \"{message}\", sender: {sender}");
            }
        }
    }
}
