using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaFile
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<User> users = await FileProcessor.GetUsersAsync();
            List<Order> orders = await FileProcessor.GetOrdersAsync();

            DataProcessor dP = new DataProcessor(users, orders);

           foreach(User user in users)
            {
                Console.WriteLine(user.Id+"|"+user.Name + "|" +user.Gender + "|" +user.Age);
            }
            Console.WriteLine();

            foreach (Order order in orders)
            {
                Console.WriteLine(order.Id + "|" +order.User_id + "|" +order.Order_number + "|" + order.Order_date + "|" + order.Total);
            }
            Console.WriteLine();
            Console.WriteLine(dP.GetResults());

            FileProcessor.SaveFile(dP.GetResults());

            Console.ReadKey();
        }
    }
}
