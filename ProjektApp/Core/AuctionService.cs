using ProjektApp.Core.Interfaces;

namespace ProjektApp.Core
{
    public class AuctionService : IAuctionService
    {

        private IAuctionPersistence _auctionPersistence;

        public AuctionService(IAuctionPersistence auctionPersistence) {
            _auctionPersistence = auctionPersistence;
        }

        public Auction GetById(int id)
        {
            return _auctionPersistence.GetById(id);
        }

        public List<Auction> GetAuctions()
        {
            return _auctionPersistence.GetAuctions();
        }

        public List<Auction> GetMyBids(string userName)
        {
            return _auctionPersistence.GetMyBids(userName);
        }

        public List<Auction> GetMyWinningBids(string userName)
        {
            return _auctionPersistence.GetMyWinningBids(userName);
        }

        public void Add(Auction auction)
        {
            //assume no bids in new auction
            if (auction == null || auction.Id != 0) throw new InvalidDataException();
            auction.CreatedDate = DateTime.Now;
            _auctionPersistence.Add(auction);
        }

        public void Edit(Auction auction, int id)
        {
            _auctionPersistence.Edit(auction, id);
        }

        public void AddBid(Bid bid, Auction auction)
        {
       
            if (bid == null || bid.Id != 0) throw new InvalidDataException();
            bid.BiddedAt = DateTime.Now;
            bool added = auction.AddBid(bid, auction);
            if (added)
            {
                _auctionPersistence.AddBid(bid, auction);
            }
            
        }
    }
}
