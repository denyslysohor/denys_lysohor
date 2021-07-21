using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopApi.Models
{
    public class DB
    {
        private static DB _instance;
        public List<Laptop> Laptops { get; private set; }
        public List<Shop> Shops { get; private set; }
        private DB() 
        {
            Laptops = new List<Laptop> {new Laptop {Id = 1, Manufacturer = "Apple", Model = "MacBook Pro"}};
            Shops = new List<Shop> {new Shop {Id = 1, Laptop = Laptops[0], LaptopId = 1, Name = "Apple Store"}};
        }
        public static DB GetInstance()
        {
            if (_instance == null)
                _instance = new DB();
            return _instance;
        }
    }
}
