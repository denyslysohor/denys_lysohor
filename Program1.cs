using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBank
{
    class Program
    {
        static void Main(string[] args)
        {

            Account account = new Account() { Name = "Jack", UserBalance = new Balance { Sum = 0 } };
            account.UserBalance.Notify += DisplayMessage;

            account.UserBalance.Put(120);
            account.UserBalance.Take(150);
            account.UserBalance.Take(50);
        }
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
