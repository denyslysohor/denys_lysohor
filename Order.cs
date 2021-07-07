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

        public virtual User User { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
