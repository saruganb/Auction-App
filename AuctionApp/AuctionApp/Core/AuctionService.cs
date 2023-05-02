using AuctionApp.Core.Interfaces;
using AuctionApp.Migrations;
using static Humanizer.In;

namespace AuctionApp.Core
{
    public class AuctionService : IAuctionService
    {
        private IAuctionPersistence _auctionPersistence; 

        public AuctionService(IAuctionPersistence auctionPersistence)
        {
            _auctionPersistence = auctionPersistence;
        }

        public void addBid(Bid bid, int id)
        {
            bid.Date = DateTime.Now;
            _auctionPersistence.addBid(bid, id);
        }

        public void createAuction(Auction auction)
        {
            if (auction == null || auction.Id != 0) throw new InvalidDataException();
          
            auction.ExpiryDate = DateTime.Now.AddDays(2);
            auction.HighestBid = auction.InitialPrice;
            _auctionPersistence.createAuction(auction);
        }

        public void editDescription(string desc, int id)
        {
            _auctionPersistence.editDescription(desc, id);
        }

        public List<Auction> getAllAuctions(string userName)
        {
            return _auctionPersistence.getAllAuctions(userName);
        }

        public Auction getAuctionBidsById(int id)
        {
            return _auctionPersistence.getAuctionBidsById(id);
        }

        public List<Auction> getAuctionsUserBidOn(string userName)
        {
            return _auctionPersistence.getAuctionsUserBidOn(userName);
        }

        public List<Auction> GetAuctionsWon(string name)
        {
            return _auctionPersistence.GetAuctionsWon(name);
        }

        public Auction getById(int id)
        {
            return _auctionPersistence.getById(id);
        }

        public List<Auction> getMyAuctions(string userName)
        {
            return _auctionPersistence.getMyAuctions(userName);
        }
    }
}
