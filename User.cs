using System;

namespace RegistrationForm
{
    [RequiredField]
    public abstract class User
    {
        public string Login { get; set; }

        public User(string login)
        {
            Login = login;
        }
    }
}
