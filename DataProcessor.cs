using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabaFile
{
    class DataProcessor
    {
        private List<User> users;
        private List<Order> orders;

        public DataProcessor()
        {
            users = new List<User>();
            orders = new List<Order>();
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }
        public void RemoveUser(User user)
        {
            users.Remove(user);
        }

        public void RemoveOrder(Order order)
        {
            orders.Remove(order);
        }

        public string Print()
        {
            var printInfo = from user in users
                            join order in orders
                            on user.Id equals order.User_id
                            where user.Age > 18 && user.Age < 65 && order.Order_date > DateTime.Now.AddDays(-7)
                            orderby order.Order_date ascending
                            select new { order.Order_number, order.Order_date, user.Name, order.Total };
            string result = "";
            foreach(var temp in printInfo)
            {
                result += temp.Order_number + ";";
                result += temp.Order_date + ";";
                result += temp.Name + ";";
                result += temp.Total + ";";
                result += "\n";
            } 
            return result;
        }
    }
}
