using AutoMapper;
using Managers.BLL;
using Managers.BLL.Interfaces;
using Managers.DAL.Entities;
using Managers.DAL.Interfaces;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.BLL.Services
{
    public class ShopService : IShopService
    {
        public object Shops { get; private set; }

        private IMapper mapper;
        private IMapper mapperReverse;
        private Database database;
        private ShopService shopService1;

        public ShopService(IShopService shopService, IMapper mapper)
        {
            shopService = shopService;
            mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<Shop, Shop>()).CreateMapper();
            mapperReverse = new MapperConfiguration(cfg =>
                cfg.CreateMap<Shop, Shop>()).CreateMapper();
        }

        public IEnumerable<Shop> GetAll()
        {
            return mapper.Map<IEnumerable<Shop>>(Shops.GetAll());
        }
    }
}
