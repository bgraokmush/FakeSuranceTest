using FakeSurance.Core.Entites.Concrete;
using FakeSurance.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FakeSurance.DataAccess.Concrete.EntityFramework
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=veritabani.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Order>().ToTable("Orders");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
