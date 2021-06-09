using System;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new();
            
            Person user = new User(mediator);
            Person admin = new Admin(mediator);
            Person vipUser = new VipUser(mediator);
            
            mediator.User = user;
            mediator.Admin = admin;
            mediator.VipUser = vipUser;
            Console.WriteLine("Chat was started");
            Console.WriteLine();
            
            vipUser.Send("Hello to everyone!", admin);
            user.Send("Hello", vipUser);
            admin.Send("Hi", vipUser);
        }
    }
}