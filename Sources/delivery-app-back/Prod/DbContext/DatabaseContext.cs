using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using delivery_app_back.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace delivery_app_back.DbContext
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=192.168.64.2;database=deliverydb;user=rachidba;password=password");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Courier>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.PhoneNumber).IsRequired().IsUnicode();
                entity.Property(e => e.Email).IsRequired().IsUnicode();
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.PhoneNumber).IsRequired().IsUnicode();
                entity.Property(e => e.Email).IsRequired().IsUnicode();
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
            });
        }

        public async Task<ICollection<Courier>> GetCouriers()
        {
            return await Couriers.ToListAsync();
        }

        public async Task<Courier> CreateCourier(Courier courier)
        {
            var savedCourier = await Couriers.AddAsync(courier);
            SaveChanges();
            return savedCourier.Entity;
        }

        public async Task<Courier> GetCourier(int userId)
        {
            return await Couriers.FirstOrDefaultAsync(courier => courier.UserId == userId);
        }
    }
}