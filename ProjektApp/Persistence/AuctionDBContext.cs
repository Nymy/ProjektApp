using Microsoft.EntityFrameworkCore;
namespace ProjektApp.Persistence
{
    public class AuctionDBContext : DbContext
    {
        public AuctionDBContext(DbContextOptions<AuctionDBContext> options) : base(options) { }

        public DbSet<BidDB> BidsDbs { get; set; }
        public DbSet<AuctionDB> AuctionDbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuctionDB>().HasData(


                new AuctionDB
                {
                    Id = -1, // from seed data
                    Title = "Auction for orchids",
                    Descripction = "Alot of orchids, very nice",
                    CreatedDate = DateTime.Now,
                    CloseDate = new DateTime(2022, 10, 30)
                });
        }

    }
}
