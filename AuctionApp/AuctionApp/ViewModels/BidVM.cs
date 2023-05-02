using System;
using AuctionApp.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AuctionApp.ViewModels
{
    public class BidVM
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public int BidPrice { get; set; }
        public DateTime Date { get; set; }

        public static BidVM FromBid(Bid bid)
        {
            return new BidVM()
            {
                Id = bid.Id,
                UserName = bid.UserName,
                BidPrice = bid.BidPrice,
                Date = bid.Date,
            }; 
        }
    }
}
