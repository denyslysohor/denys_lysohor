using System;

namespace Consumer_Producer
{
    public class CustomEventArgs : EventArgs
        {
            public string Message { get; set; }
            public CustomEventArgs(string message)
            {
                Message = message;
            }
        }

        class Publisher
        {
            public event EventHandler<CustomEventArgs> RaiseCustomEvent;

            public void InvokeEvent()
            {
                RaiseEvent(new CustomEventArgs("Событие сбылось"));
            }

            public void RaiseEvent(CustomEventArgs ev)
            {
                EventHandler<CustomEventArgs> raiseEvent = RaiseCustomEvent;

                if (raiseEvent != null)
                {
                    ev.Message += $" {DateTime.UtcNow}";

                    raiseEvent(this, ev);
                }
            }
        }

        class Subscriber
        {
            private string _id { get; }

            public Subscriber(string id, Publisher publisher)
            {
                _id = id;

                publisher.RaiseCustomEvent += HandleEvent;
            }

            void HandleEvent(object sender, CustomEventArgs ev)
            {
                Console.WriteLine($"{_id} получил сообщение: {ev.Message}");
            }
        }
    class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();

            Subscriber subscriber = new Subscriber("Читатель", publisher);
            Subscriber subscriber1 = new Subscriber("Читатель1", publisher);
            Subscriber subscriber2 = new Subscriber("Читатель2", publisher);

            publisher.InvokeEvent();
        }
    }
}
