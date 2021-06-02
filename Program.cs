using System;

namespace Supervisor
{
    public class Subject
    {
        public event EventHandler eventHandler;
        public void Notify()
        {
            if (eventHandler != null)
            {
                eventHandler(this, EventArgs.Empty);
            }
        }
    }

    public class Observer
    {
        Subject subject;

        public Observer(Subject subject)
        {
            this.subject = subject;
        }
        public void EventTriggering(object sender, EventArgs ev)
        {
            Console.WriteLine("Событие затронуто");
        }

        public void Subscribing()
        {
            subject.eventHandler += EventTriggering;
        }

        public void UnSubscribing()
        {
            subject.eventHandler -= EventTriggering;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Subject sbj = new Subject();
            Observer observer = new Observer(sbj);

            observer.Subscribing();
            observer.Subscribing();

            sbj.Notify();

            observer.UnSubscribing();

            sbj.Notify();
        }
    }
}
