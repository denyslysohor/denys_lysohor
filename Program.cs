using System;

namespace Mediator
{
    class Program
    {

        static void Main(string[] args)
        {
            Mediator mediator = new();

            Person p = new(mediator, "Denys");
            Person p1 = new(mediator, "Dmitrii");
            Person p2 = new(mediator, "Ivan");
            Person p3 = new(mediator, "Oleksandr");

            p.Send("Hi");
        }
    }
}
