using System;

namespace Mediator
{
    class User : Person
        {
            public User(Mediator mediator)
                : base(mediator)
            {
                
            }
 
            public override void Notify(string message, Person reciever)
            {
                Console.WriteLine($"Сообщение от пользователя, пользователю {reciever}: " + message);
            }
        }
        
        class VipUser : Person
        {
            public VipUser(Mediator mediator)
                : base(mediator)
            {
                
            }
 
            public override void Notify(string message, Person reciever)
            {
                Console.WriteLine($"Сообщение от VIP пользователя, пользователю {reciever}: " + message);
            }
        }

        class Admin : Person
        {
            public Admin(Mediator mediator)
                : base(mediator)
            {
                
            }
 
            public override void Notify(string message, Person reciever)
            {
                Console.WriteLine($"Сообщение от админа, пользователю {reciever}: " + message);
            }
        }
}