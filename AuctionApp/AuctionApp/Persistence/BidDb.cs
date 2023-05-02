using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionApp.Persistence
{
    public class BidDb
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BidPrice { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [Required]
        public string UserName { get; set; }

        [ForeignKey("AuctionId")]
        public AuctionDb AuctionDb { get; set; }

        public int AuctionId { get; set; }
    }
}
