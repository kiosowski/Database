using Banicharnica.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Banicharnica.Data
{
    public class BanicharnicaContext : DbContext
    {
        public BanicharnicaContext()
        {
        }
        public BanicharnicaContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(x => x.Manager)
                      .WithMany(x => x.ManagerEmployees)
                      .HasForeignKey(x => x.ManagerId);
            });
        }
    }
}
