using Microsoft.EntityFrameworkCore;
using PaymentModule.DataContext.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.DataContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=PaymentModule;Username=postgres;Password=postgres");
        }

        public DbSet<City> Cities => Set<City>();
        public DbSet<Street> Streets => Set<Street>();
        public DbSet<CityStreet> CityStreets => Set<CityStreet>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Goods> Goods => Set<Goods>();
        public DbSet<Tariff> Tariffs => Set<Tariff>();
        public DbSet<SharingSession> SharingSessions => Set<SharingSession>();
        public DbSet<Payment> Payments => Set<Payment>();
    }
}
