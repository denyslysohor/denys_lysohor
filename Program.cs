using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegistrationForm
{
    class Program
    {
        static void Main(string[] args)
        {
            ExistUser guy = new ExistUser("lmao21", "Ivan", 80);
            ExistUser guy1 = new ExistUser("lam", "Petro", 80);
            ExistUser guy2 = new ExistUser("", "Petro", 80);
            UserService userService = new UserService();
            Validate(guy);
            userService.Register(guy);
            Validate(guy1);
            userService.Register(guy1);
            Validate(guy2);
            userService.Register(guy2);
        }
        private static void Validate(User user)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            else
                Console.WriteLine("Пользователь прошел валидацию");
        }
    }
}
