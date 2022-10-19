namespace ProjektApp.Core
{
    public class Auction
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime CloseDate { get; set; }  

        public string Description { get; set; }

        public int LowestPrice { get; set; }

        public string UserName { get; set; }

        private List<Bid> _bids = new List<Bid>();

        public IEnumerable<Bid> Bids => _bids;

        public Auction(string title)
        {
            Title = title;
            CreatedDate = DateTime.Now;
        }

        public Auction(int id, string title, string description, int lowestPrice, DateTime closeAuction)
        {
            Id = id;
            Title = title;
            Description = description;
            LowestPrice = lowestPrice;
            CreatedDate = DateTime.Now;
            CloseDate = closeAuction;
          
        }

        public Auction() { }

        public bool AddBid(Bid newBid, Auction auction)
        {
            if (IsCompleted()) return false;
            if (newBid.BidAmount.CompareTo(LowestPrice) > 0)
            {
                if (_bids.Count == 0 || newBid.BidAmount.CompareTo(_bids.Last().BidAmount) > 0)
                {
                    _bids.Add(newBid);
                    return true;
                }
                return false;
            }           
            return false;
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
