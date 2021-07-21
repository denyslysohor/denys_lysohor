using Microsoft.AspNetCore.Mvc;
using LaptopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaptopApi.Controllers
{
   // [Route("api/[Laptop]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        DB db = DB.GetInstance();

        // GET: api/<LaptopController>
        [Route("api/Laptop")]
        [HttpGet]
        public IEnumerable<Laptop> GetLaptops()
        {
            return db.Laptops;
        }

        // GET api/<LaptopController>/5
        [HttpGet("{id}")]
        [Route("api/Laptop/{id}")]
        public Laptop GetLaptop(int id)
        {
            Laptop laptop = db.Laptops.Where(l=>l.Id == id).FirstOrDefault();
            return laptop;
        }

        // POST api/<LaptopController>
        [HttpPost]
        [Route("api/CreateLaptop")]
        public void CreateLaptop([FromBody] Laptop laptop)
        {
            db.Laptops.Add(laptop);
        }

        // PUT api/<LaptopController>/5
        [HttpPut("{id}")]
        [Route("api/UpdateLaptop/{id}")]
        public void UpdateLaptop(int id, [FromBody] Laptop laptop)
        {
            int index = db.Laptops.IndexOf(db.Laptops.Where(l=>l.Id == id).FirstOrDefault());
            db.Laptops[index] = laptop;
        }

        // DELETE api/<LaptopController>/5
        [HttpDelete("{id}")]
        [Route("api/DeleteLaptop/{id}")]
        public void DeleteLaptop(int id)
        {
            Laptop laptop = db.Laptops.Where(l => l.Id == id).FirstOrDefault();
            if (laptop != null)
            {
                db.Laptops.Remove(laptop);
            }
        }
    }
}
