namespace AuctionApp.Core.Interfaces
{
    public interface IAuctionPersistence
    {
        public List<Auction> getMyAuctions(string userName);

        public List<Auction> getAllAuctions(string userName);

        public void createAuction(Auction auction);

        public Auction getAuctionBidsById(int id);

        public void editDescription(string desc, int id);

        public void addBid(Bid bid, int id);

        public Auction getById(int id);

        public List<Auction> GetAuctionsWon(string name);

        public List<Auction> getAuctionsUserBidOn(string userName);
    }
}
