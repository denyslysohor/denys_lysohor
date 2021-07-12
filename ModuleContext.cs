using ModuleDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleDAL
{
    public class ModuleContext : DbContext
    {
        public ModuleContext(string connectionString = @"data source=.;Initial Catalog=Module;Integrated Security=True;") : base(connectionString)
        {
            Database.SetInitializer<ModuleContext>(new ModuleInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
