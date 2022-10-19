using ProjektApp.Core;
namespace ProjektApp.ViewModels
{
    public class AuctionVM
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime CloseAuction { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }
        public int LowestPrice { get; set; }

        public static AuctionVM FromAuction(Auction auction)
        {
            return new AuctionVM()
            {
                Id = auction.Id,
                Title = auction.Title,
                CreatedDate = auction.CreatedDate,
                CloseAuction = auction.CloseDate,
                LowestPrice = auction.LowestPrice,
                Description = auction.Description,
                IsCompleted = auction.IsCompleted()
            };
        }


    }
}
