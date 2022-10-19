using System.ComponentModel.DataAnnotations;

namespace ProjektApp.Persistence
{
    public class AuctionDb
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(128)]
        public string Title { get; set; }


        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        public int LowestPrice { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CloseDate { get; set; }

        public string UserName { get; set; }

        public List<BidDb> BidDbs { get; set; } = new List<BidDb>();

    }
}
