using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Managers.BLL.DTO;
using Managers.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewManagers.Models;

namespace ViewManagers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobHistoriesController : ControllerBase
    {
        private IJobHistoryService service;
        private IMapper mapper;
        private IMapper mapperReverse;

        public JobHistoriesController(IJobHistoryService service)
        {
            this.service = service;
            mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<JobHistoryDTO, JobHistoryModel>()).CreateMapper();
            mapperReverse = new MapperConfiguration(cfg =>
                cfg.CreateMap<JobHistoryModel, JobHistoryDTO>()).CreateMapper();
        }


        [HttpGet]
        public IEnumerable<JobHistoryModel> GetJobHistory()
        {
            return mapper.Map<IEnumerable<JobHistoryDTO>, IEnumerable<JobHistoryModel>>(service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<JobHistoryModel> GetJobHistory(int id)
        {
            var jobHistory = service.Get(id);

            if (jobHistory == null)
            {
                return NotFound();
            }

            return mapper.Map<JobHistoryDTO, JobHistoryModel>(jobHistory);
        }

        [HttpPost]
        public void PostManager(JobHistoryModel jobHistory)
        {
            service.Create(mapperReverse.Map<JobHistoryModel, JobHistoryDTO>(jobHistory));
        }


        [HttpDelete("{id}")]
        public void DeleteJobHistory(int id)
        {
            service.Delete(id);
        }
    }
}
