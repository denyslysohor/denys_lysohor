using System;

namespace RegistrationForm
{
    public abstract class User
    {
        [RequiredField]
        public string Login { get; set; }
    }
}
