using System;
using System.Reflection;

namespace RegistrationForm
{
    public class UserService
    {
        User[] users = new User[30];

        bool isConsist = false;

        public UserService()
        {

        }
        private static void Validate(User user)
        {
            var type = user.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                if (property.IsDefined(typeof(RequiredFieldAttribute)))
                {
                    if (property.GetValue(user) == null)
                    {
                        try
                        {
                            throw new Exception("Пользователь не прошел валидацию");
                        }
                        catch
                        {
                            Console.WriteLine("Заполнены не все поля");
                            break;
                        }
                    }
                }
            }
        }

        public void Register(User user)
        {
            Validate(user);
            foreach (User item in users)
            {
                if (item != null && user.Login == item.Login)
                {
                    isConsist = true;
                    try
                    {
                        throw new Exception("Array consists this user!");
                    }
                    catch
                    {
                        Console.WriteLine("Error has been detected...");
                        break;
                    }
                    finally
                    {
                        Console.WriteLine("This user exists");
                    }
                }
            }

            for (int i = 0; i < users.Length; i++)
            {
                if (users[i] == null && isConsist == false)
                {
                    users[i] = user;
                }
            }

            switch (isConsist)
            {
                case false:
                    Console.WriteLine($"User has been added: {user.Login}");
                    Console.WriteLine();
                    break;
            }
        }
    }
}
