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

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
