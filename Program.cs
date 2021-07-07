using System;
using System.Linq;

namespace ShopInfoEF6App
{
    class Program
    {
        static void Main(string[] args)
        {
            AppContext context = new AppContext();
            
            Console.WriteLine("--------------------Query 1:-----------------");
            
             var query1 = ((IQueryable<Product>)context.Products)
                 .Join((IQueryable<Category>)context.Categories,
                        product => product.CategoryId,
                        category => category.Id,
                        (product, caregory) => new
                        {
                            ProductName = product.Name,
                            CategoryName = caregory.Name,
                            Price = product.Price
                        });

             foreach (var item in query1)
             {
                 Console.WriteLine(item.ToString());
             }

            Console.WriteLine("--------------------Query 2:-----------------");
            
            var query2 = from T1 in context.Products
                         join T2 in context.Categories on T1.CategoryId equals T2.Id
                         group T1 by new { T2.Name } into g
                         select new
                         {
                             CategoryName = g.Key.Name,
                             TotalPrice = g.Sum(t3 => t3.Price)
                         };
                         
            foreach (var item in query2)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("--------------------Query 3:-----------------");
            
            var query3 = from users in context.Users
                         join orders in context.Orders on users.Id equals orders.UserId
                         join discounts in context.Discounts on orders.DiscountId equals discounts.Id
                         group new { orders, discounts} by new { users.FirstName, users.LastName} into g
                         select new
                         {
                             FirstName = g.Key.FirstName,
                             LastName = g.Key.LastName,
                             TotalPrice = g.Sum(t=>t.orders.Total),
                             TotalDiscount = g.Sum(t1=>t1.discounts.Value) * g.Sum(t => t.orders.Total)/100
                         };

            foreach (var item in query3)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("--------------------Query 4:-----------------");

            var query4 = from T1 in context.Products
                         join T2 in context.Categories on T1.CategoryId equals T2.Id
                         join T3 in context.OrderItems on T1.Id equals T3.ProductId
                         group T3 by new { ProductName = T1.Name, CategoryName = T2.Name } into g
                         select new
                         {
                             ProductName = g.Key.ProductName,
                             CategoryName = g.Key.CategoryName,
                             SoldCount = g.Sum(s=>s.Count)
                         };
            foreach (var item in query4)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("--------------------Query 5:-----------------");

            var query5 = from T1 in context.Products
                         join T2 in context.Categories on T1.CategoryId equals T2.Id
                         join T3 in context.CartItems on T1.Id equals T3.ProductId
                         group T3 by new { ProductName = T1.Name, CategoryName = T2.Name } into g
                         select new
                         {
                             ProductName = g.Key.ProductName,
                             CategoryName = g.Key.CategoryName,
                             CartCount = g.Sum(s => s.Count)
                         };

            foreach (var item in query5)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("--------------------Query 6:-----------------");

            var query6 = from T1 in query4
                         join T2 in query5 on T1.ProductName equals T2.ProductName into ps
                         from T2 in ps.DefaultIfEmpty()
                         select new
                         {
                             ProductName = T1.ProductName,
                             CategoryName = T1.CategoryName,
                             TotalCount = T1.SoldCount + T2.CartCount
                         };
            foreach (var item in query6)
            {
                
                Console.WriteLine(item.ToString());
            }
            
        }
        static void Init(AppContext context)
        {
            context.Users.Add(new User()
            {
                FirstName = "Denys",
                LastName = "Lysohor",
                Age = 18,
                Email = "d.lysohor2002@icloud.com",
            });
            context.SaveChanges();
            context.Users.Add(new User()
            {

                FirstName = "Max",
                LastName = "Lorenzo",
                Age = 25,
                Email = "m.lorenzo@icloud.com",
            });

            context.Users.Add(new User()
            {

                FirstName = "Ken",
                LastName = "Markov",
                Age = 31,
                Email = "k.markov11@icloud.com",
            });

            context.SaveChanges();
            context.Categories.Add(new Category()
            {
                Name = "Eat",
            });

            context.Categories.Add(new Category()
            {
                Name = "Clothing",
            });

            context.SaveChanges();
            context.Products.Add(new Product
            {
                Name = "Apple",
                CategoryId = 2,
                Price = 15
            });
            context.Products.Add(new Product
            {
                Name = "Bread",
                CategoryId = 2,
                Price = 10
            });
            context.Products.Add(new Product
            {
                Name = "Sneakers",
                CategoryId = 1,
                Price = 1500
            });

            context.SaveChanges();
            context.Discounts.Add(new Discount()
            {
                Value = 10
            });
            context.Discounts.Add(new Discount()
            {
                Value = 20
            });

            context.SaveChanges();
            context.Carts.Add(new Cart()
            {
                UserId = 1,
                DiscountId = 1
            });
            context.Carts.Add(new Cart()
            {
                UserId = 2,
                DiscountId = 1
            }); 
            context.Carts.Add(new Cart()
            {
                UserId = 3,
                DiscountId = 2
            });

            context.SaveChanges();
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
            context.SaveChanges();
            context.UserAddresses.Add(new UserAddress()
            {
                UserId = 1,
                CountryCode = 11,
                State = "Actual",
                City = "Kyiv",
                Address = "Svobodu 11",
                PhoneNumber = "0503212331"

            });
            context.UserAddresses.Add(new UserAddress()
            {
                UserId = 2,
                CountryCode = 11,
                State = "Actual",
                City = "Kharkiv",
                Address = "Pobeda 23",
                PhoneNumber = "0663772333"

            });
            context.UserAddresses.Add(new UserAddress()
            {
                UserId = 3,
                CountryCode = 11,
                State = "Actual",
                City = "Kharkiv",
                Address = "Naukova 14",
                PhoneNumber = "06732123678"

            });
            context.SaveChanges();
        }
    }
}