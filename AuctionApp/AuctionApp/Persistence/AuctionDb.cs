using System.ComponentModel.DataAnnotations;

namespace AuctionApp.Persistence
{
    public class AuctionDb
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        [Required]
        public string Owner { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ExpiryDate { get; set; }
        [Required]
        public int InitialPrice { get; set; }
        [Required]
        public int HighestBid { get; set; }

        public List<BidDb> BidDbs { get; set; } = new List<BidDb>(); 

    }
}
