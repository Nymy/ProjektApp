using ProjektApp.Core;
namespace ProjektApp.ViewModels
{
    public class AuctionDetailsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime CloseAuction { get; set; }

        public string Description { get; set; }

        public int LowestPrice { get; set; }

        public string UserName { get; set; }

        public bool IsCompleted { get; set; }

        public List<BidVM> Bids { get; set; } = new();

        public static AuctionDetailsVM FromAuction(Auction auction)
        {

            var detaislVM = new AuctionDetailsVM()
            {
                Id = auction.Id,
                Title = auction.Title,
                CreatedDate = auction.CreatedDate,
                CloseAuction = auction.CloseDate,
                LowestPrice = auction.LowestPrice,
                Description = auction.Description,
                UserName = auction.UserName,
                IsCompleted = auction.IsCompleted()
            };
            foreach (var bid in auction.Bids)
            {
                detaislVM.Bids.Add(BidVM.FromBid(bid));
            }
            return detaislVM;
        }
    }
}
