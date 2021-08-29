using Managers.DAL.EF;
using Managers.DAL.Entities;
using Managers.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.DAL.Repositories
{
    class ShopRepository : IRepository<Shop>
    {
        private ManagerContext db;

        public ShopRepository(ManagerContext db)
        {
            this.db = db;
        }
        public void Create(Shop item)
        {
            db.Shops.Add(item);
        }

        public void Delete(int id)
        {
            Shop shop = Get(id);
            if (shop != null)
                db.Shops.Remove(shop);
        }

        public Shop Get(int id)
        {
            return db.Shops.Find(id);
        }

        public IEnumerable<Shop> GetAll()
        {
            return db.Shops;
        }

        public void Update(Shop newItem, int id)
        {
            Shop shop = Get(id);
            if (shop != null)
            {
                shop.Id = newItem.Id;
                shop.Name = newItem.Name;
                shop.Address = newItem.Address;

                db.Entry(shop).State = EntityState.Modified;
            }
        }
    }
}
