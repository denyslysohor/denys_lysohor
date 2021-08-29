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
    public class ManagersController : ControllerBase
    {

        private IManagerService service;
        private IMapper mapper;
        private IMapper mapperReverse;

        public ManagersController(IManagerService service)
        {
            this.service = service;
            mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<ManagerDTO, ManagerModel>()).CreateMapper();
            mapperReverse = new MapperConfiguration(cfg =>
                cfg.CreateMap<ManagerModel, ManagerDTO>()).CreateMapper();
        }
        
        [HttpGet]
        [Route("Index/{page?}")]
        public IndexViewModel<ManagerModel> Index(int page = 1)
        {
            int pageSize = 3;   

            IEnumerable<ManagerModel> source = GetManagers();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel<ManagerModel> viewModel = new IndexViewModel<ManagerModel>
            {
                PageViewModel = pageViewModel,
                Items = items
            };
            return viewModel;
        }

        [HttpGet]
        public IEnumerable<ManagerModel> GetManagers()
        {
            return mapper.Map<IEnumerable<ManagerDTO>, IEnumerable<ManagerModel>>(service.GetAll());
        }
        
        [HttpGet("{id}")]
        public ActionResult<ManagerModel> GetManager(int id)
        {
            var manager = service.Get(id);

            if (manager == null)
            {
                return NotFound();
            }

            return mapper.Map<ManagerDTO, ManagerModel>(manager);
        }
        
        [HttpPost]
        public void PostManager(ManagerModel manager)
        {
            service.Create(mapperReverse.Map<ManagerModel, ManagerDTO>(manager));
        }


        [HttpDelete("{id}")]
        public void DeleteManager(int id)
        {
            service.Delete(id);
        }
    }
}
