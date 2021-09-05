using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Managers.BLL;
using Managers.BLL.Interfaces;
using Managers.DAL.Entities;
using Managers.DAL.Interfaces;
using Nest;

namespace Managers.BLL.Services
{
    public class JobHistoryService : IJobHistoryService
    {
        private Database database;
        private IMapper mapper;
        private IMapper mapperReverse;

        public JobHistoryService(IJobHistoryService service, IMapper mapper)
        {
            mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<JobHistory, JobHistory>()).CreateMapper();
            mapperReverse = new MapperConfiguration(cfg =>
                cfg.CreateMap<JobHistory, JobHistory>()).CreateMapper();
        }

        public IEnumerable<JobHistory> GetAll()
        {
            return mapper.Map<IEnumerable<JobHistory>>(database.JobHistory.GetAll());
        }
    }
}
