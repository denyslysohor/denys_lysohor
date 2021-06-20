using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LabaFile
{
    class FileProcessor
    {
        static public void SaveFile(string str)
        {
            try
            {

                using (StreamWriter writer = new StreamWriter(File.Open(@"result.txt", FileMode.OpenOrCreate)))
                {
                    writer.Write(str);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        static private async Task<string> ReadUserFileAsync()
        {
            string path = @"users.txt";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    return await sr.ReadToEndAsync();
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        static public async Task<List<User>> GetUsersAsync()
        {
            string str = await ReadUserFileAsync();
            List<User> users = new List<User>();
            string[] st = str.Split(';', '\n');

            int temp = 0;

            while (temp < st.Length-2)
            {
                int id = Convert.ToInt32(st[temp]);
                string name = st[temp + 1];
                string gender = st[temp + 2];
                uint age = Convert.ToUInt32(st[temp + 3]);
                users.Add(new User() { Id = id, Name = name, Gender = gender, Age = age });
                temp += 5;
            }

            return users;

        }
        static private async Task<string> ReadOrderFileAsync()
        {
            string path = @"orders.txt";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    return await sr.ReadToEndAsync();
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        static public async Task<List<Order>> GetOrdersAsync()
        {
            string str = await ReadOrderFileAsync();
            List<Order> orders = new List<Order>();
            string[] st = str.Split(';', '\n');

            int temp = 0;

            while (temp < st.Length - 2)
            {
                int id = Convert.ToInt32(st[temp]);
                int user_id = Convert.ToInt32(st[temp + 1]);
                string order_number = st[temp + 2];
                DateTime order_date = Convert.ToDateTime(st[temp + 3]);
                decimal total = Convert.ToDecimal(st[temp + 4]);
                orders.Add(new Order() { Id = id, User_id = user_id, Order_date = order_date, Order_number = order_number, Total = total });
                temp += 6;
            }

            return orders;

        }
    }
}
