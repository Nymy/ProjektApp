using ProjektApp.Core;
using System.ComponentModel.DataAnnotations;

namespace ProjektApp.ViewModels
{
    public class EditAuctionVM
    {
        [Required]
        [StringLength(255, ErrorMessage = "Max length 255 characters")]
        public string Description { get; set; }

        public static EditAuctionVM FromAuction(Auction auction)
        {
            var newDescription = new EditAuctionVM()
            {
                Description = auction.Description,
            };
            return newDescription;
        }
    }
}
