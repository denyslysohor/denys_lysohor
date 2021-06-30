using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopInfoEF6App
{
    public class CartItem
    {
     
        public int CartId { get; set; }

        public int ProductId { get; set; }
        public int Count { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual Product Product { get; set; }
    }
}