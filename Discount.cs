using System.Collections.Generic;

namespace ShopInfoEF6App
{
    public class Discount
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public ICollection<Cart> Carts { get; set; }
    }
}
