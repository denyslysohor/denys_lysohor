using System;

namespace RegistrationForm
{
    public class UserService
    {
        User[] users = new User[30];
        ExistUser lena = new ExistUser("lmao1", "Olena", 95);
        ExistUser denys = new ExistUser("denza500", "Denys", 27);
        ExistUser julia = new ExistUser("Jull", "Julia", 28);
        ExistUser dmitrii = new ExistUser("dimaxyi", "Dmitrii", 96);

        bool isConsist = false;

        public UserService()
        {
            users[0] = lena;
            users[1] = denys;
            users[2] = julia;
            users[3] = dmitrii;
        }

        public void Register(User user)
        {

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
