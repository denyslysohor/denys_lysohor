using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopApi.Models
{
    public class DB
    {
        private static DB _instance;
        internal List<Laptop> Laptops { get; set; }
        internal List<Shop> Shops { get; set; }
        private DB(List<Shop> Shops, List<Laptop> Laptops) 
        {
            Laptops = Laptops = new List<Laptop> {new Laptop {Id = 1, Manufacturer = "Apple", Model = "MacBook Pro", ShopId = 1}};
            Shops = Shops = new List<Shop> {new Shop {Id = 1, Name = "Apple Store"}};
        }
        public static DB GetInstance()
        {
            if (_instance == null)
                _instance = new DB(new List<Shop>(), new List<Laptop>());
            return _instance;
        }
    }
}
