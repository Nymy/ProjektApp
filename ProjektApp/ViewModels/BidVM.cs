using ProjektApp.Core;
using Bid = ProjektApp.Core.Bid;
namespace ProjektApp.ViewModels
{
    public class BidVM
    {
        public int Id { get; set; }
        public string Name { get; set; }    

        public int BidAmount { get; set; }  
        public DateTime BiddedAt { get; set; }

        public int AuctionId { get; set; }


        public static BidVM FromBid(Bid bid)
        {
            return new BidVM()
            {
                Id = bid.Id,
                Name = bid.Name,
                BidAmount = bid.BidAmount,
                BiddedAt = bid.BiddedAt,
                AuctionId = bid.AuctionId
            };
        }
    }
}
