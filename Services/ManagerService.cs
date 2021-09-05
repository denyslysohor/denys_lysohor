using AutoMapper;
using Managers.BLL;
using Managers.BLL.Interfaces;
using Managers.DAL.Entities;
using Managers.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.BLL.Services
{
    public class ManagerService : IManagerService
    {
        private Database Database;
        private IMapper mapper;
        private IMapper mapperReverse;
        private IManagerService object1;
        private IMapper object2;

        public ManagerService(IManagerService @object, IWorkUnit database)
        {
            database = (IWorkUnit)Database;
            mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<Manager, Manager>()).CreateMapper();
            mapperReverse = new MapperConfiguration(cfg =>
                cfg.CreateMap<Manager, Manager>()).CreateMapper();
        }

        public ManagerService(IManagerService object1, IMapper object2)
        {
            this.object1 = object1;
            this.object2 = object2;
        }

        public Manager GetById(int id)
        {
            return mapper.Map<Manager, Manager>(Database.Manangers.GetById(id));
        }

        public IEnumerable<Manager> GetAll()
        {
            return mapper.Map<IEnumerable<Manager>>(Database.Manangers.GetAll());
        }
    }
}
