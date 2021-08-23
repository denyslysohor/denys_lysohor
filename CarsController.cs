using JwtAuthSampleAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthSampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        Car[] cars = new Car[]
        {
            new Car {Id = 1, Mark = "Cadillac", Model = "Escalade", Color = "Silver", Year = 2021 },
            new Car {Id = 2, Mark = "Chevrolet", Model = "Malibu", Color = "Black", Year = 2018 },
            new Car {Id = 3, Mark = "Toyota", Model = "CH-R", Color = "Slate", Year = 2020 },
            new Car {Id = 4, Mark = "Ford", Model = "Focus", Color = "Red", Year = 2019 }
        };

        [HttpGet]
        [Route("")]
        public IEnumerable<Car> GetAllCars()
        {
            return cars;
        }
    }
}
