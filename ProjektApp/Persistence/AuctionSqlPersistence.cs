using ProjektApp.Core.Interfaces;
using ProjektApp.Core;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Threading.Tasks;
using ProjektApp.ViewModels;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace ProjektApp.Persistence
{
    public class AuctionSqlPersistence : IAuctionPersistence
    {
        private AuctionDbContext _dbContext;
        private IMapper _mapper;

        public AuctionSqlPersistence(AuctionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<Auction> GetAuctions()
        {
            var auctionDbs = _dbContext.AuctionDbs
                  .Where(p => p.CloseDate > DateTime.Now)
                //  .Include(p => p.BidDbs)
                .ToList();

            List<Auction> result = new List<Auction>();
            foreach (AuctionDb adb in auctionDbs)
            {
                Auction auction = _mapper.Map<Auction>(adb);
                result.Add(auction);
            }

            return result;
        }

        public List<Auction> GetMyBids(string userName)
        {
            var auctionDbs = _dbContext.AuctionDbs
                .Include(p => p.BidDbs)
                .Where(c => c.CloseDate > DateTime.Now)
                .ToList();

            bool added = false;
            List<Auction> result = new List<Auction>();
            foreach (AuctionDb adb in auctionDbs)
            {
                added = false;
                foreach (BidDb bdb in adb.BidDbs)
                {
                    if (bdb.Name == userName)
                    {
                        if (!added)
                        {
                            added = true;
                            Auction auction = _mapper.Map<Auction>(adb);
                            result.Add(auction);
                        }

                    }
                }
            }

            return result;
        }

        public List<Auction> GetMyWinningBids(string userName)
        {
            Console.WriteLine("\n \n \n" + userName + " IM HERE IM HERE IM HERE \n \n\n\n");
            var auctionDbs = _dbContext.AuctionDbs
                .Include(p => p.BidDbs)
                .Where(c => c.CloseDate < DateTime.Now)
                .ToList();

            List<Auction> result = new List<Auction>();
            foreach (AuctionDb adb in auctionDbs)
            {
                if (adb.BidDbs.Last().Name == userName)
                {
                    Auction auction = _mapper.Map<Auction>(adb);
                    result.Add(auction);

                }
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

        public void Add(Auction auction)
        {
            AuctionDb adb = _mapper.Map<AuctionDb>(auction);
            _dbContext.AuctionDbs.Add(adb);
            _dbContext.SaveChanges();
        }

        public void Edit(Auction auction, int id)
        {
            var auctionDesc = _dbContext.AuctionDbs.FirstOrDefault(a => a.Id.Equals(id));
            auctionDesc.Description = auction.Description;
            _dbContext.SaveChanges();
        }

        public void AddBid(Bid bid, Auction auction)
        {
            bool added = auction.AddBid(bid, auction);
            if (added)
            {
                BidDb bdb = _mapper.Map<BidDb>(bid);
                _dbContext.BidsDbs.Add(bdb);
                _dbContext.SaveChanges();
            }
        }
    }
}
