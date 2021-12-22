using Microsoft.EntityFrameworkCore;
using MusicShop.DataLayer.Models;
using System;

namespace MusicShop.DataLayer
{
    public class MusicShopDbContext : DbContext
    {
        public MusicShopDbContext(DbContextOptions<MusicShopDbContext> options) : base(options)
        { 
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instrument>()
                .HasOne(i => i.Instrument_Type)
                .WithMany(it => it.Instruments)
                .HasForeignKey(i => i.Instrument_Type_Id);

            modelBuilder.Entity<Instrument>()
                .HasOne(i => i.Producer)
                .WithMany(it => it.Instruments)
                .HasForeignKey(i => i.Producer_Id);
        }

        public DbSet<Instrument> Instrument {get; set;}
        public DbSet<Customer> Customer {get; set;}
        public DbSet<Instrument_Type> Instrument_Type {get; set;}
        public DbSet<Producer> Producer {get; set;}
        public DbSet<Purchase> Purchase {get; set;}
        public DbSet<Purchased_Item> Purchased_Item {get; set;}
    }
}
