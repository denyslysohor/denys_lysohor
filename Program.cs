using System;

namespace ShopInfoEF6App
{
    class Program
    {
        static void Main(string[] args)
        {
            AppContext context = new AppContext();
            
            context.Users.Add(new User()
            {
                FirstName = "Denys",
                LastName = "Lysohor",
                Age = 18,
                Email = "d.lysohor2002@icloud.com",
            });
            context.Users.Add(new User()
            {
                
                FirstName = "Dmitrii",
                LastName = "Ignaschevich",
                Age = 96,
                Email = "d.Ignaschevich@icloud.com",
            });
            context.Users.Add(new User()
            {
                
                FirstName = "Ken",
                LastName = "Markov",
                Age = 31,
                Email = "Markov11@icloud.com",
            });

          
            context.Categories.Add(new Category()
            {
                Name = "Eat",
            }) ;

            context.Categories.Add(new Category()
            {
                Name = "Clothing",
            });
          

            context.Products.Add(new Product
            {
                Name = "Apple",
                CategoryId = 1,
                Price = 15
            }) ;
            context.Products.Add(new Product
            {
                Name = "Bread",
                CategoryId = 1,
                Price = 10
            });
            context.Products.Add(new Product
            {
                Name = "Sneakers",
                CategoryId = 2,
                Price = 1500
            });
           
         
            context.Discounts.Add(new Discount() { 
                Value = 10            
            });
            context.Discounts.Add(new Discount()
            {
                Value = 20
            });
        

            context.Carts.Add(new Cart()
            {
                UserId = 1,
                DiscountId = 1
            }) ;
            context.Carts.Add(new Cart()
            {
                UserId = 2,
                DiscountId = 1
            }); context.Carts.Add(new Cart()
            {
                UserId = 3,
                DiscountId = 2
            });
          
          
            context.CartItems.Add(new CartItem()
            { 
                CartId = 1,
                ProductId = 1,
                Count = 3
            });
            context.CartItems.Add(new CartItem()
            {
                CartId = 2,
                ProductId = 2,
                Count = 5
            });
            context.CartItems.Add(new CartItem()
            {
                CartId = 3,
                ProductId = 3,
                Count = 1
            });

            context.UserAddresses.Add(new UserAddress()
            {
                UserId = 1,
                CountryCode = 11,
                State = "Actual",
                City = "Kiev",
                Address = "Svobodu 11",
                PhoneNumber = "0503212331"

            });
            context.UserAddresses.Add(new UserAddress()
            {
                UserId = 2,
                CountryCode = 11,
                State = "Actual",
                City = "Kharkov",
                Address = "Pobeda 23",
                PhoneNumber = "0663772333"

            });
            context.UserAddresses.Add(new UserAddress()
            {
                UserId = 3,
                CountryCode = 11,
                State = "Actual",
                City = "Kharkov",
                Address = "Naukova 14",
                PhoneNumber = "06732123678"

            });
            context.SaveChanges();
            
            foreach (User us in context.Users)
            {
                Console.WriteLine(us.Id + "|" + us.FirstName + "|" + us.LastName + "|" + us.Email);
            }
          
        }
    }
}