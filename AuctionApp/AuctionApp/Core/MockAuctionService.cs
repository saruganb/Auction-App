using AuctionApp.Core.Interfaces;

namespace AuctionApp.Core
{
    public class MockAuctionService /*: IAuctionService*/
    {
        public List<Auction> getAll()
        {
            Auction auction1 = new Auction(1, "Mac", "Very good computer", "Sarugan", 12000, DateTime.Now);
            Auction auction2 = new Auction(2, "Asus", "Better than Mac", "Diego", 13000, DateTime.Now);
            auction1.AddBid(new Bid(1, "Diego", 12000, DateTime.Now));
            auction2.AddBid(new Bid(1, "Sarugan", 13000, DateTime.Now));

            List<Auction> auctions = new List<Auction>();
            auctions.Add(auction1); 
            auctions.Add(auction2);
            return auctions; 
        }
        


    }
}
