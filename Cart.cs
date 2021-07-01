using System.Collections.Generic;

namespace ShopInfoEF6App
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DiscountId { get; set; }

        public Discount Discount { get; set; }

        public User User { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
