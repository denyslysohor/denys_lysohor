using System;
using System.Collections.Generic;
using System.Text;

namespace ShopInfoEF6App
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public int Count { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
