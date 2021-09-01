using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestingWebApp.Models;

namespace TestingWebApp.Data
{
    public class TestingWebAppContext : DbContext
    {
        public TestingWebAppContext (DbContextOptions<TestingWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<TestingWebApp.Models.User> User { get; set; }
    }
}
