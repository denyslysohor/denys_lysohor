using Managers.DAL.EF;
using Managers.DAL.Entities;
using Managers.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.DAL.Repositories
{
    public class EFWorkUnit : IWorkUnit
    {
        private ManagerContext db;
        private JobHistoryRepository jobHistoryRepository;
        private ManagerRepository managerRepository;
        private ShopRepository shopRepository;

        public EFWorkUnit(DbContextOptions<ManagerContext> options)
        {
            db = new ManagerContext(options);
        }

        public IRepository<JobHistory> JobHistories
        {
            get
            {
                if(jobHistoryRepository == null)
                {
                    jobHistoryRepository = new JobHistoryRepository(db);
                }
                return jobHistoryRepository;
            }
        }

        public IRepository<Manager> Manangers
        {
            get
            {
                if (managerRepository == null)
                {
                    managerRepository = new ManagerRepository(db);
                }
                return managerRepository;
            }
        }

        public IRepository<Shop> Shops
        {
            get
            {
                if (shopRepository == null)
                {
                    shopRepository = new ShopRepository(db);
                }
                return shopRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
