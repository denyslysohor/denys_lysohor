using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopInfoEF6App
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        

        public virtual Cart Cart { get; set; }
        public virtual ICollection<UserAddress> UserAddresses { get; set; }

        
    }
}