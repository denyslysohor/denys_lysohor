using Managers.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.BLL.Interfaces
{
    public interface IJobHistoryService
    {
        IEnumerable<JobHistoryDTO> GetAll();
        JobHistoryDTO Get(int id);
        void Create(JobHistoryDTO item);
        void Delete(int id);
    }
}
