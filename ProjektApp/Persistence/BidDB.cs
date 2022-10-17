using ProjektApp.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektApp.Persistence
{
    public class BidDB
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        private DateTime BiddedAt { get; set; }

        [Required]
        public int BidAmount { get; set; }

        [ForeignKey("AuctionId")]
        public AuctionDB auctionDB { get; set; }


    }
}
