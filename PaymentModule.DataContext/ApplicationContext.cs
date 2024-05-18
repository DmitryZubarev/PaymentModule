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
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected ApplicationContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .Property(x => x.DateTime)
                .HasColumnType("timestamp without time zone");

            modelBuilder.Entity<SharingSession>()
                .Property(x => x.StartDateTime)
                .HasColumnType("timestamp without time zone");
            modelBuilder.Entity<SharingSession>()
                .Property(x => x.EndDateTime)
                .HasColumnType("timestamp without time zone");

            CreateData(modelBuilder);
        }


        public DbSet<City> Cities => Set<City>();
        public DbSet<Street> Streets => Set<Street>();
        public DbSet<CityStreet> CityStreets => Set<CityStreet>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Goods> Goods => Set<Goods>();
        public DbSet<Tariff> Tariffs => Set<Tariff>();
        public DbSet<SharingSession> SharingSessions => Set<SharingSession>();
        public DbSet<Payment> Payments => Set<Payment>();

        private void CreateData(ModelBuilder modelBuilder)
        {
            AddStreets(modelBuilder);
            AddCities(modelBuilder);
            AddCityStreets(modelBuilder);
            AddLocations(modelBuilder);
            AddGoods(modelBuilder);
            AddTariffs(modelBuilder);
        }

        private void AddStreets(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Street>().HasData(
                new Street()
                {
                    Id = 1,
                    Name = "Street_1",
                });
        }

        private void AddCities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City()
                {
                    Id = 1,
                    Name = "City_1",
                });
        }

        private void AddCityStreets(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityStreet>().HasData(
                new CityStreet()
                {
                    Id = 1,
                    CityId = 1,
                    StreetId = 1,
                });
        }

        private void AddLocations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                new Location()
                {
                    Id = 1,
                    CityStreetId = 1,
                    BuildingNumber = 1,
                    BuildingSubNumber = "A",
                });
        }

        private void AddGoods(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goods>().HasData(
                new Goods()
                {
                    Id = 1,
                    Name = "Blanked",
                });
        }

        private void AddTariffs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tariff>().HasData(
                new Tariff()
                {
                    Id = 1,
                    LocationId = 1,
                    GoodsId = 1,
                    Price = 100,
                    Time = new TimeSpan(0, 0, 15),
                });
        }
    }
}
