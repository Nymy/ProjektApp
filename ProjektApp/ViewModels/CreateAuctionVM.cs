using System.ComponentModel.DataAnnotations;
namespace ProjektApp.ViewModels
{
    public class CreateAuctionVM
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public DateTime CloseAuction { get; set; }
        public string Description { get; set; }
    }
}
