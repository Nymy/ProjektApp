namespace ProjektApp.Core
{
    public class Auction
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime CreatedDate { get; }

        public DateTime CloseAuction { get; set; }  

        private List<Bid> _bids = new List<Bid>();

        //public IEnumerable<Bid> Bids => _bids;

        public Auction(string title)
        {
            Title = title;
            CreatedDate = DateTime.Now;
        }

        public Auction(int id, string title, DateTime closeAuction)
        {
            Id = id;
            Title = title;
            CreatedDate = DateTime.Now;
            CloseAuction = closeAuction;
        }

        public Auction() { }

        public void AddBid(Bid newBid)
        {
            if (IsCompleted()) throw new InvalidOperationException("Auction is closed!");
 
            if (_bids.Count == 0 || newBid.BidAmount.CompareTo(_bids.Last().BidAmount) > 0 )
                _bids.Add(newBid);
            else throw new ArgumentException("Bid not high enough");
        }

        public bool IsCompleted()
        {
            if (DateTime.Compare(DateTime.Now, CloseAuction) < 0) return false;
            return true;
        }

        public override string ToString()
        {
            return $"{Id}: {Title} - completed: {IsCompleted()}";
        }
    }
}
