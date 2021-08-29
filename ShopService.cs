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
    public class ShopService : IShopService
    {
        private IWorkUnit Database { get; set; }
        private IMapper mapper;
        private IMapper mapperReverse;

        public ShopService(IWorkUnit database)
        {
            Database = database;
            mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<Shop, ShopDTO>()).CreateMapper();
            mapperReverse = new MapperConfiguration(cfg =>
                cfg.CreateMap<ShopDTO, Shop>()).CreateMapper();
        }
        public void Create(ShopDTO item)
        {
            Database.Shops.Create(mapperReverse.Map<ShopDTO, Shop>(item));
            Database.Save();
        }

        public void Delete(int id)
        {
            var data = Database.Shops.Get(id);
            if (data != null)
            {
                Database.Shops.Delete(id);
                Database.Save();
            }
        }

        public ShopDTO Get(int id)
        {
            return mapper.Map<Shop, ShopDTO>(Database.Shops.Get(id));
        }

        public IEnumerable<ShopDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Shop>, IEnumerable<ShopDTO>>(Database.Shops.GetAll());
        }
    }
}
