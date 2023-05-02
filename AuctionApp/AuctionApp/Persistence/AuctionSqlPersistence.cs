using System;
using AuctionApp.Core;
using AuctionApp.Core.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Persistence
{
    public class AuctionSqlPersistence : IAuctionPersistence
    {
        private AuctionDbContext _auctionDbContext;
        private IMapper _mapper;

        public AuctionSqlPersistence(AuctionDbContext auctionDbContext, IMapper mapper)
        {
            _auctionDbContext = auctionDbContext;
            _mapper = mapper;
        }

        public void createAuction(Auction auction)
        {
            AuctionDb auctionDb = _mapper.Map<AuctionDb>(auction);
            _auctionDbContext.AuctionDbs.Add(auctionDb);
            _auctionDbContext.SaveChanges();
        }

        public void addBid(Bid bid, int id)
        {
            BidDb bidDb = _mapper.Map<BidDb>(bid);
            bidDb.AuctionId = id;
            var transaction = _auctionDbContext.Database.BeginTransaction();
            try
            {
                _auctionDbContext.BidDbs.Add(bidDb);
                _auctionDbContext.SaveChanges();

                var result = _auctionDbContext.AuctionDbs.Where(a => a.Id == id).SingleOrDefault();

                if (result != null)
                {
                    result.HighestBid = bidDb.BidPrice;
                    _auctionDbContext.SaveChanges();
                }

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw new Exception();
            }
        }

        public Auction getById(int id)
        {
            var auctionDb = _auctionDbContext.AuctionDbs
                .Where(a => a.Id == id)
                .SingleOrDefault();

            Auction auction = _mapper.Map<Auction>(auctionDb);

            return auction;
        }

        public void editDescription(string desc, int id)
        {
            var result = _auctionDbContext.AuctionDbs.Where(a => a.Id == id).SingleOrDefault();
            if (result != null)
            {
                result.Description = desc;
                _auctionDbContext.SaveChanges();
            }
        }

        public Auction getAuctionBidsById(int id)
        {
            var auctionDb = _auctionDbContext.AuctionDbs
                .Include(a => a.BidDbs)
                .Where(a => a.Id == id)
                .SingleOrDefault();

            Auction auction = _mapper.Map<Auction>(auctionDb);

            for (int i = auctionDb.BidDbs.Count - 1; i >= 0; i--)
            {
                auction.AddBid(_mapper.Map<Bid>(auctionDb.BidDbs[i]));
            }

            return auction;

        }

        public List<Auction> getMyAuctions(string userName)
        {
            var AuctionDbs = _auctionDbContext.AuctionDbs
                .Where(p => p.Owner.Equals(userName) && p.ExpiryDate >= DateTime.Now)
                .ToList();

            List<Auction> result = new List<Auction>();
            foreach (AuctionDb auctionDb in AuctionDbs)
            {
                result.Add(_mapper.Map<Auction>(auctionDb));
            }
            return result;
        }


        public List<Auction> getAllAuctions(string userName)
        {
            var AuctionDbs = _auctionDbContext.AuctionDbs
               .Where(p => !p.Owner.Equals(userName) && p.ExpiryDate >= DateTime.Now)
               .ToList();

            List<Auction> result = new List<Auction>();
            foreach (AuctionDb auctionDb in AuctionDbs)
            {
                result.Add(_mapper.Map<Auction>(auctionDb));
            }
            return result;
        }

        public List<Auction> GetAuctionsWon(string name)
        {
            var auctionDbs = _auctionDbContext.AuctionDbs
                .Where(p => p.ExpiryDate < DateTime.Now)
                .ToList();

            List<Auction> result = new List<Auction>();
            foreach (AuctionDb auctionDb in auctionDbs)
            {

                var bidDb = _auctionDbContext.BidDbs
                .Where(b => b.AuctionId == auctionDb.Id && b.BidPrice == auctionDb.HighestBid)
                .SingleOrDefault();

                if (bidDb != null && bidDb.UserName.Equals(name))
                {
                    result.Add(_mapper.Map<Auction>(auctionDb));
                }
            }

            return result;

        }

        public List<Auction> getAuctionsUserBidOn(string owner)
        {
            var AuctionsNotExpired = _auctionDbContext.AuctionDbs
                .Where(a => a.ExpiryDate >= DateTime.Now)
                .ToList();

            List<Auction> auctionsBidOn = new List<Auction>();
            foreach (AuctionDb auctions in AuctionsNotExpired)
            {
                var BidsOfOwner = _auctionDbContext.BidDbs
                    .Where(b => b.UserName.Equals(owner) && b.AuctionId == auctions.Id)
                    .FirstOrDefault();

                if (BidsOfOwner != null)
                {
                    auctionsBidOn.Add(_mapper.Map<Auction>(auctions));
                }
            }
            return auctionsBidOn;
        }
    }
}
