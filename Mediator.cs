namespace Mediator
{
    public class Mediator
    {
        public Person User { get; set; }
        public Person Admin { get; set; }
        public Person VipUser { get; set; }

        public void Send(string msg, Person colleague, Person reciever)
        {
            if (User == colleague)
            {
                User.Notify(msg, reciever);
            }

            else if (VipUser == colleague)
            {
                VipUser.Notify(msg, reciever);
            }

            else if (Admin == colleague)
            {
                Admin.Notify(msg, reciever);
            }
        }
    }
}