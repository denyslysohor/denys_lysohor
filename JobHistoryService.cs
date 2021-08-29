using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Managers.BLL.DTO;
using Managers.BLL.Interfaces;
using Managers.DAL.Entities;
using Managers.DAL.Interfaces;

namespace Managers.BLL.Services
{
    public class JobHistoryService : IJobHistoryService
    {
        private IWorkUnit Database { get; set; }
        private IMapper mapper;
        private IMapper mapperReverse;

        public JobHistoryService(IWorkUnit database)
        {
            Database = database;
            mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<JobHistory, JobHistoryDTO>()).CreateMapper();
            mapperReverse = new MapperConfiguration(cfg =>
                cfg.CreateMap<JobHistoryDTO, JobHistory>()).CreateMapper();
        }
        public void Create(JobHistoryDTO item)
        {
            Database.JobHistories.Create(mapperReverse.Map<JobHistoryDTO, JobHistory>(item));
            Database.Save();
        }

        public void Delete(int id)
        {
            var data = Database.JobHistories.Get(id);
            if (data != null)
            {
                Database.JobHistories.Delete(id);
                Database.Save();
            }
        }

        public JobHistoryDTO Get(int id)
        {
            return mapper.Map<JobHistory, JobHistoryDTO>(Database.JobHistories.Get(id));
        }

        public IEnumerable<JobHistoryDTO> GetAll()
        {
            return mapper.Map<IEnumerable<JobHistory>, IEnumerable<JobHistoryDTO>>(Database.JobHistories.GetAll());
        }
    }
}
