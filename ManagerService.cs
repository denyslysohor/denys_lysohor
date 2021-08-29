using AutoMapper;
using Managers.BLL.DTO;
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
        private IWorkUnit Database { get; set; }
        private IMapper mapper;
        private IMapper mapperReverse;

        public ManagerService(IWorkUnit database)
        {
            Database = database;
            mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<Manager, ManagerDTO>()).CreateMapper();
            mapperReverse = new MapperConfiguration(cfg =>
                cfg.CreateMap<ManagerDTO, Manager>()).CreateMapper();
        }
        public void Create(ManagerDTO item)
        {
            Database.Manangers.Create(mapperReverse.Map<ManagerDTO, Manager>(item));
            Database.Save();
        }

        public void Delete(int id)
        {
            var data = Database.Manangers.Get(id);
            if (data != null)
            {
                Database.Manangers.Delete(id);
                Database.Save();
            }
        }

        public ManagerDTO Get(int id)
        {
            return mapper.Map<Manager, ManagerDTO>(Database.Manangers.Get(id));
        }

        public IEnumerable<ManagerDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Manager>, IEnumerable<ManagerDTO>>(Database.Manangers.GetAll());
        }
    }
}
