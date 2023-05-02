using System;
using AuctionApp.Core;

namespace AuctionApp.ViewModels
{
    public class AuctionDetailsVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Owner { get; set; }

        public int InitialPrice { get; set; }

        public DateTime ExpiryDate { get; set; }

        public int HighestBid { get; set; }

        public List<BidVM> BidVMs { get; set; } = new();

        public static AuctionDetailsVM FromAuction(Auction a)
        {
            var AuctionDetailsVM =  new AuctionDetailsVM()
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                Owner = a.Owner,
                InitialPrice = a.InitialPrice,
                ExpiryDate = a.ExpiryDate,
                HighestBid = a.HighestBid,

            };

            foreach(var bids in a.bids)
            {
                AuctionDetailsVM.BidVMs.Add(BidVM.FromBid(bids));
            }


            return AuctionDetailsVM;
        }
    }
}

