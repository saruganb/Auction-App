using System;
using AuctionApp.Core;
using AuctionApp.Persistence;
using AutoMapper;

namespace AuctionApp.Mappings
{
    public class BidMapping : Profile
    {
        public BidMapping()
        {
            CreateMap<BidDb, Bid>()
               .ReverseMap();
        }
    }
}

