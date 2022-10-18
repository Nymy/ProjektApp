using Microsoft.EntityFrameworkCore;
namespace ProjektApp.Persistence
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }

        public DbSet<BidDb> BidsDbs { get; set; }
        public DbSet<AuctionDb> AuctionDbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AuctionDb adb = new AuctionDb
            {
                Id = -1, // from seed data
                Title = "Auction for orchids",
                Description = "Alot of orchids, very nice",
                CreatedDate = new DateTime(2022,10,17),
                CloseDate = new DateTime(2022, 10, 17, 23,59,59),
                UserName = "nonnoo@kth.se",
                BidDbs = new List<BidDb>() 
            };

            BidDb bid1 = new BidDb()
            {
                Id = -1,
                Name = "Viktor",
                BidAmount = 100,
                BiddedAt = new DateTime(2022, 10, 17, 13, 20, 00),
                AuctionId = -1

            };
            BidDb bid2 = new BidDb()
            {
                Id = -2,
                Name = "Nonno",
                BidAmount = 101,
                BiddedAt = new DateTime(2022, 10, 17, 13, 21, 00),
                AuctionId = -1

            };

            modelBuilder.Entity<AuctionDb>().HasData(adb);
            modelBuilder.Entity<BidDb>().HasData(bid1);
            modelBuilder.Entity<BidDb>().HasData(bid2);



        }

    }
}
