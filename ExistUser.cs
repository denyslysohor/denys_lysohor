using System;

namespace RegistrationForm
{
    [RequiredField]
    public class ExistUser : User
    {
        [RequiredField]
        public string Firstname { get; set; }
        [RequiredField]
        public int Age { get; set; }
    }
}
