using System;
using AuctionApp.Core;
using AuctionApp.Persistence;
using AutoMapper;

namespace AuctionApp.Mappings
{
    public class AuctionMapping : Profile
    {
        public AuctionMapping()
        {
            CreateMap<AuctionDb, Auction>()
               .ReverseMap();
        }
    }
}

