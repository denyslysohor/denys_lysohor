using System.Collections.Generic;

namespace ShopInfoEF6App
{
    public class Discount
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}