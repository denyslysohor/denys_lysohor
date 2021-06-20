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
            DataProcessor dP = new DataProcessor();

           List<User> users = await FileProcessor.GetUsersAsync();
           foreach(User user in users)
            {
                Console.WriteLine(user.Id+"|"+user.Name + "|" +user.Gender + "|" +user.Age);
                dP.AddUser(user);
            }
            Console.WriteLine();

            List<Order> orders = await FileProcessor.GetOrdersAsync();
            foreach (Order order in orders)
            {
                Console.WriteLine(order.Id + "|" +order.User_id + "|" +order.Order_number + "|" + order.Order_date + "|" + order.Total);
                dP.AddOrder(order);
            }
            Console.WriteLine();
            Console.WriteLine(dP.Print());

            FileProcessor.SaveFile(dP.Print());

            Console.ReadKey();
        }
    }
}
