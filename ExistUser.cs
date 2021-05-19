using System;
namespace RegistrationForm
{
    [RequiredField]
    public class ExistUser : User
    {
        public string Firstname { get; set; }
        public int Age { get; set; }
        public ExistUser(string login, string firstname, int age): base(login)
        {
            Firstname = firstname;
            Age = age;
        }
    }
}
