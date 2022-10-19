namespace ProjektApp.Core
{
    public class Bid
    {
       public int Id { get; set; }  
       public string Name { get; set; }
       public DateTime BiddedAt { get; set; }
       public int BidAmount { get; set; }     

        public int AuctionId { get; set; }

        public Bid(string name, int bidAmount) {
            Name = name;
            BidAmount = bidAmount;
            BiddedAt = DateTime.Now;
        }


        public Bid(int id, string name, int bidAmount)
        {
            Id = id;
            Name = name;
            BidAmount = bidAmount;
            BiddedAt = DateTime.Now;
        }

        public Bid() { }
    }
}
