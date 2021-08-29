using Managers.DAL.EF;
using Managers.DAL.Entities;
using Managers.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.DAL.Repositories
{
    class ManagerRepository : IRepository<Manager>
    {
        private ManagerContext db;

        public ManagerRepository(ManagerContext db)
        {
            this.db = db;
        }
        public void Create(Manager item)
        {
            db.Managers.Add(item);
        }

        public void Delete(int id)
        {
            Manager manager = Get(id);
            if (manager != null)
                db.Managers.Remove(manager);
        }

        public Manager Get(int id)
        {
            return db.Managers.Find(id);
        }

        public IEnumerable<Manager> GetAll()
        {
            return db.Managers;
        }

        public void Update(Manager newItem, int id)
        {
            Manager manager = Get(id);
            if(manager != null)
            {
                manager.Id = newItem.Id;
                manager.FirstName = newItem.FirstName;
                manager.LastName = newItem.LastName;
                manager.IsEmployee = newItem.IsEmployee;
                
                db.Entry(manager).State = EntityState.Modified;
            }
        }
    }
}
