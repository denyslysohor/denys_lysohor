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
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        DB db = DB.GetInstance();
        
        [HttpGet]
        public IEnumerable<Laptop> GetLaptops()
        {
            return db.Laptops;
        }
        
        [HttpGet("{id}")]
        [Route("{id}")]
        public Laptop GetLaptop(int id)
        {
            Laptop laptop = db.Laptops.FirstOrDefault(l => l.Id == id);
            return laptop;
        }

        // POST api/<LaptopController>
        [HttpPost]
        public void CreateLaptop([FromBody] Laptop laptop)
        {
            db.Laptops.Add(laptop);
        }

        // PUT api/<LaptopController>/5
        [HttpPut("{id}")]
        public void UpdateLaptop(int id, [FromBody] Laptop laptop)
        {
            int index = db.Laptops.IndexOf(db.Laptops.FirstOrDefault(l => l.Id == id));
            db.Laptops[index] = laptop;
        }

        // DELETE api/<LaptopController>/5
        [HttpDelete("{id}")]
        [Route("{id}")]
        public void DeleteLaptop(int id)
        {
            Laptop laptop = db.Laptops.FirstOrDefault(l => l.Id == id);
            if (laptop != null)
            {
                db.Laptops.Remove(laptop);
            }
        }
    }
}
