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
    public class ShopsController : ControllerBase
    {
        private IShopService service;
        private IMapper mapper;
        private IMapper mapperReverse;

        public ShopsController(IShopService service)
        {
            this.service = service;
            mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<ShopDTO, ShopModel>()).CreateMapper();
            mapperReverse = new MapperConfiguration(cfg =>
                cfg.CreateMap<ShopModel, ShopDTO>()).CreateMapper();
        }

        // GET: api/Shops
        [HttpGet]
        public IEnumerable<ShopModel> GetShop()
        {
            return mapper.Map<IEnumerable<ShopDTO>,IEnumerable<ShopModel>>(service.GetAll());
        }
       
        [HttpGet("{id}")]
        public ActionResult<ShopModel> GetShop(int id)
        {
            var shop = service.Get(id);

            if (shop == null)
            {
                return NotFound();
            }

            return mapper.Map<ShopDTO, ShopModel>(shop);
        }

        [HttpPost]
        public void PostShop(ShopModel shop)
        {
            service.Create(mapperReverse.Map<ShopModel, ShopDTO>(shop));
        }


        [HttpDelete("{id}")]
        public void DeleteShop(int id)
        {
            service.Delete(id);
        }
    }
}
