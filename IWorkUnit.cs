using Managers.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.DAL.Interfaces
{
    public interface IWorkUnit
    {
        IRepository<JobHistory> JobHistories { get; }
        IRepository<Manager> Manangers { get; }
        IRepository<Shop> Shops { get; }
        void Save();
    }
}
