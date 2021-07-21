using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopApi.Models
{
    public class StoreContext
    {
        public List<Laptop> Laptops { get; set; }
        public List<Shop> Shops { get; set; }
    }
}
