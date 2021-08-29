using Managers.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.DAL.EF
{
    public partial class ManagerContext : DbContext
    {
        public ManagerContext()
        {
        }

        public ManagerContext(DbContextOptions<ManagerContext> options)
            : base(options)
        {
           
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<JobHistory> JobHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Manager;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
