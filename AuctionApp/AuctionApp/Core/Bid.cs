namespace AuctionApp.Core
{
    public class Bid
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int BidPrice { get; set; }
        public DateTime Date { get; set; }
        public Bid(int id, string userName, int bidPrice, DateTime date)
        {
            this.Id = id;
            this.UserName = userName;
            this.BidPrice = bidPrice;
            this.Date = date;
        }

        public Bid() { }
    }
}
