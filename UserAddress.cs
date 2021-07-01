namespace ShopInfoEF6App
{
    public class UserAddress
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CountryCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public User User { get; set; }

    }
}
