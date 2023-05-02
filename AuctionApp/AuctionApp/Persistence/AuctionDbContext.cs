using Microsoft.EntityFrameworkCore;
using AuctionApp.ViewModels;
using System.Threading.Tasks;
using System;
using AuctionApp.Core;

namespace AuctionApp.Persistence
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }
        public DbSet<AuctionDb> AuctionDbs { get; set; }
        public DbSet<BidDb> BidDbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AuctionDb adb = new AuctionDb
            {
                Id = -1,
                Name = "Mac",
                Description = "Good item",
                Owner = "sarugan@kth.se",
                InitialPrice = 15000,
                ExpiryDate = DateTime.Now,
                HighestBid = 16500
            };
            modelBuilder.Entity<AuctionDb>().HasData(adb);
            BidDb tdb1 = new BidDb()
            {
                Id = -1,
                BidPrice = 16000,
                Date = DateTime.Now,
                UserName = "saruganb10@gmail.com",
                AuctionId = -1,
            };
            BidDb tdb2 = new BidDb()
            {
                Id = -2,
                BidPrice = 16500,
                Date = DateTime.Now,
                UserName = "saruganb11@gmail.com",
                AuctionId = -1,
            };
            modelBuilder.Entity<BidDb>().HasData(tdb1);
            modelBuilder.Entity<BidDb>().HasData(tdb2);
        }
    }
}
