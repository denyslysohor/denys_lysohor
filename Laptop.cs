using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopApi.Models
{
    public class Laptop
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
