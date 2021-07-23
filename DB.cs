using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopApi.Models
{
    public class DB
    {
        public List<Laptop> Laptops { get; set; }
        public List<Shop> Shops { get; set; }

        public DB(List<Shop> shops, List<Laptop> laptops)
        {
            shops = Shops;
            laptops = Laptops;
        }
    }
}

