using Microsoft.AspNetCore.Mvc;
using System;
using LaptopApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaptopApi.Controllers
{
    //[Route("api/[Shop]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        DB db = DB.GetInstance();

        // GET: api/<ShopController>
        [Route("api/Shop")]
        [HttpGet]
        public IEnumerable<Shop> GetShops()
        {
            return db.Shops;
        }

        // GET api/<ShopController>/5
        [HttpGet("{id}")]
        [Route("api/Shop/{id}")]
        public Shop GetShop(int id)
        {
            Shop shop = db.Shops.Where(l => l.Id == id).FirstOrDefault();
            return shop;
        }

        // POST api/<ShopController>
        [HttpPost]
        [Route("api/CreateShop")]
        public void CreateShop([FromBody] Shop shop)
        {
            db.Shops.Add(shop);
        }

        // PUT api/<ShopController>/5
        [HttpPut("{id}")]
        [Route("api/UpdateShop/{id}")]
        public void UpdateShop(int id, [FromBody] Shop shop)
        {
            int index = db.Shops.IndexOf(db.Shops.Where(l => l.Id == id).FirstOrDefault());
            db.Shops[index] = shop;
        }

        // DELETE api/<ShopController>/5
        [HttpDelete("{id}")]
        [Route("api/DeleteShop/{id}")]
        public void DeleteShop(int id)
        {
            Shop shop = db.Shops.Where(l => l.Id == id).FirstOrDefault();
            if (shop != null)
            {
                db.Shops.Remove(shop);
            }
        }
    }
}
