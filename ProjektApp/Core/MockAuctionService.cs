using ProjektApp.Core.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace ProjektApp.Core
{
    public class MockAuctionService : IAuctionService
    {
        public List<Auction> GetAuctions()
        {
            Auction a1 = new Auction(1, "Auction for orchids", new DateTime(2022, 10, 18, 23,59,59));
            Auction a2 = new Auction(2, "Auction for Mona Lisa", new DateTime(2022, 10, 19));
            Auction a3 = new Auction(3, "Auction for Cats", new DateTime(2022, 10, 17, 14, 35, 10));
            a1.AddBid(new Core.Bid("Nonno", 125));
            a1.AddBid(new Core.Bid("Viktor", 130));
            a2.AddBid(new Core.Bid("Kasper", 100));
            a3.AddBid(new Core.Bid("Calle", 100));
            a3.Description = "This cat is very cute";
            List<Auction> auctions = new();
            auctions.Add(a1);
            auctions.Add(a2);
            auctions.Add(a3);
            return auctions;
        }
    }
}
