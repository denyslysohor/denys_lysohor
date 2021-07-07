using System.Collections.Generic;

namespace ShopInfoEF6App
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DiscountId { get; set; }

        public virtual Discount Discount { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}