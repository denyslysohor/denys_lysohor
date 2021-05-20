using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace RegistrationForm
{
    class Program
    {
        static void Main(string[] args)
        {
            ExistUser guy1 = new ExistUser { Login = "lmao11", Firstname = "Denys", Age = 80 };
            ExistUser guy3 = new ExistUser { Login = "lmao11", Firstname = "Denys", Age = 80 };
            ExistUser guy4 = new ExistUser { Login = "lmao112", Firstname = "Denys", Age = 80 };
            ExistUser guy5 = new ExistUser { Login = "lmao111", Firstname = "Denys", Age = 80 };
            ExistUser guy2 = new ExistUser { Firstname = "Ivan", Age = 80  };
            UserService userService = new UserService();
            userService.Register(guy1);
            userService.Register(guy2);
            userService.Register(guy5);
            userService.Register(guy4);
            userService.Register(guy3);
        }
    }
}
