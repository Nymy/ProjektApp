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
    }
}
