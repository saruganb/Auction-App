using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionApp.ViewModels
{
    public class CreateAuctionVM
    {
        [Required]
        [StringLength(128, ErrorMessage = "Max length 128 characters")]
        public string Name { get; set; }

        [StringLength(300, ErrorMessage = "Max length 300 characters")]
        public string Description { get; set; }

        [Required]
        public int InitialPrice { get; set; }
    }
}

