namespace ProjektApp.Core
{
    public class Bid
    {
       public int Id { get; set; }  
       public string Name { get; set; }
       private DateTime _biddedAt;
       public DateTime BiddedAt { get => _biddedAt;  }
       public int BidAmount { get; set; }     

        public Bid(string name, int bidAmount) {
            Name = name;
            BidAmount = bidAmount;  
            _biddedAt = DateTime.Now;
        }
    }
}
