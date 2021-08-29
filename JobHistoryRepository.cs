using Managers.DAL.EF;
using Managers.DAL.Entities;
using Managers.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.DAL.Repositories
{
    class JobHistoryRepository : IRepository<JobHistory>
    {
        private ManagerContext db;

        public JobHistoryRepository(ManagerContext db)
        {
            this.db = db;
        }

        public void Create(JobHistory item)
        {
            db.JobHistories.Add(item);
        }

        public void Delete(int id)
        {
            JobHistory jobHistory = Get(id);
            if (jobHistory != null)
                db.JobHistories.Remove(jobHistory);
        }

        public JobHistory Get(int id)
        {
            return db.JobHistories.Find(id);
        }

        public IEnumerable<JobHistory> GetAll()
        {
            return db.JobHistories;
        }

        public void Update(JobHistory newItem, int id)
        {
            JobHistory jobHistory = Get(id);
            if(jobHistory != null)
            {
                jobHistory.Id = newItem.Id;
                jobHistory.StartDate = newItem.StartDate;
                jobHistory.FinishDate = newItem.FinishDate;
                jobHistory.ManagerId = newItem.ManagerId;
                jobHistory.ShopId = newItem.ShopId;
            }
        }
    }
}
