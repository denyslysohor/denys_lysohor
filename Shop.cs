using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopApi.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LaptopId { get; set; }
        public Laptop Laptop { get; set; }
    }
}
