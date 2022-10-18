namespace ProjektApp.Core
{
    public class Auction
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime CloseDate { get; set; }  

        public string Description { get; set; }

        public string UserName { get; set; }

        private List<Bid> _bids = new List<Bid>();

        public IEnumerable<Bid> Bids => _bids;

        public Auction(string title)
        {
            Title = title;
            CreatedDate = DateTime.Now;
        }

        public Auction(int id, string title, string description, DateTime closeAuction)
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedDate = DateTime.Now;
            CloseDate = closeAuction;
          
        }

        public Auction() { }

        public void AddBid(Bid newBid)
        {
            Console.WriteLine(newBid.BidAmount + " NEW BID SENT IN");
            if (IsCompleted()) throw new InvalidOperationException("Auction is closed!");
 
            if (_bids.Count == 0 || newBid.BidAmount.CompareTo(_bids.Last().BidAmount) > 0 )
                _bids.Add(newBid);
            else throw new ArgumentException("Bid not high enough");
        }

        public void AddBidFromDb(Bid newBid)
        {
            _bids.Add(newBid);
        }


        public bool IsCompleted()
        {
            if (DateTime.Compare(DateTime.Now, CloseDate) < 0) return false;
            return true;
        }

        public override string ToString()
        {
            return $"{Id}: {Title} - completed: {IsCompleted()}";
        }
    }
}
