using ProjektApp.Core.Interfaces;
using ProjektApp.Core;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Threading.Tasks;

namespace ProjektApp.Persistence
{
    public class AuctionSqlPersistence : IAuctionPersistence
    {
        private AuctionDbContext _dbContext;
        private IMapper _mapper;

        public AuctionSqlPersistence(AuctionDbContext dbContext, IMapper mapper) { 
            _dbContext = dbContext; 
            _mapper = mapper;
        }

        public List<Auction> GetAuctions() {
            var auctionDbs = _dbContext.AuctionDbs
              //  .Where(p => true)
              //  .Include(p => p.BidDbs)
                .ToList();

            List<Auction> result = new List<Auction>();
            foreach(AuctionDb adb in auctionDbs)
            {
                Auction auction = _mapper.Map<Auction>(adb);
                Console.WriteLine(auction.CloseDate);
                result.Add(auction);
            }

            return result;
        }

        public Auction GetById(int id)
        {
            // eager loading
            var auctionDb = _dbContext.AuctionDbs
                .Include(p => p.BidDbs)
                .Where(p => p.Id == id)
                .SingleOrDefault();

            Auction auction = _mapper.Map<Auction>(auctionDb);
            foreach (BidDb tdb in auctionDb.BidDbs)
            {
                auction.AddBidFromDb(_mapper.Map<Bid>(tdb));
            }
            return auction;
        }
    }
}
