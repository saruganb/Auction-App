using System;
using AuctionApp.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AuctionApp.ViewModels
{
    public class AuctionVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public int InitialPrice { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int HighestBid { get; set; }

        public static AuctionVM FromAuction(Auction auction)
        {
            return new AuctionVM()
            {
                Id = auction.Id,
                Name = auction.Name,
                Description = auction.Description,
                Owner = auction.Owner,
                InitialPrice = auction.InitialPrice,
                ExpiryDate = auction.ExpiryDate,
                HighestBid = auction.HighestBid
            }; 
        }
    }
}
