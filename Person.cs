namespace Mediator
{
    public abstract class Person
    {
        private Mediator _mediator;

        protected Person(Mediator mediator)
        {
            _mediator = mediator;
        }
        
        public void Send(string message, Person reciever)
        {
            _mediator.Send(message, this, this);
        }
        public abstract void Notify(string message, Person reciever);
    }
}