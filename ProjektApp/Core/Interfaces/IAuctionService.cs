namespace ProjektApp.Core.Interfaces
{
    public interface IAuctionService
    {
        List<Auction> GetAuctions();
        List<Auction> GetMyBids(string userName);
        List<Auction> GetMyWinningBids(string userName);
        
        Auction GetById(int id);

        void Add(Auction auction);

        void Edit(Auction auction, int id);

        void AddBid(Bid bid, Auction auction);

        
    }
}
