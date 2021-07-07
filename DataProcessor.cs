using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaFile
{
    class DataProcessor
    {
        private List<User> _users;
        private List<Order> _orders;

        public DataProcessor(List<User> users, List<Order> orders)
        {
            _users = users;
            _orders = new List<Order>();
        }

        public string GetResults()
        {
            var printInfo = from user in _users
                            join order in _orders
                            on user.Id equals order.User_id
                            where user.Age > 18 && user.Age < 65 && order.Order_date > DateTime.Now.AddDays(-7)
                            orderby order.Order_date ascending
                            select new { order.Order_number, order.Order_date, user.Name, order.Total };
            string result = String.Empty;
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
