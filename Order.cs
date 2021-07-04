using System;
using System.Collections.Generic;
using System.Text;

namespace ShopInfoEF6App
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DiscountId { get; set; }
        public int Total { get; set; }

        public User User { get; set; }
        public Discount Discount { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
