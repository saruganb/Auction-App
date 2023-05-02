namespace AuctionApp.Core
{
    public class Auction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public int InitialPrice { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int HighestBid { get; set; }

        private List<Bid> _bids = new List<Bid>();

        public IEnumerable<Bid> bids => _bids; 

        public Auction(int id, string name, string description, string owner, int initialPrice, DateTime expiryDate)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Owner = owner;
            this.InitialPrice = initialPrice;
            this.ExpiryDate = expiryDate;
            this.HighestBid = initialPrice;
        }

        public Auction(int id, string name, string owner, int initialPrice, DateTime expiryDate)
        {
            this.Id = id;
            this.Name = name;
            this.Description = ""; 
            this.Owner = owner;
            this.InitialPrice = initialPrice;
            this.ExpiryDate = expiryDate;
            this.HighestBid = initialPrice;
        }

        public Auction()
        {
        }

        public void AddBid(Bid bid)
        {
            _bids.Add(bid);
        }

        public bool isExpired()
        {
            return this.ExpiryDate < DateTime.Now; 
        }

    }
}
